Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Management
Imports System.Threading

Namespace XiaolzCSharp
    Public Class CpuMemoryCapacity
        Public Shared Function MemoryAvailable() As List(Of String)
            Dim status As List(Of String) = New List(Of String)()
            '获取总物理内存大小
            Dim cimobject1 As ManagementClass = New ManagementClass("Win32_PhysicalMemory")
            Dim moc1 As ManagementObjectCollection = cimobject1.GetInstances()
            Dim available As Double = 0, capacity As Double = 0

            For Each mo1 As ManagementObject In moc1
                capacity += ((Math.Round(Long.Parse(mo1.Properties("Capacity").Value.ToString()) / 1024 / 1024 / 1024.0, 1)))
            Next

            moc1.Dispose()
            cimobject1.Dispose()
            '获取内存可用大小
            Dim cimobject2 As ManagementClass = New ManagementClass("Win32_PerfFormattedData_PerfOS_Memory")
            Dim moc2 As ManagementObjectCollection = cimobject2.GetInstances()

            For Each mo2 As ManagementObject In moc2
                available += ((Math.Round(Long.Parse(mo2.Properties("AvailableMBytes").Value.ToString()) / 1024.0, 1)))
            Next

            moc2.Dispose()
            cimobject2.Dispose()
            status.Add("总内存=" & capacity.ToString() & "G")
            status.Add("可使用=" & available.ToString() & "G")
            status.Add("已使用=" & (capacity - available).ToString() & "G," & Math.Round((capacity - available) / capacity * 100, 0).ToString() & "%")
            Return status
        End Function

        Public Shared Function HardwareInfo() As List(Of String)
            Dim status As List(Of String) = New List(Of String)()
            Dim CPUName = ""
            Dim mos As ManagementObjectSearcher = New ManagementObjectSearcher("Select * from Win32_Processor") 'Win32_Processor  CPU处理器

            For Each mo As ManagementObject In mos.Get()
                CPUName = mo("Name").ToString()
            Next

            mos.Dispose()
            Dim PhysicalMemory = ""
            Dim m As ManagementClass = New ManagementClass("Win32_PhysicalMemory") '内存条
            Dim mn As ManagementObjectCollection = m.GetInstances()
            PhysicalMemory = "物理内存条数量：" & mn.Count.ToString() & "  "
            Dim capacity = 0.0
            Dim count = 0

            For Each mo1 As ManagementObject In mn
                count += 1
                capacity = ((Math.Round(Long.Parse(mo1.Properties("Capacity").Value.ToString()) / 1024 / 1024 / 1024.0, 1)))
                PhysicalMemory += "第" & count.ToString() & "张内存条大小：" & capacity.ToString() & "G   "
            Next

            mn.Dispose()
            m.Dispose()
            Dim h As ManagementClass = New ManagementClass("win32_DiskDrive") '硬盘
            Dim hn As ManagementObjectCollection = h.GetInstances()

            For Each mo1 As ManagementObject In hn
                capacity += Long.Parse(mo1.Properties("Size").Value.ToString()) / 1024 / 1024 / 1024
            Next

            mn.Dispose()
            m.Dispose()
            status.Add("CPU型号：" & CPUName)
            status.Add("内存状况：" & PhysicalMemory)
            status.Add("硬盘状况：" & "硬盘为：" & capacity.ToString() & "G")
            Return status
        End Function

        Public Shared Function GetUsage() As List(Of String)
            Dim status As List(Of String) = New List(Of String)()
            Dim process = Diagnostics.Process.GetCurrentProcess()
            Dim cpu = New PerformanceCounter("Processor", "% Processor Time", "_Total", Environment.MachineName)
            Dim ram = New PerformanceCounter("Process", "Private Bytes", process.ProcessName, True)
            cpu.NextValue()
            ram.NextValue()
            Thread.Sleep(500)
            status.Add("机器人CPU使用率: " & Math.Round(cpu.NextValue() / Environment.ProcessorCount, 2).ToString() & "%")
            status.Add("机器人使用内存:" & Math.Round(ram.NextValue() / 1024 / 1024, 2).ToString() & "M")
            Return status
        End Function

        Public Shared Function GetMemoryUsage() As List(Of String)
            Dim status As List(Of String) = New List(Of String)()

            Using searcher As ManagementObjectSearcher = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfProc_Process Where Name <> '_Total' AND Name <> 'Idle'")

                For Each obj As ManagementObject In searcher.Get()
                    status.Add(String.Format("{0:0000.00}", Math.Round(Double.Parse(obj("WorkingSetPrivate").ToString()) / 1024 / 1024, 2)) & "MB (使用内存)  " & "进程名称: " & obj("Name").ToString())
                Next

                status.Sort()
                status.Reverse()
                Return status.Take(10).ToList()
            End Using
        End Function

        Public Shared Function GetCpuUsage() As List(Of String)
            Dim status As List(Of String) = New List(Of String)()
            'using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT IDProcess,Name,PercentProcessorTime,WorkingSetPrivate,Timestamp_Sys100NS FROM Win32_PerfFormattedData_PerfProc_Process Where Name <> '_Total' AND Name <> 'Idle'"))
            '{
            '    foreach (ManagementObject obj in searcher.Get())
            '    {
            '        var T = obj["Timestamp_Sys100NS"];
            '        Thread.Sleep(100);
            '       status.Add(Math.Round(double.Parse(obj["PercentProcessorTime"].ToString()) / Environment.ProcessorCount, 2).ToString() + "% (CPU占用)  " + Math.Round(double.Parse(obj["WorkingSetPrivate"].ToString()) / 1024 / 1024, 2).ToString() + "MB (使用内存)  " + "进程名称: " + obj["Name"].ToString());
            '    }
            '}

            Dim mos = New ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_PerfProc_Process Where Name <> 'Idle'")
            Dim run1 = mos.Get().Cast(Of ManagementObject)().ToDictionary(Function(mo) mo.Properties("Name").Value, Function(mo) CULng(mo.Properties("PercentProcessorTime").Value))
            Thread.Sleep(1000)
            Dim run2 = mos.Get().Cast(Of ManagementObject)().ToDictionary(Function(mo) mo.Properties("Name").Value, Function(mo) CULng(mo.Properties("PercentProcessorTime").Value))
            Dim total = run2("_Total") - run1("_Total")

            For Each kvp In run1
                Dim proc = kvp.Key
                Dim p1 = kvp.Value

                If run2.ContainsKey(proc) Then
                    Dim p2 = run2(proc)
                    Debug.WriteLine("{0:P}:{1}", (p2 - p1) / total, proc)
                    status.Add(String.Format("{0:P}", (p2 - p1) / total) & " (CPU占用)  " & "进程名称: " & proc.ToString())
                End If
            Next

            status.Sort()
            status.Reverse()
            Return status.Take(10).ToList()
        End Function
    End Class
End Namespace
