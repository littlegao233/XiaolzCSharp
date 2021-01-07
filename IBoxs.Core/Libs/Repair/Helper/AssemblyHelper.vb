Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports IBoxs.Core.Repair.Core
Imports IBoxs.Core.Repair.Enum

Namespace IBoxs.Core.Repair.Helper
    ' 
    ' 	 *	移植自: 00.00.dotnetRedirect 插件, 原作者: 成音S. 引用请带上此注释
    ' 	 *	论坛地址: https://cqp.cc/t/42920
    ' 	 
    Public Module AssemblyHelper
#Region "--字段--"
        Private preloaded As List(Of String) = New List(Of String)()
#End Region

#Region "--公开方法--"
        Public Function ReadFromEmbeddedResources(ByVal assemblyNames As Dictionary(Of String, String), ByVal symbolNames As Dictionary(Of String, String), ByVal requestedAssemblyName As AssemblyName, ByVal executingAssembly As Assembly) As Assembly
            Dim text As String = requestedAssemblyName.Name.ToLowerInvariant()

            If requestedAssemblyName.CultureInfo IsNot Nothing AndAlso Not String.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name) Then
                text = String.Format("{0}.{1}", requestedAssemblyName.CultureInfo.Name, text)
            End If

            Dim rawAssembly As Byte()

            Using stream = LoadStream(assemblyNames, text, executingAssembly)

                If stream Is Nothing Then
                    Return Nothing
                End If

                rawAssembly = ReadStream(stream)
            End Using

            Using stream2 = LoadStream(symbolNames, text, executingAssembly)

                If stream2 IsNot Nothing Then
                    Dim rawSymbolStore = ReadStream(stream2)
                    Return Assembly.Load(rawAssembly, rawSymbolStore)
                End If
            End Using

            Return Assembly.Load(rawAssembly)
        End Function

        Public Function ReadFromEmbeddedResources(ByVal name As String, ByVal executingAssembly As Assembly) As Assembly
            Dim assemblys As String() = executingAssembly.GetManifestResourceNames()
            Dim rawAssembly As Byte()

            For Each file In assemblys

                If file.EndsWith(".resources") Then
                    If Equals(file, name.Split(","c)(0)) Then
                        Return executingAssembly
                    End If
                End If

                If Equals(file, name) Then
                    Return executingAssembly
                End If

                If file.EndsWith(".dll") OrElse file.EndsWith(".dll.compressed") Then
                    Using stream = LoadStream(file, executingAssembly)

                        If stream Is Nothing Then
                            Return Nothing
                        End If

                        rawAssembly = ReadStream(stream)
                    End Using

                    Dim tmp = Assembly.Load(rawAssembly)

                    If Equals(tmp.FullName, name) Then
                        Return tmp
                    End If
                End If
            Next

            Return Nothing
        End Function

        Public Function CosturaAssemblyLoader(ByVal sender As Object, ByVal args As ResolveEventArgs, ByVal executingAssembly As Assembly) As Assembly
            Dim typeLoader = executingAssembly.GetType("Costura.AssemblyLoader")

            If typeLoader IsNot Nothing Then
                If Environment.OSVersion.Version.Major > 5 AndAlso Environment.OSVersion.Version.Minor > 2 Then
                    If preloaded.Any() AndAlso Not preloaded.Contains(executingAssembly.FullName) Then
                        preloaded.Add(executingAssembly.FullName)
                        CosturaPreload(executingAssembly, typeLoader)
                    End If
                End If
                '读取其打包后生成的组件目录并尝试载入。
                Dim assemblyNames = GetInstanceField(Of Dictionary(Of String, String))(typeLoader, Nothing, "assemblyNames")
                Dim symbolNames = GetInstanceField(Of Dictionary(Of String, String))(typeLoader, Nothing, "symbolNames")
                Dim assemblyName As AssemblyName = New AssemblyName(args.Name)
                Dim embeddedAssembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName, executingAssembly)

                If embeddedAssembly IsNot Nothing Then
                    If embeddedAssembly.FullName.CompareTo(args.Name) = 0 Then
                        Return embeddedAssembly
                    End If
                End If

                '若非内嵌组件(即非托管或可执行文件)，尝试以原有重定向方法解析。
                embeddedAssembly = InvokeMethod(Of Assembly)(typeLoader, Nothing, "ResolveAssembly", New Object() {sender, args})

                If embeddedAssembly IsNot Nothing Then
                    If embeddedAssembly.FullName.CompareTo(args.Name) = 0 Then
                        Return embeddedAssembly
                    End If
                End If
            End If

            Return executingAssembly
        End Function

        Public Function AssemblyLoad(ByVal name As String, ByVal executingAssembly As Assembly) As Assembly
            If executingAssembly.FullName.CompareTo(name) = 0 Then
                Return executingAssembly
            End If

            '若组件为使用Native SDK，理应存在Fody.Costura 打包及重定向。
            '尝试解析其重定向类。
            executingAssembly = CosturaAssemblyLoader(Nothing, New ResolveEventArgs(name), executingAssembly)

            If executingAssembly.FullName.CompareTo(name) = 0 Then
                Return executingAssembly
            End If
            '若组件非Fody.Costura，尝试解析其内嵌组件。
            Dim tmp = ReadFromEmbeddedResources(name, executingAssembly)

            If tmp IsNot Nothing Then
                Return tmp
            End If

            Return Nothing
        End Function

        Public Function IsDotNetAssembly(ByVal peFile As String) As Boolean
            Dim peHeader As UInteger
            Dim dataDictionaryStart As UShort
            Dim dataDictionaryRVA = New UInteger(15) {}
            Dim dataDictionarySize = New UInteger(15) {}
            Dim fs As Stream = New FileStream(peFile, FileMode.Open, FileAccess.Read)
            Dim reader As BinaryReader = New BinaryReader(fs)
            fs.Position = &H3C
            peHeader = reader.ReadUInt32()
            fs.Position = peHeader
            dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(fs.Position) + &H60)
            fs.Position = dataDictionaryStart

            Try

                For i = 0 To 15 - 1
                    dataDictionaryRVA(i) = reader.ReadUInt32()
                    dataDictionarySize(i) = reader.ReadUInt32()
                Next

            Finally
                fs.Position = 0
                fs.Close()
            End Try

            Return dataDictionaryRVA(14) = 0
        End Function

        Public Sub PreloadUnmanagedLibraries(ByVal executingAssembly As Assembly, ByVal hash As String, ByVal tempBasePath As String, ByVal libs As List(Of String), ByVal checksums As Dictionary(Of String, String))
            ' since tempBasePath is per user, the mutex can be per user
            Dim mutexId = String.Format("Costura{0}", hash)

            Using mutex = New Mutex(False, mutexId)
                Dim hasHandle = False

                Try

                    Try
                        hasHandle = mutex.WaitOne(60000, False)

                        If hasHandle = False Then
                            Throw New TimeoutException("等待独占访问的超时")
                        End If

                    Catch __unusedAbandonedMutexException1__ As AbandonedMutexException
                        hasHandle = True
                    End Try

                    Dim bittyness = If(IntPtr.Size = 8, "64", "32")
                    CreateDirectory(Path.Combine(tempBasePath, bittyness))
                    InternalPreloadUnmanagedLibraries(executingAssembly, tempBasePath, libs, checksums)
                Finally

                    If hasHandle Then
                        mutex.ReleaseMutex()
                    End If
                End Try
            End Using
        End Sub

        Public Function CalculateChecksum(ByVal filename As String) As String
            Using fs = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite Or FileShare.Delete)

                Using bs = New BufferedStream(fs)

                    Using sha1 = New SHA1CryptoServiceProvider()
                        Dim hash = sha1.ComputeHash(bs)
                        Dim formatted = New StringBuilder(2 * hash.Length)

                        For Each b In hash
                            formatted.AppendFormat("{0:X2}", b)
                        Next

                        Return formatted.ToString()
                    End Using
                End Using
            End Using
        End Function

        Public Sub CopyTo(ByVal source As Stream, ByVal destination As Stream)
            Dim array = New Byte(81919) {}
            Dim count As Integer

            While CSharpImpl.__Assign(count, source.Read(array, 0, array.Length)) <> 0
                destination.Write(array, 0, count)
            End While
        End Sub

        Public Function ReadStream(ByVal stream As Stream) As Byte()
            Dim array = New Byte(stream.Length - 1) {}
            stream.Read(array, 0, array.Length)
            Return array
        End Function

        Public Function LoadStream(ByVal fullName As String, ByVal executingAssembly As Assembly) As Stream
            If fullName.EndsWith(".compressed") Then
                Using manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName)

                    Using deflateStream As DeflateStream = New DeflateStream(manifestResourceStream, CompressionMode.Decompress)
                        Dim memoryStream As MemoryStream = New MemoryStream()
                        CopyTo(deflateStream, memoryStream)
                        memoryStream.Position = 0L
                        Return memoryStream
                    End Using
                End Using
            End If

            Return executingAssembly.GetManifestResourceStream(fullName)
        End Function

        Public Function LoadStream(ByVal resourceNames As Dictionary(Of String, String), ByVal name As String, ByVal executingAssembly As Assembly) As Stream
            Dim fullName As String

            If resourceNames.TryGetValue(name, fullName) Then
                Return LoadStream(fullName, executingAssembly)
            End If

            Return Nothing
        End Function
