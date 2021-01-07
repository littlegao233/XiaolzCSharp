Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Globalization
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace XiaolzCSharp
    Public Partial Class Form1
        Inherits Form

        Private slectitem As String

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox1.Text, "") Then Return

            If SqliHelper.CheckDataExsit("授权群号", "GroupID", textBox1.Text) = False Then
                SqliHelper.InsertData("授权群号", New String() {"GroupID", "time"}, New String() {textBox1.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView1, "授权群号", "")
                MessageBox.Show("添加成功.")
            End If
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox1.Text, "") Then Return

            If SqliHelper.CheckDataExsit("授权群号", "GroupID", textBox1.Text) = True Then
                SqliHelper.DeleteData("授权群号", "GroupID", "QQID like'" & textBox1.Text & "'")
                SqliHelper.CheckImporlistview(listView1, "授权群号", "")
                MessageBox.Show("删除成功.")
            End If
        End Sub

        Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox2.Text, "") Then Return

            If SqliHelper.CheckDataExsit("高级权限", "QQID", textBox2.Text) = False Then
                SqliHelper.InsertData("高级权限", New String() {"QQID", "time"}, New String() {textBox2.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView2, "高级权限", "")
                MessageBox.Show("添加成功.")
            End If
        End Sub

        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox2.Text, "") Then Return

            If SqliHelper.CheckDataExsit("中级权限", "QQID", textBox2.Text) = False Then
                SqliHelper.InsertData("中级权限", New String() {"QQID", "time"}, New String() {textBox2.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView3, "中级权限", "")
                MessageBox.Show("添加成功.")
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            listView1.Items.Clear()
            listView1.GridLines = True
            listView1.View = View.Details
            listView1.FullRowSelect = True
            listView1.Columns.Add("ID", 30, HorizontalAlignment.Center)
            listView1.Columns.Add("群号", listView1.Width - 30 - 5, HorizontalAlignment.Center)
            listView1.Items.Clear()
            listView2.GridLines = True
            listView2.View = View.Details
            listView2.FullRowSelect = True
            listView2.Columns.Add("ID", 30, HorizontalAlignment.Center)
            listView2.Columns.Add("高级权限QQ号", listView2.Width - 30 - 5, HorizontalAlignment.Center)
            listView3.Items.Clear()
            listView3.GridLines = True
            listView3.View = View.Details
            listView3.FullRowSelect = True
            listView3.Columns.Add("ID", 30, HorizontalAlignment.Center)
            listView3.Columns.Add("中级权限QQ号", listView3.Width - 30 - 5, HorizontalAlignment.Center)
            listView4.Items.Clear()
            listView4.GridLines = True
            listView4.View = View.Details
            listView4.FullRowSelect = True
            listView4.Columns.Add("ID", 30, HorizontalAlignment.Center)
            listView4.Columns.Add("群号", 60, HorizontalAlignment.Center)
            listView4.Columns.Add("QQ号", 60, HorizontalAlignment.Center)
            listView4.Columns.Add("MessageReq", 60, HorizontalAlignment.Center)
            listView4.Columns.Add("MessageRandom", 80, HorizontalAlignment.Center)
            listView4.Columns.Add("时间", 150, HorizontalAlignment.Center)
            listView4.Columns.Add("消息", 250, HorizontalAlignment.Left)
            SqliHelper.CheckImporlistview(listView1, "授权群号", "")
            SqliHelper.CheckImporlistview(listView2, "高级权限", "")
            SqliHelper.CheckImporlistview(listView3, "中级权限", "")
            Dim MasterInfo = SqliHelper.ReadData("主人信息", New String() {"FeedbackGroup", "MasterQQ"}, "", "FeedbackGroup like '%%'")

            If MasterInfo.Count > 0 Then
                textBox4.Text = MasterInfo(0)(0)
                textBox5.Text = MasterInfo(0)(1)
            End If

            Call New Thread(Sub()
                                While True
                                    Dim status As List(Of String) = CpuMemoryCapacity.GetUsage()

                                    Try
                                        label21.Invoke(CType(CType(Sub() CSharpImpl.__Assign(label21.Text, String.Join(CStr(" "), CType(status, IEnumerable(Of String)))), MethodInvoker), [Delegate]))
                                    Catch
                                    End Try

                                    Thread.Sleep(2000)
                                End While
                            End Sub).Start()
        End Sub

        Private Sub 修改ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim myValue As Object = InputBox("是否要修改群号:" & slectitem & "?", "修改群号", "")
            Dim regex As Regex = New Regex("^[0-9]+$")

            If Not Equals(Convert.ToString(myValue), "") AndAlso regex.IsMatch(Convert.ToString(myValue)) = True Then
                SqliHelper.UpdateData("授权群号", New String() {"GroupID like'" & slectitem & "'"}, "GroupID='" & Convert.ToString(myValue) & "'")
                SqliHelper.CheckImporlistview(listView1, "授权群号", "")
            End If
        End Sub

        Private Sub toolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim myValue As Object = InputBox("是否要修改高级权限QQ号:" & slectitem & "?", "高级权限", "")
            Dim regex As Regex = New Regex("^[0-9]+$")

            If Not Equals(Convert.ToString(myValue), "") AndAlso regex.IsMatch(Convert.ToString(myValue)) = True Then
                SqliHelper.UpdateData("高级权限", New String() {"QQID like'" & slectitem & "'"}, "QQID='" & Convert.ToString(myValue) & "'")
                SqliHelper.CheckImporlistview(listView2, "高级权限", "")
            End If
        End Sub

        Private Sub toolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim myValue As Object = InputBox("是否要修改中级权限QQ号:" & slectitem & "?", "中级权限", "")
            Dim regex As Regex = New Regex("^[0-9]+$")

            If Not Equals(Convert.ToString(myValue), "") AndAlso regex.IsMatch(Convert.ToString(myValue)) = True Then
                SqliHelper.UpdateData("中级权限", New String() {"QQID like'" & slectitem & "'"}, "QQID='" & Convert.ToString(myValue) & "'")
                SqliHelper.CheckImporlistview(listView2, "中级权限", "")
            End If
        End Sub

        Private Sub 删除ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If SqliHelper.CheckDataExsit("授权群号", "GroupID", textBox1.Text) = True Then
                SqliHelper.DeleteData("授权群号", "GroupID", "GroupID like'" & slectitem & "'")
                SqliHelper.CheckImporlistview(listView1, "授权群号", "")
                MessageBox.Show("删除成功.")
            End If
        End Sub

        Private Sub toolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If SqliHelper.CheckDataExsit("高级权限", "QQID", slectitem) = True Then
                SqliHelper.DeleteData("高级权限", "QQID", "QQID like'" & slectitem & "'")
                SqliHelper.CheckImporlistview(listView2, "高级权限", "")
                MessageBox.Show("删除成功.")
            End If
        End Sub

        Private Sub toolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs)
            If SqliHelper.CheckDataExsit("中级权限", "QQID", slectitem) = True Then
                SqliHelper.DeleteData("中级权限", "QQID", "QQID like'" & slectitem & "'")
                SqliHelper.CheckImporlistview(listView3, "中级权限", "")
                MessageBox.Show("删除成功.")
            End If
        End Sub

        Private Sub listView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView1.SelectedItems.Count > 0 Then
                    slectitem = listView1.SelectedItems(0).SubItems(1).Text
                End If

            Catch
            End Try
        End Sub

        Private Sub listView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView2.SelectedItems.Count > 0 Then
                    slectitem = listView2.SelectedItems(0).SubItems(1).Text
                End If

            Catch
            End Try
        End Sub

        Private Sub listView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView3.SelectedItems.Count > 0 Then
                    slectitem = listView3.SelectedItems(0).SubItems(1).Text
                End If

            Catch
            End Try
        End Sub

        Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim actualdata = String.Empty
            Dim entereddata As Char() = textBox1.Text.ToCharArray()

            For Each aChar In entereddata.AsEnumerable()

                If Char.IsDigit(aChar) Then
                    actualdata = actualdata & aChar
                Else
                    actualdata.Replace(aChar, " "c)
                    actualdata.Trim()
                End If
            Next

            textBox1.Text = actualdata
        End Sub

        Private Sub textBox2_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim actualdata = String.Empty
            Dim entereddata As Char() = textBox2.Text.ToCharArray()

            For Each aChar In entereddata.AsEnumerable()

                If Char.IsDigit(aChar) Then
                    actualdata = actualdata & aChar
                Else
                    actualdata.Replace(aChar, " "c)
                    actualdata.Trim()
                End If
            Next

            textBox2.Text = actualdata
        End Sub

        Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If checkBox1.Checked = True Then
                API.MsgRecod = True
            Else
                API.MsgRecod = False
            End If
        End Sub

        Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs)
            If SqliHelper.ClearTable("消息记录") = True Then MessageBox.Show("已清空记录.")
            listView4.Items.Clear()
        End Sub

        Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox3.Text, "") Then Return
            SqliHelper.CheckImporlistview(listView4, "消息记录", " where QQID like '" & textBox3.Text & "' ")
        End Sub

        Private Sub toolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView4.SelectedItems.Count > 0 Then
                    For Each item As ListViewItem In listView4.SelectedItems
                        Dim sucess = API.Undo_GroupEvent(PInvoke.plugin_key, API.MyQQ, Long.Parse(item.SubItems(1).Text), Long.Parse(item.SubItems(4).Text), Integer.Parse(item.SubItems(3).Text))
                        If sucess Then MessageBox.Show("已撤回该消息.")
                    Next
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub toolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView4.SelectedItems.Count > 0 Then
                    For Each item As ListViewItem In listView4.SelectedItems
                        SqliHelper.DeleteData("消息记录", "ID", "ID like'" & item.SubItems(0).Text & "'")
                        listView4.Items.Remove(item)
                    Next

                    MessageBox.Show("删除成功.")
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub listView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try

                If listView4.SelectedItems.Count > 0 Then
                End If

            Catch
            End Try
        End Sub

        Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Equals(textBox4.Text, "") OrElse Equals(textBox5.Text, "") Then Return

            If SqliHelper.CheckDataExsit("主人信息", "FeedbackGroup", textBox4.Text) = False Then
                If SqliHelper.CheckDataExsit("主人信息", "MasterQQ", textBox5.Text) = False Then
                    SqliHelper.ClearTable("主人信息")
                    SqliHelper.InsertData("主人信息", New String() {"FeedbackGroup", "MasterQQ"}, New String() {textBox4.Text, textBox5.Text})
                    MessageBox.Show("添加成功.")
                Else
                    SqliHelper.UpdateData("主人信息", New String() {"MasterQQ like'" & textBox5.Text & "'"}, "FeedbackGroup='" & textBox4.Text & "'")
                    MessageBox.Show("修改成功.")
                End If
            Else

                If SqliHelper.CheckDataExsit("主人信息", "MasterQQ", textBox5.Text) = False Then
                    SqliHelper.UpdateData("主人信息", New String() {"FeedbackGroup like'%" & textBox4.Text & "%''"}, "MasterQQ='" & textBox5.Text & "'")
                    MessageBox.Show("修改成功.")
                End If
            End If

            PInvoke.FeedbackGroup = Long.Parse(textBox4.Text)
            PInvoke.MasterQQ = textBox5.Text

            If SqliHelper.CheckDataExsit("授权群号", "GroupID", textBox4.Text) = False Then
                SqliHelper.InsertData("授权群号", New String() {"GroupID", "time"}, New String() {textBox4.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView1, "授权群号", "")
            End If

            If SqliHelper.CheckDataExsit("高级权限", "QQID", textBox5.Text) = False Then
                SqliHelper.InsertData("高级权限", New String() {"QQID", "time"}, New String() {textBox5.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView2, "高级权限", "")
            End If

            If SqliHelper.CheckDataExsit("中级权限", "QQID", textBox5.Text) = False Then
                SqliHelper.InsertData("中级权限", New String() {"QQID", "time"}, New String() {textBox2.Text, Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture)})
                SqliHelper.CheckImporlistview(listView3, "中级权限", "")
            End If
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
