Imports System.Text
Imports Unity

Namespace IBoxs.Core.App.Core
    Public Class OnoQQ_Fun
        Private Shared _defaultEncoding As Encoding = Nothing

        ''' <summary>
        ''' 静态构造函数, 注册依赖注入回调
        ''' </summary>
        Shared Sub New()
            _defaultEncoding = Encoding.GetEncoding("GB18030")

            ' 初始化 Costura.Fody
            CosturaUtility.Initialize()

            ' 初始化依赖注入容器
            UnityContainer = New UnityContainer()
        End Sub
    End Class
End Namespace
