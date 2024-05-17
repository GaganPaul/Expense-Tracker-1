<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Login_info_3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Login_info1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Login_info2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Budget_btn = New System.Windows.Forms.Button()
        Me.Expense_btn = New System.Windows.Forms.Button()
        Me.Report_btn = New System.Windows.Forms.Button()
        Me.Settings_btn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Logout_label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Custom_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Financial_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Year_Overview_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Custom_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Financial_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Year_Overview_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel1.Controls.Add(Me.Login_info_3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Login_info1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Login_info2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(904, 47)
        Me.Panel1.TabIndex = 0
        '
        'Login_info_3
        '
        Me.Login_info_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_info_3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login_info_3.Location = New System.Drawing.Point(563, 9)
        Me.Login_info_3.Name = "Login_info_3"
        Me.Login_info_3.Size = New System.Drawing.Size(118, 32)
        Me.Login_info_3.TabIndex = 7
        Me.Login_info_3.Text = "Time"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(686, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(61, 47)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'Login_info1
        '
        Me.Login_info1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_info1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login_info1.Location = New System.Drawing.Point(687, 7)
        Me.Login_info1.Name = "Login_info1"
        Me.Login_info1.Size = New System.Drawing.Size(217, 30)
        Me.Login_info1.TabIndex = 4
        Me.Login_info1.Text = "User"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 47)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Login_info2
        '
        Me.Login_info2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_info2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login_info2.Location = New System.Drawing.Point(57, 9)
        Me.Login_info2.Name = "Login_info2"
        Me.Login_info2.Size = New System.Drawing.Size(152, 32)
        Me.Login_info2.TabIndex = 5
        Me.Login_info2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(267, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Expense Tracker"
        '
        'Budget_btn
        '
        Me.Budget_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Budget_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Budget_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Budget_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Budget_btn.Location = New System.Drawing.Point(-9, 55)
        Me.Budget_btn.Name = "Budget_btn"
        Me.Budget_btn.Size = New System.Drawing.Size(226, 37)
        Me.Budget_btn.TabIndex = 2
        Me.Budget_btn.Text = "Budget"
        Me.Budget_btn.UseVisualStyleBackColor = False
        '
        'Expense_btn
        '
        Me.Expense_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Expense_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Expense_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Expense_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Expense_btn.Location = New System.Drawing.Point(-9, 109)
        Me.Expense_btn.Name = "Expense_btn"
        Me.Expense_btn.Size = New System.Drawing.Size(226, 38)
        Me.Expense_btn.TabIndex = 3
        Me.Expense_btn.Text = "Expense"
        Me.Expense_btn.UseVisualStyleBackColor = False
        '
        'Report_btn
        '
        Me.Report_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Report_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Report_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Report_btn.Location = New System.Drawing.Point(-9, 166)
        Me.Report_btn.Name = "Report_btn"
        Me.Report_btn.Size = New System.Drawing.Size(226, 34)
        Me.Report_btn.TabIndex = 4
        Me.Report_btn.Text = "Report"
        Me.Report_btn.UseVisualStyleBackColor = False
        '
        'Settings_btn
        '
        Me.Settings_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Settings_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Settings_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Settings_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Settings_btn.Location = New System.Drawing.Point(-9, 217)
        Me.Settings_btn.Name = "Settings_btn"
        Me.Settings_btn.Size = New System.Drawing.Size(226, 39)
        Me.Settings_btn.TabIndex = 5
        Me.Settings_btn.Text = "Settings"
        Me.Settings_btn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.Settings_btn)
        Me.Panel2.Controls.Add(Me.Logout_label)
        Me.Panel2.Controls.Add(Me.Report_btn)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.Expense_btn)
        Me.Panel2.Controls.Add(Me.Budget_btn)
        Me.Panel2.Location = New System.Drawing.Point(0, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(209, 329)
        Me.Panel2.TabIndex = 1
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(47, 269)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(39, 36)
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'Logout_label
        '
        Me.Logout_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Logout_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logout_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Logout_label.Location = New System.Drawing.Point(92, 273)
        Me.Logout_label.Name = "Logout_label"
        Me.Logout_label.Size = New System.Drawing.Size(62, 32)
        Me.Logout_label.TabIndex = 4
        Me.Logout_label.Text = "Exit"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(61, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Menu"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(43, 25)
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'Timer1
        '
        '
        'Custom_PictureBox
        '
        Me.Custom_PictureBox.BackgroundImage = CType(resources.GetObject("Custom_PictureBox.BackgroundImage"), System.Drawing.Image)
        Me.Custom_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Custom_PictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Custom_PictureBox.Location = New System.Drawing.Point(437, 73)
        Me.Custom_PictureBox.Name = "Custom_PictureBox"
        Me.Custom_PictureBox.Size = New System.Drawing.Size(244, 109)
        Me.Custom_PictureBox.TabIndex = 8
        Me.Custom_PictureBox.TabStop = False
        '
        'Financial_PictureBox
        '
        Me.Financial_PictureBox.BackgroundImage = CType(resources.GetObject("Financial_PictureBox.BackgroundImage"), System.Drawing.Image)
        Me.Financial_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Financial_PictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Financial_PictureBox.Location = New System.Drawing.Point(270, 225)
        Me.Financial_PictureBox.Name = "Financial_PictureBox"
        Me.Financial_PictureBox.Size = New System.Drawing.Size(244, 108)
        Me.Financial_PictureBox.TabIndex = 9
        Me.Financial_PictureBox.TabStop = False
        '
        'Year_Overview_PictureBox
        '
        Me.Year_Overview_PictureBox.BackgroundImage = CType(resources.GetObject("Year_Overview_PictureBox.BackgroundImage"), System.Drawing.Image)
        Me.Year_Overview_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Year_Overview_PictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Year_Overview_PictureBox.Location = New System.Drawing.Point(612, 225)
        Me.Year_Overview_PictureBox.Name = "Year_Overview_PictureBox"
        Me.Year_Overview_PictureBox.Size = New System.Drawing.Size(243, 108)
        Me.Year_Overview_PictureBox.TabIndex = 10
        Me.Year_Overview_PictureBox.TabStop = False
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(902, 373)
        Me.Controls.Add(Me.Year_Overview_PictureBox)
        Me.Controls.Add(Me.Financial_PictureBox)
        Me.Controls.Add(Me.Custom_PictureBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Mainform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mainform"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Custom_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Financial_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Year_Overview_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Expense_btn As Button
    Friend WithEvents Report_btn As Button
    Friend WithEvents Settings_btn As Button
    Friend WithEvents Budget_btn As Button
    Friend WithEvents Login_info2 As Label
    Friend WithEvents Login_info1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Logout_label As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Custom_PictureBox As PictureBox
    Friend WithEvents Financial_PictureBox As PictureBox
    Friend WithEvents Year_Overview_PictureBox As PictureBox
    Friend WithEvents Login_info_3 As Label
End Class