#End Region

#Region "--私有方法--"
        Private Sub CosturaPreload(ByVal executingAssembly As Assembly, ByVal typeLoader As Type)
            '读取其打包后生成的preload组件目录并尝试载入。
            Dim preloadList As List(Of String) = New List(Of String)()
            Dim preload32List As List(Of String) = New List(Of String)()
            Dim preload64List As List(Of String) = New List(Of String)()   ' 预兼容 64位 组件, 当酷Q支持 64时则生效
            Dim checksums As Dictionary(Of String, String) = New Dictionary(Of String, String)()

            Try
                checksums = GetInstanceField(Of Dictionary(Of String, String))(typeLoader, Nothing, "checksums")
                preload32List = GetInstanceField(Of List(Of String))(typeLoader, Nothing, "preload32List")
                preload64List = GetInstanceField(Of List(Of String))(typeLoader, Nothing, "preload64List")
                preloadList = GetInstanceField(Of List(Of String))(typeLoader, Nothing, "preloadList")
            Catch
            End Try

            If checksums.Any() Then
                'var hash = $"{Process.GetCurrentProcess ().Id}_{executingAssembly.GetHashCode ()}";
                Dim hash = String.Format("{0}_{1}", Process.GetCurrentProcess().Id, executingAssembly.GetHashCode())
                Dim prefixPath = Path.Combine(Path.GetTempPath(), "Costura")
                Dim tempBasePath = Path.Combine(prefixPath, hash)
                PreloadUnmanagedLibraries(executingAssembly, hash, tempBasePath, preloadList.Concat(preload32List).ToList(), checksums)
            End If
        End Sub

        Private Sub CreateDirectory(ByVal tempBasePath As String)
            If Not Directory.Exists(tempBasePath) Then
                Directory.CreateDirectory(tempBasePath)
            End If
        End Sub

        Private Function ResourceNameToPath(ByVal [lib] As String) As String
            Dim bittyness = If(IntPtr.Size = 8, "64", "32")
            Dim name = [lib]

            If [lib].StartsWith(String.Concat("costura", bittyness, ".")) Then
                name = Path.Combine(bittyness, [lib].Substring(10))
            ElseIf [lib].StartsWith("costura.") Then
                name = [lib].Substring(8)
            End If

            If name.EndsWith(".compressed") Then
                name = name.Substring(0, name.Length - 11)
            End If

            Return name
        End Function

        Private Sub InternalPreloadUnmanagedLibraries(ByVal executingAssembly As Assembly, ByVal tempBasePath As String, ByVal libs As IList(Of String), ByVal checksums As Dictionary(Of String, String))
            Dim name As String

            For Each [lib] In libs
                name = ResourceNameToPath([lib])
                Dim assemblyTempFilePath = Path.Combine(tempBasePath, name)

                If File.Exists(assemblyTempFilePath) Then
                    Dim checksum = CalculateChecksum(assemblyTempFilePath)

                    If Not Equals(checksum, checksums([lib])) Then
                        File.Delete(assemblyTempFilePath)
                    End If
                End If

                If Not File.Exists(assemblyTempFilePath) Then
                    Using copyStream = LoadStream([lib], executingAssembly)

                        Using assemblyTempFile = File.OpenWrite(assemblyTempFilePath)
                            CopyTo(copyStream, assemblyTempFile)
                        End Using
                    End Using
                End If
            Next

            'SetDllDirectory(tempBasePath);
            AddDllDirectory(tempBasePath)
            Dim errorModes As UInteger = 32771
            Dim originalErrorMode = SetErrorMode(errorModes)

            For Each [lib] In libs
                name = ResourceNameToPath([lib])

                If name.EndsWith(".dll") Then
                    Dim assemblyTempFilePath = Path.Combine(tempBasePath, name)

                    'LoadLibrary(assemblyTempFilePath);
                    LoadLibraryEx(assemblyTempFilePath, IntPtr.Zero, LoadLibraryFlags.LOAD_LIBRARY_SEARCH_USER_DIRS)
                End If
            Next

            ' restore to previous state
            SetErrorMode(originalErrorMode)
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
#End Region
    End Module
End Namespace
