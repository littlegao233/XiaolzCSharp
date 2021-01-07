Imports System

Namespace XiaolzCSharp
    Partial Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New ComponentModel.Container()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
            contextMenuStrip1 = New Windows.Forms.ContextMenuStrip(components)
            修改ToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
            删除ToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
            contextMenuStrip2 = New Windows.Forms.ContextMenuStrip(components)
            toolStripMenuItem1 = New Windows.Forms.ToolStripMenuItem()
            toolStripMenuItem2 = New Windows.Forms.ToolStripMenuItem()
            contextMenuStrip3 = New Windows.Forms.ContextMenuStrip(components)
            toolStripMenuItem3 = New Windows.Forms.ToolStripMenuItem()
            toolStripMenuItem4 = New Windows.Forms.ToolStripMenuItem()
            tabControl1 = New Windows.Forms.TabControl()
            tabPage1 = New Windows.Forms.TabPage()
            button7 = New Windows.Forms.Button()
            textBox5 = New Windows.Forms.TextBox()
            label13 = New Windows.Forms.Label()
            textBox4 = New Windows.Forms.TextBox()
            label12 = New Windows.Forms.Label()
            listView3 = New Windows.Forms.ListView()
            listView2 = New Windows.Forms.ListView()
            listView1 = New Windows.Forms.ListView()
            button3 = New Windows.Forms.Button()
            button4 = New Windows.Forms.Button()
            textBox2 = New Windows.Forms.TextBox()
            label2 = New Windows.Forms.Label()
            button2 = New Windows.Forms.Button()
            button1 = New Windows.Forms.Button()
            textBox1 = New Windows.Forms.TextBox()
            label1 = New Windows.Forms.Label()
            tabPage2 = New Windows.Forms.TabPage()
            button6 = New Windows.Forms.Button()
            textBox3 = New Windows.Forms.TextBox()
            label3 = New Windows.Forms.Label()
            groupBox1 = New Windows.Forms.GroupBox()
            listView4 = New Windows.Forms.ListView()
            contextMenuStrip4 = New Windows.Forms.ContextMenuStrip(components)
            toolStripMenuItem5 = New Windows.Forms.ToolStripMenuItem()
            toolStripMenuItem6 = New Windows.Forms.ToolStripMenuItem()
            button5 = New Windows.Forms.Button()
            checkBox1 = New Windows.Forms.CheckBox()
            tabPage3 = New Windows.Forms.TabPage()
            label20 = New Windows.Forms.Label()
            label19 = New Windows.Forms.Label()
            label18 = New Windows.Forms.Label()
            label17 = New Windows.Forms.Label()
            label16 = New Windows.Forms.Label()
            label15 = New Windows.Forms.Label()
            label14 = New Windows.Forms.Label()
            label11 = New Windows.Forms.Label()
            label10 = New Windows.Forms.Label()
            label9 = New Windows.Forms.Label()
            label8 = New Windows.Forms.Label()
            label7 = New Windows.Forms.Label()
            label6 = New Windows.Forms.Label()
            label5 = New Windows.Forms.Label()
            label4 = New Windows.Forms.Label()
            label21 = New Windows.Forms.Label()
            contextMenuStrip1.SuspendLayout()
            contextMenuStrip2.SuspendLayout()
            contextMenuStrip3.SuspendLayout()
            tabControl1.SuspendLayout()
            tabPage1.SuspendLayout()
            tabPage2.SuspendLayout()
            groupBox1.SuspendLayout()
            contextMenuStrip4.SuspendLayout()
            tabPage3.SuspendLayout()
            SuspendLayout()
            ' 
            ' contextMenuStrip1
            ' 
            contextMenuStrip1.Items.AddRange(New Windows.Forms.ToolStripItem() {修改ToolStripMenuItem, 删除ToolStripMenuItem})
            contextMenuStrip1.Name = "contextMenuStrip1"
            contextMenuStrip1.Size = New Drawing.Size(101, 48)
            ' 
            ' 修改ToolStripMenuItem
            ' 
            修改ToolStripMenuItem.Name = "修改ToolStripMenuItem"
            修改ToolStripMenuItem.Size = New Drawing.Size(100, 22)
            修改ToolStripMenuItem.Text = "修改"
            AddHandler 修改ToolStripMenuItem.Click, New EventHandler(AddressOf 修改ToolStripMenuItem_Click)
            ' 
            ' 删除ToolStripMenuItem
            ' 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
            删除ToolStripMenuItem.Size = New Drawing.Size(100, 22)
            删除ToolStripMenuItem.Text = "删除"
            AddHandler 删除ToolStripMenuItem.Click, New EventHandler(AddressOf 删除ToolStripMenuItem_Click)
            ' 
            ' contextMenuStrip2
            ' 
            contextMenuStrip2.Items.AddRange(New Windows.Forms.ToolStripItem() {toolStripMenuItem1, toolStripMenuItem2})
            contextMenuStrip2.Name = "contextMenuStrip1"
            contextMenuStrip2.Size = New Drawing.Size(101, 48)
            ' 
            ' toolStripMenuItem1
            ' 
            toolStripMenuItem1.Name = "toolStripMenuItem1"
            toolStripMenuItem1.Size = New Drawing.Size(100, 22)
            toolStripMenuItem1.Text = "修改"
            AddHandler toolStripMenuItem1.Click, New EventHandler(AddressOf toolStripMenuItem1_Click)
            ' 
            ' toolStripMenuItem2
            ' 
            toolStripMenuItem2.Name = "toolStripMenuItem2"
            toolStripMenuItem2.Size = New Drawing.Size(100, 22)
            toolStripMenuItem2.Text = "删除"
            AddHandler toolStripMenuItem2.Click, New EventHandler(AddressOf toolStripMenuItem2_Click)
            ' 
            ' contextMenuStrip3
            ' 
            contextMenuStrip3.Items.AddRange(New Windows.Forms.ToolStripItem() {toolStripMenuItem3, toolStripMenuItem4})
            contextMenuStrip3.Name = "contextMenuStrip1"
            contextMenuStrip3.Size = New Drawing.Size(101, 48)
            ' 
            ' toolStripMenuItem3
            ' 
            toolStripMenuItem3.Name = "toolStripMenuItem3"
            toolStripMenuItem3.Size = New Drawing.Size(100, 22)
            toolStripMenuItem3.Text = "修改"
            AddHandler toolStripMenuItem3.Click, New EventHandler(AddressOf toolStripMenuItem3_Click)
            ' 
            ' toolStripMenuItem4
            ' 
            toolStripMenuItem4.Name = "toolStripMenuItem4"
            toolStripMenuItem4.Size = New Drawing.Size(100, 22)
            toolStripMenuItem4.Text = "删除"
            AddHandler toolStripMenuItem4.Click, New EventHandler(AddressOf toolStripMenuItem4_Click)
            ' 
            ' tabControl1
            ' 
            tabControl1.Controls.Add(tabPage1)
            tabControl1.Controls.Add(tabPage2)
            tabControl1.Controls.Add(tabPage3)
            tabControl1.Location = New Drawing.Point(12, 11)
            tabControl1.Name = "tabControl1"
            tabControl1.SelectedIndex = 0
            tabControl1.Size = New Drawing.Size(493, 333)
            tabControl1.TabIndex = 11
            ' 
            ' tabPage1
            ' 
            tabPage1.Controls.Add(button7)
            tabPage1.Controls.Add(textBox5)
            tabPage1.Controls.Add(label13)
            tabPage1.Controls.Add(textBox4)
            tabPage1.Controls.Add(label12)
            tabPage1.Controls.Add(listView3)
            tabPage1.Controls.Add(listView2)
            tabPage1.Controls.Add(listView1)
            tabPage1.Controls.Add(button3)
            tabPage1.Controls.Add(button4)
            tabPage1.Controls.Add(textBox2)
            tabPage1.Controls.Add(label2)
            tabPage1.Controls.Add(button2)
            tabPage1.Controls.Add(button1)
            tabPage1.Controls.Add(textBox1)
            tabPage1.Controls.Add(label1)
            tabPage1.Location = New Drawing.Point(4, 22)
            tabPage1.Name = "tabPage1"
            tabPage1.Padding = New Windows.Forms.Padding(3)
            tabPage1.Size = New Drawing.Size(485, 307)
            tabPage1.TabIndex = 0
            tabPage1.Text = "权限设置"
            tabPage1.UseVisualStyleBackColor = True
            ' 
            ' button7
            ' 
            button7.Location = New Drawing.Point(417, 271)
            button7.Name = "button7"
            button7.Size = New Drawing.Size(52, 27)
            button7.TabIndex = 26
            button7.Text = "设置"
            button7.UseVisualStyleBackColor = True
            AddHandler button7.Click, New EventHandler(AddressOf button7_Click)
            ' 
            ' textBox5
            ' 
            textBox5.Location = New Drawing.Point(285, 276)
            textBox5.Name = "textBox5"
            textBox5.Size = New Drawing.Size(126, 21)
            textBox5.TabIndex = 25
            ' 
            ' label13
            ' 
            label13.AutoSize = True
            label13.Location = New Drawing.Point(217, 279)
            label13.Name = "label13"
            label13.Size = New Drawing.Size(59, 12)
            label13.TabIndex = 24
            label13.Text = "主人QQ号:"
            ' 
            ' textBox4
            ' 
            textBox4.Location = New Drawing.Point(83, 276)
            textBox4.Name = "textBox4"
            textBox4.Size = New Drawing.Size(126, 21)
            textBox4.TabIndex = 23
            ' 
            ' label12
            ' 
            label12.AutoSize = True
            label12.Location = New Drawing.Point(19, 279)
            label12.Name = "label12"
            label12.Size = New Drawing.Size(59, 12)
            label12.TabIndex = 22
            label12.Text = "反馈群号:"
            ' 
            ' listView3
            ' 
            listView3.Activation = Windows.Forms.ItemActivation.OneClick
            listView3.ContextMenuStrip = contextMenuStrip3
            listView3.FullRowSelect = True
            listView3.HeaderStyle = Windows.Forms.ColumnHeaderStyle.None
            listView3.HideSelection = False
            listView3.Location = New Drawing.Point(324, 85)
            listView3.Name = "listView3"
            listView3.Size = New Drawing.Size(145, 177)
            listView3.TabIndex = 21
            listView3.UseCompatibleStateImageBehavior = False
            AddHandler listView3.SelectedIndexChanged, New EventHandler(AddressOf listView3_SelectedIndexChanged)
            ' 
            ' listView2
            ' 
            listView2.Activation = Windows.Forms.ItemActivation.OneClick
            listView2.ContextMenuStrip = contextMenuStrip2
            listView2.FullRowSelect = True
            listView2.HeaderStyle = Windows.Forms.ColumnHeaderStyle.None
            listView2.HideSelection = False
            listView2.Location = New Drawing.Point(171, 85)
            listView2.Name = "listView2"
            listView2.Size = New Drawing.Size(145, 177)
            listView2.TabIndex = 20
            listView2.UseCompatibleStateImageBehavior = False
            AddHandler listView2.SelectedIndexChanged, New EventHandler(AddressOf listView2_SelectedIndexChanged)
            ' 
            ' listView1
            ' 
            listView1.Activation = Windows.Forms.ItemActivation.OneClick
            listView1.ContextMenuStrip = contextMenuStrip1
            listView1.FullRowSelect = True
            listView1.HeaderStyle = Windows.Forms.ColumnHeaderStyle.None
            listView1.HideSelection = False
            listView1.Location = New Drawing.Point(17, 85)
            listView1.Name = "listView1"
            listView1.Size = New Drawing.Size(145, 177)
            listView1.TabIndex = 19
            listView1.UseCompatibleStateImageBehavior = False
            AddHandler listView1.SelectedIndexChanged, New EventHandler(AddressOf listView1_SelectedIndexChanged)
            ' 
            ' button3
            ' 
            button3.Location = New Drawing.Point(357, 44)
            button3.Name = "button3"
            button3.Size = New Drawing.Size(112, 27)
            button3.TabIndex = 18
            button3.Text = "添加中级权限"
            button3.UseVisualStyleBackColor = True
            AddHandler button3.Click, New EventHandler(AddressOf button3_Click)
            ' 
            ' button4
            ' 
            button4.Location = New Drawing.Point(209, 44)
            button4.Name = "button4"
            button4.Size = New Drawing.Size(112, 27)
            button4.TabIndex = 17
            button4.Text = "添加高级权限"
            button4.UseVisualStyleBackColor = True
            AddHandler button4.Click, New EventHandler(AddressOf button4_Click)
            ' 
            ' textBox2
            ' 
            textBox2.Location = New Drawing.Point(68, 47)
            textBox2.Name = "textBox2"
            textBox2.Size = New Drawing.Size(126, 21)
            textBox2.TabIndex = 16
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Location = New Drawing.Point(19, 50)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(35, 12)
            label2.TabIndex = 15
            label2.Text = "QQ号:"
            ' 
            ' button2
            ' 
            button2.Location = New Drawing.Point(357, 9)
            button2.Name = "button2"
            button2.Size = New Drawing.Size(112, 27)
            button2.TabIndex = 14
            button2.Text = "删除授权群号"
            button2.UseVisualStyleBackColor = True
            AddHandler button2.Click, New EventHandler(AddressOf button2_Click)
            ' 
            ' button1
            ' 
            button1.Location = New Drawing.Point(209, 8)
            button1.Name = "button1"
            button1.Size = New Drawing.Size(112, 27)
            button1.TabIndex = 13
            button1.Text = "添加授权群号"
            button1.UseVisualStyleBackColor = True
            AddHandler button1.Click, New EventHandler(AddressOf button1_Click)
            ' 
            ' textBox1
            ' 
            textBox1.Location = New Drawing.Point(68, 13)
            textBox1.Name = "textBox1"
            textBox1.Size = New Drawing.Size(126, 21)
            textBox1.TabIndex = 12
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Location = New Drawing.Point(19, 16)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(35, 12)
            label1.TabIndex = 11
            label1.Text = "群号:"
            ' 
            ' tabPage2
            ' 
            tabPage2.Controls.Add(button6)
            tabPage2.Controls.Add(textBox3)
            tabPage2.Controls.Add(label3)
            tabPage2.Controls.Add(groupBox1)
            tabPage2.Controls.Add(button5)
            tabPage2.Controls.Add(checkBox1)
            tabPage2.Location = New Drawing.Point(4, 22)
            tabPage2.Name = "tabPage2"
            tabPage2.Padding = New Windows.Forms.Padding(3)
            tabPage2.Size = New Drawing.Size(485, 307)
            tabPage2.TabIndex = 1
            tabPage2.Text = "消息处理"
            tabPage2.UseVisualStyleBackColor = True
            ' 
            ' button6
            ' 
            button6.Location = New Drawing.Point(244, 273)
            button6.Name = "button6"
            button6.Size = New Drawing.Size(105, 24)
            button6.TabIndex = 5
            button6.Text = "查询消息记录"
            button6.UseVisualStyleBackColor = True
            AddHandler button6.Click, New EventHandler(AddressOf button6_Click)
            ' 
            ' textBox3
            ' 
            textBox3.Location = New Drawing.Point(70, 276)
            textBox3.Name = "textBox3"
            textBox3.Size = New Drawing.Size(147, 21)
            textBox3.TabIndex = 4
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Location = New Drawing.Point(16, 280)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(47, 12)
            label3.TabIndex = 3
            label3.Text = "QQ号码:"
            ' 
            ' groupBox1
            ' 
            groupBox1.Controls.Add(listView4)
            groupBox1.Location = New Drawing.Point(11, 45)
            groupBox1.Name = "groupBox1"
            groupBox1.Size = New Drawing.Size(459, 221)
            groupBox1.TabIndex = 2
            groupBox1.TabStop = False
            groupBox1.Text = "查询消息记录, 按住shift多选. 撤回注意是否已经有权限, 时间是否超过可撤期限."
            ' 
            ' listView4
            ' 
            listView4.Activation = Windows.Forms.ItemActivation.OneClick
            listView4.ContextMenuStrip = contextMenuStrip4
            listView4.FullRowSelect = True
            listView4.HeaderStyle = Windows.Forms.ColumnHeaderStyle.None
            listView4.HideSelection = False
            listView4.Location = New Drawing.Point(8, 18)
            listView4.Name = "listView4"
            listView4.Size = New Drawing.Size(445, 195)
            listView4.TabIndex = 20
            listView4.UseCompatibleStateImageBehavior = False
            AddHandler listView4.SelectedIndexChanged, New EventHandler(AddressOf listView4_SelectedIndexChanged)
            ' 
            ' contextMenuStrip4
            ' 
            contextMenuStrip4.Items.AddRange(New Windows.Forms.ToolStripItem() {toolStripMenuItem5, toolStripMenuItem6})
            contextMenuStrip4.Name = "contextMenuStrip1"
            contextMenuStrip4.Size = New Drawing.Size(101, 48)
            ' 
            ' toolStripMenuItem5
            ' 
            toolStripMenuItem5.Name = "toolStripMenuItem5"
            toolStripMenuItem5.Size = New Drawing.Size(100, 22)
            toolStripMenuItem5.Text = "撤回"
            AddHandler toolStripMenuItem5.Click, New EventHandler(AddressOf toolStripMenuItem5_Click)
            ' 
            ' toolStripMenuItem6
            ' 
            toolStripMenuItem6.Name = "toolStripMenuItem6"
            toolStripMenuItem6.Size = New Drawing.Size(100, 22)
            toolStripMenuItem6.Text = "删除"
            AddHandler toolStripMenuItem6.Click, New EventHandler(AddressOf toolStripMenuItem6_Click)
            ' 
            ' button5
            ' 
            button5.Location = New Drawing.Point(264, 16)
            button5.Name = "button5"
            button5.Size = New Drawing.Size(105, 24)
            button5.TabIndex = 1
            button5.Text = "清空消息记录"
            button5.UseVisualStyleBackColor = True
            AddHandler button5.Click, New EventHandler(AddressOf button5_Click)
            ' 
            ' checkBox1
            ' 
            checkBox1.AutoSize = True
            checkBox1.Location = New Drawing.Point(25, 19)
            checkBox1.Name = "checkBox1"
            checkBox1.Size = New Drawing.Size(210, 16)
            checkBox1.TabIndex = 0
            checkBox1.Text = "开启/关闭消息记录(用于撤回消息)"
            checkBox1.UseVisualStyleBackColor = True
            AddHandler checkBox1.CheckedChanged, New EventHandler(AddressOf checkBox1_CheckedChanged)
            ' 
            ' tabPage3
            ' 
            tabPage3.Controls.Add(label20)
            tabPage3.Controls.Add(label19)
            tabPage3.Controls.Add(label18)
            tabPage3.Controls.Add(label17)
            tabPage3.Controls.Add(label16)
            tabPage3.Controls.Add(label15)
            tabPage3.Controls.Add(label14)
            tabPage3.Controls.Add(label11)
            tabPage3.Controls.Add(label10)
            tabPage3.Controls.Add(label9)
            tabPage3.Controls.Add(label8)
            tabPage3.Controls.Add(label7)
            tabPage3.Controls.Add(label6)
            tabPage3.Controls.Add(label5)
            tabPage3.Controls.Add(label4)
            tabPage3.Location = New Drawing.Point(4, 22)
            tabPage3.Name = "tabPage3"
            tabPage3.Size = New Drawing.Size(485, 307)
            tabPage3.TabIndex = 2
            tabPage3.Text = "命令大全"
            tabPage3.UseVisualStyleBackColor = True
            ' 
            ' label20
            ' 
            label20.AutoSize = True
            label20.ForeColor = Drawing.SystemColors.MenuHighlight
            label20.Location = New Drawing.Point(258, 92)
            label20.Name = "label20"
            label20.Size = New Drawing.Size(77, 12)
            label20.TabIndex = 14
            label20.Text = "解除全员禁言"
            ' 
            ' label19
            ' 
            label19.AutoSize = True
            label19.ForeColor = Drawing.SystemColors.MenuHighlight
            label19.Location = New Drawing.Point(258, 65)
            label19.Name = "label19"
            label19.Size = New Drawing.Size(53, 12)
            label19.TabIndex = 13
            label19.Text = "全员禁言"
            ' 
            ' label18
            ' 
            label18.AutoSize = True
            label18.ForeColor = Drawing.SystemColors.MenuHighlight
            label18.Location = New Drawing.Point(18, 286)
            label18.Name = "label18"
            label18.Size = New Drawing.Size(107, 12)
            label18.TabIndex = 12
            label18.Text = "删除黑名单1234567"
            ' 
            ' label17
            ' 
            label17.AutoSize = True
            label17.ForeColor = Drawing.SystemColors.MenuHighlight
            label17.Location = New Drawing.Point(258, 37)
            label17.Name = "label17"
            label17.Size = New Drawing.Size(95, 12)
            label17.TabIndex = 11
            label17.Text = "解除禁言1234567"
            ' 
            ' label16
            ' 
            label16.AutoSize = True
            label16.ForeColor = Drawing.SystemColors.MenuHighlight
            label16.Location = New Drawing.Point(18, 258)
            label16.Name = "label16"
            label16.Size = New Drawing.Size(131, 12)
            label16.TabIndex = 10
            label16.Text = "添加全局黑名单1234567"
            ' 
            ' label15
            ' 
            label15.AutoSize = True
            label15.ForeColor = Drawing.SystemColors.MenuHighlight
            label15.Location = New Drawing.Point(258, 9)
            label15.Name = "label15"
            label15.Size = New Drawing.Size(125, 12)
            label15.TabIndex = 9
            label15.Text = "禁言1234567时间1分钟"
            ' 
            ' label14
            ' 
            label14.AutoSize = True
            label14.ForeColor = Drawing.SystemColors.MenuHighlight
            label14.Location = New Drawing.Point(18, 231)
            label14.Name = "label14"
            label14.Size = New Drawing.Size(107, 12)
            label14.TabIndex = 8
            label14.Text = "添加黑名单1234567"
            ' 
            ' label11
            ' 
            label11.AutoSize = True
            label11.ForeColor = Drawing.SystemColors.MenuHighlight
            label11.Location = New Drawing.Point(18, 203)
            label11.Name = "label11"
            label11.Size = New Drawing.Size(89, 12)
            label11.TabIndex = 7
            label11.Text = "拒绝进群666666"
            ' 
            ' label10
            ' 
            label10.AutoSize = True
            label10.ForeColor = Drawing.SystemColors.MenuHighlight
            label10.Location = New Drawing.Point(18, 175)
            label10.Name = "label10"
            label10.Size = New Drawing.Size(89, 12)
            label10.TabIndex = 6
            label10.Text = "同意进群666666"
            ' 
            ' label9
            ' 
            label9.AutoSize = True
            label9.ForeColor = Drawing.SystemColors.MenuHighlight
            label9.Location = New Drawing.Point(18, 148)
            label9.Name = "label9"
            label9.Size = New Drawing.Size(77, 12)
            label9.TabIndex = 5
            label9.Text = "开启消息记录"
            ' 
            ' label8
            ' 
            label8.AutoSize = True
            label8.ForeColor = Drawing.SystemColors.MenuHighlight
            label8.Location = New Drawing.Point(18, 120)
            label8.Name = "label8"
            label8.Size = New Drawing.Size(119, 12)
            label8.TabIndex = 4
            label8.Text = "拒绝加1234567为好友"
            ' 
            ' label7
            ' 
            label7.AutoSize = True
            label7.ForeColor = Drawing.SystemColors.MenuHighlight
            label7.Location = New Drawing.Point(18, 92)
            label7.Name = "label7"
            label7.Size = New Drawing.Size(119, 12)
            label7.TabIndex = 3
            label7.Text = "同意加1234567为好友"
            ' 
            ' label6
            ' 
            label6.AutoSize = True
            label6.ForeColor = Drawing.SystemColors.MenuHighlight
            label6.Location = New Drawing.Point(18, 65)
            label6.Name = "label6"
            label6.Size = New Drawing.Size(95, 12)
            label6.TabIndex = 2
            label6.Text = "拒绝1234567入群"
            ' 
            ' label5
            ' 
            label5.AutoSize = True
            label5.ForeColor = Drawing.SystemColors.MenuHighlight
            label5.Location = New Drawing.Point(18, 37)
            label5.Name = "label5"
            label5.Size = New Drawing.Size(95, 12)
            label5.TabIndex = 1
            label5.Text = "同意1234567入群"
            ' 
            ' label4
            ' 
            label4.AutoSize = True
            label4.ForeColor = Drawing.SystemColors.MenuHighlight
            label4.Location = New Drawing.Point(18, 9)
            label4.Name = "label4"
            label4.Size = New Drawing.Size(137, 12)
            label4.TabIndex = 0
            label4.Text = "撤回1234567最近消息5条"
            ' 
            ' label21
            ' 
            label21.AutoSize = True
            label21.ForeColor = Drawing.Color.DarkOliveGreen
            label21.Location = New Drawing.Point(213, 9)
            label21.Name = "label21"
            label21.Size = New Drawing.Size(0, 12)
            label21.TabIndex = 12
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(6.0F, 12.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(514, 349)
            Controls.Add(label21)
            Controls.Add(tabControl1)
            FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
            Name = "Form1"
            StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Text = "权限窗口"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            contextMenuStrip1.ResumeLayout(False)
            contextMenuStrip2.ResumeLayout(False)
            contextMenuStrip3.ResumeLayout(False)
            tabControl1.ResumeLayout(False)
            tabPage1.ResumeLayout(False)
            tabPage1.PerformLayout()
            tabPage2.ResumeLayout(False)
            tabPage2.PerformLayout()
            groupBox1.ResumeLayout(False)
            contextMenuStrip4.ResumeLayout(False)
            tabPage3.ResumeLayout(False)
            tabPage3.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

#End Region
        Private contextMenuStrip1 As Windows.Forms.ContextMenuStrip
        Private 修改ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
        Private 删除ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
        Private contextMenuStrip2 As Windows.Forms.ContextMenuStrip
        Private toolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem2 As Windows.Forms.ToolStripMenuItem
        Private contextMenuStrip3 As Windows.Forms.ContextMenuStrip
        Private toolStripMenuItem3 As Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem4 As Windows.Forms.ToolStripMenuItem
        Private tabControl1 As Windows.Forms.TabControl
        Private tabPage1 As Windows.Forms.TabPage
        Private listView3 As Windows.Forms.ListView
        Private listView2 As Windows.Forms.ListView
        Private listView1 As Windows.Forms.ListView
        Private button3 As Windows.Forms.Button
        Private button4 As Windows.Forms.Button
        Private textBox2 As Windows.Forms.TextBox
        Private label2 As Windows.Forms.Label
        Private button2 As Windows.Forms.Button
        Private button1 As Windows.Forms.Button
        Private textBox1 As Windows.Forms.TextBox
        Private label1 As Windows.Forms.Label
        Private tabPage2 As Windows.Forms.TabPage
        Private button5 As Windows.Forms.Button
        Private checkBox1 As Windows.Forms.CheckBox
        Private button6 As Windows.Forms.Button
        Private textBox3 As Windows.Forms.TextBox
        Private label3 As Windows.Forms.Label
        Private groupBox1 As Windows.Forms.GroupBox
        Private listView4 As Windows.Forms.ListView
        Private contextMenuStrip4 As Windows.Forms.ContextMenuStrip
        Private toolStripMenuItem5 As Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem6 As Windows.Forms.ToolStripMenuItem
        Private tabPage3 As Windows.Forms.TabPage
        Private label4 As Windows.Forms.Label
        Private label5 As Windows.Forms.Label
        Private label6 As Windows.Forms.Label
        Private label7 As Windows.Forms.Label
        Private label8 As Windows.Forms.Label
        Private label9 As Windows.Forms.Label
        Private label11 As Windows.Forms.Label
        Private label10 As Windows.Forms.Label
        Private button7 As Windows.Forms.Button
        Private textBox5 As Windows.Forms.TextBox
        Private label13 As Windows.Forms.Label
        Private textBox4 As Windows.Forms.TextBox
        Private label12 As Windows.Forms.Label
        Private label14 As Windows.Forms.Label
        Private label15 As Windows.Forms.Label
        Private label18 As Windows.Forms.Label
        Private label17 As Windows.Forms.Label
        Private label16 As Windows.Forms.Label
        Private label19 As Windows.Forms.Label
        Private label20 As Windows.Forms.Label
        Private label21 As Windows.Forms.Label
    End Class
End Namespace
