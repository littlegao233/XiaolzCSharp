Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports IBoxs.Core.Repair.Core
Imports IBoxs.Core.Repair.Helper

Namespace IBoxs.Core.Repair
    Public Module ModuleInitializer
        Public Sub Initialize()
            Dim executingAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim typeLoader = executingAssembly.GetType("Costura.AssemblyLoader")

            If typeLoader Is Nothing Then
                Return
            End If

            Dim assemblyNames = GetInstanceField(Of Dictionary(Of String, String))(typeLoader, Nothing, "assemblyNames")
            Dim symbolNames = GetInstanceField(Of Dictionary(Of String, String))(typeLoader, Nothing, "symbolNames")
            Dim uriOuter As Uri = New Uri(If(Equals(executingAssembly.Location, Nothing), executingAssembly.CodeBase, executingAssembly.Location))
            Dim path = IO.Path.GetDirectoryName(uriOuter.LocalPath)
            Dim appPath As String = IO.Path.Combine(path, executingAssembly.GetName().Name)

            If Not Directory.Exists(path) Then
                Return
            End If

            Directory.CreateDirectory(appPath)

            AppDomain.CurrentDomain.AppendPrivatePath(appPath)

            AddDllDirectory(appPath)

            For Each assemblyName In assemblyNames
                Dim rawAssembly As Byte()

                Using stream = LoadStream(assemblyName.Value, executingAssembly)

                    If stream IsNot Nothing Then
                        rawAssembly = ReadStream(stream)
                        File.WriteAllBytes(IO.Path.Combine(appPath, assemblyName.Key & ".dll"), rawAssembly)
                    End If
                End Using
            Next

            For Each pdbName In symbolNames
                Dim rawAssembly As Byte()

                Using stream = LoadStream(pdbName.Value, executingAssembly)

                    If stream IsNot Nothing Then
                        rawAssembly = ReadStream(stream)
                        File.WriteAllBytes(IO.Path.Combine(appPath, pdbName.Key & ".pdb"), rawAssembly)
                    End If
                End Using
            Next
        End Sub
    End Module
End Namespace
