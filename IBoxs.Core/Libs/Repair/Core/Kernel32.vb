Imports IBoxs.Core.Repair.Enum
Imports System
Imports System.Runtime.InteropServices

Namespace IBoxs.Core.Repair.Core
    ' 
    ' 	 *	移植自: 00.00.dotnetRedirect 插件, 原作者: 成音S. 引用请带上此注释
    ' 	 *	论坛地址: https://cqp.cc/t/42920
    ' 	 
    Public Module Kernel32
        '' https://docs.microsoft.com/en-us/windows/desktop/api/libloaderapi/nf-libloaderapi-adddlldirectory
        '<DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        '<MarshalAs(UnmanagedType.Bool)>
        'Public Function AddDllDirectory(ByVal lpPathName As String) As Boolean
        'End Function

        ''https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setdlldirectorya
        '<DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        '<MarshalAs(UnmanagedType.Bool)>
        'Public Function SetDllDirectory(ByVal lpPathName As String) As Boolean
        'End Function

        <DllImport("kernel32.dll")>
        Public Function SetErrorMode(ByVal uMode As UInteger) As UInteger
        End Function

        <DllImport("kernel32", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Private Function LoadLibrary(ByVal dllToLoad As String) As IntPtr
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Function LoadLibraryEx(ByVal lpFileName As String, ByVal hReservedNull As IntPtr, ByVal dwFlags As LoadLibraryFlags) As IntPtr
        End Function
    End Module
End Namespace
