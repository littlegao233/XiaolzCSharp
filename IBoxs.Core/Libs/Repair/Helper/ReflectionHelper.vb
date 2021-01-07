Imports System
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.CompilerServices

Namespace IBoxs.Core.Repair
    ' 
    ' 	 *	移植自: 00.00.dotnetRedirect 插件, 原作者: 成音S. 引用请带上此注释
    ' 	 *	论坛地址: https://cqp.cc/t/42920
    ' 	 
    Public Module ReflectionHelper
#Region "--字段--"
        Public bindFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Static
#End Region

#Region "--公开方法--"
        Public Function InvokeMethod(Of T)(ByVal type As Type, ByVal instance As Object, ByVal methodName As String, ParamArray args As Object()) As T
            Dim method = GetMethod(type, methodName)

            If method IsNot Nothing Then
                Return method.Invoke(instance, args)
            End If

            Return Nothing
        End Function

        <Extension()>
        Public Function InvokeMethod(Of T)(ByVal obj As T, ByVal methodName As String, ParamArray args As Object()) As T
            Dim type = GetType(T)
            Dim method = GetMethod(type, methodName)

            If method IsNot Nothing Then
                Return method.Invoke(obj, args)
            End If

            Return Nothing
        End Function

        Public Function GetMethod(ByVal type As Type, ByVal methodName As String) As MethodInfo
            Dim result = type.GetMethods().Where(Function(mi) Equals(mi.Name, methodName)).FirstOrDefault()

            If result IsNot Nothing Then
                Return result
            End If

            Return Nothing
        End Function

        Public Function GetInstanceField(Of T)(ByVal type As Type, ByVal instance As Object, ByVal fieldName As String) As T
            Dim field = type.GetField(fieldName, bindFlags)
            Return field.GetValue(instance)
        End Function

        Public Sub SetInstanceField(Of T)(ByVal type As Type, ByVal instance As Object, ByVal fieldName As String, ByVal fieldValue As T)
            Dim field = type.GetField(fieldName, bindFlags)
            field.SetValue(instance, fieldValue)
        End Sub

        <Extension()>
        Public Sub ClearEventInvocations(ByVal obj As Object, ByVal eventName As String)
            Dim fi = obj.GetType().GetEventField(eventName)

            If fi IsNot Nothing Then
                fi.SetValue(obj, Nothing)
            End If
        End Sub

        <Extension()>
        Public Function GetEventField(ByVal type As Type, ByVal eventName As String) As FieldInfo
            Dim field As FieldInfo = Nothing

            While type IsNot Nothing
                field = type.GetField(eventName, bindFlags)

                If field IsNot Nothing AndAlso (field.FieldType Is GetType(MulticastDelegate) OrElse field.FieldType.IsSubclassOf(GetType(MulticastDelegate))) Then
                    Exit While
                End If

                field = type.GetField("EVENT_" & eventName.ToUpper(), bindFlags)

                If field IsNot Nothing Then
                    Exit While
                End If

                type = type.BaseType
            End While

            Return field
        End Function
#End Region
    End Module
End Namespace
