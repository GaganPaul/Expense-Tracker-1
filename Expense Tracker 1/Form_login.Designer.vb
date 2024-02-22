<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_login))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.username_txt = New System.Windows.Forms.TextBox()
        Me.Password_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ShowPasswordCheckBox = New System.Windows.Forms.CheckBox()
        Me.Login_btn = New System.Windows.Forms.Button()
        Me.Remove_user_btn = New System.Windows.Forms.Button()
        Me.Exit_btn = New System.Windows.Forms.Button()
        Me.Registerlink = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 488)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(72, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(258, 46)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "The One Stop Solution For All        Your Budgeting Needs"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(121, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Expense Tracker"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(540, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 23)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Login"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(425, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "User Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(425, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password"
        '
        'username_txt
        '
        Me.username_txt.BackColor = System.Drawing.Color.Beige
        Me.username_txt.Location = New System.Drawing.Point(428, 115)
        Me.username_txt.Name = "username_txt"
        Me.username_txt.Size = New System.Drawing.Size(263, 20)
        Me.username_txt.TabIndex = 4
        '
        'Password_txt
        '
        Me.Password_txt.BackColor = System.Drawing.Color.Beige
        Me.Password_txt.Location = New System.Drawing.Point(428, 185)
        Me.Password_txt.Name = "Password_txt"
        Me.Password_txt.Size = New System.Drawing.Size(263, 20)
        Me.Password_txt.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(512, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Show Password"
        '
        'ShowPasswordCheckBox
        '
        Me.ShowPasswordCheckBox.AutoSize = True
        Me.ShowPasswordCheckBox.BackColor = System.Drawing.Color.Beige
        Me.ShowPasswordCheckBox.Location = New System.Drawing.Point(601, 208)
        Me.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox"
        Me.ShowPasswordCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.ShowPasswordCheckBox.TabIndex = 7
        Me.ShowPasswordCheckBox.UseVisualStyleBackColor = False
        '
        'Login_btn
        '
        Me.Login_btn.BackColor = System.Drawing.Color.Beige
        Me.Login_btn.Location = New System.Drawing.Point(465, 272)
        Me.Login_btn.Name = "Login_btn"
        Me.Login_btn.Size = New System.Drawing.Size(202, 23)
        Me.Login_btn.TabIndex = 8
        Me.Login_btn.Text = "Login"
        Me.Login_btn.UseVisualStyleBackColor = False
        '
        'Remove_user_btn
        '
        Me.Remove_user_btn.BackColor = System.Drawing.Color.Beige
        Me.Remove_user_btn.Location = New System.Drawing.Point(465, 317)
        Me.Remove_user_btn.Name = "Remove_user_btn"
        Me.Remove_user_btn.Size = New System.Drawing.Size(202, 23)
        Me.Remove_user_btn.TabIndex = 9
        Me.Remove_user_btn.Text = "Remove User"
        Me.Remove_user_btn.UseVisualStyleBackColor = False
        '
        'Exit_btn
        '
        Me.Exit_btn.BackColor = System.Drawing.Color.Beige
        Me.Exit_btn.Location = New System.Drawing.Point(465, 363)
        Me.Exit_btn.Name = "Exit_btn"
        Me.Exit_btn.Size = New System.Drawing.Size(202, 23)
        Me.Exit_btn.TabIndex = 10
        Me.Exit_btn.Text = "Exit"
        Me.Exit_btn.UseVisualStyleBackColor = False
        '
        'Registerlink
        '
        Me.Registerlink.AutoSize = True
        Me.Registerlink.LinkColor = System.Drawing.Color.Black
        Me.Registerlink.Location = New System.Drawing.Point(612, 465)
        Me.Registerlink.Name = "Registerlink"
        Me.Registerlink.Size = New System.Drawing.Size(127, 13)
        Me.Registerlink.TabIndex = 11
        Me.Registerlink.TabStop = True
        Me.Registerlink.Text = "New User...Register Now"
        '
        'Form_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(749, 487)
        Me.Controls.Add(Me.Registerlink)
        Me.Controls.Add(Me.Exit_btn)
        Me.Controls.Add(Me.Remove_user_btn)
        Me.Controls.Add(Me.Login_btn)
        Me.Controls.Add(Me.ShowPasswordCheckBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Password_txt)
        Me.Controls.Add(Me.username_txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents username_txt As TextBox
    Friend WithEvents Password_txt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ShowPasswordCheckBox As CheckBox
    Friend WithEvents Login_btn As Button
    Friend WithEvents Remove_user_btn As Button
    Friend WithEvents Exit_btn As Button
    Friend WithEvents Registerlink As LinkLabel
End Class
