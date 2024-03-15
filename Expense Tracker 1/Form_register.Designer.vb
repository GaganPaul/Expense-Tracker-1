<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_register))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Back_btn = New System.Windows.Forms.Button()
        Me.Register_btn = New System.Windows.Forms.Button()
        Me.ShowPasswordCheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Register_password = New System.Windows.Forms.TextBox()
        Me.Register_username = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(37, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(258, 46)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "The One Stop Solution For All        Your Budgeting Needs"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(86, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Expense Tracker"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 452)
        Me.Panel1.TabIndex = 1
        '
        'Back_btn
        '
        Me.Back_btn.BackColor = System.Drawing.Color.Beige
        Me.Back_btn.Location = New System.Drawing.Point(391, 336)
        Me.Back_btn.Name = "Back_btn"
        Me.Back_btn.Size = New System.Drawing.Size(202, 23)
        Me.Back_btn.TabIndex = 20
        Me.Back_btn.Text = "Back"
        Me.Back_btn.UseVisualStyleBackColor = False
        '
        'Register_btn
        '
        Me.Register_btn.BackColor = System.Drawing.Color.Beige
        Me.Register_btn.Location = New System.Drawing.Point(390, 279)
        Me.Register_btn.Name = "Register_btn"
        Me.Register_btn.Size = New System.Drawing.Size(202, 23)
        Me.Register_btn.TabIndex = 18
        Me.Register_btn.Text = "Register"
        Me.Register_btn.UseVisualStyleBackColor = False
        '
        'ShowPasswordCheckBox2
        '
        Me.ShowPasswordCheckBox2.AutoSize = True
        Me.ShowPasswordCheckBox2.BackColor = System.Drawing.Color.Beige
        Me.ShowPasswordCheckBox2.Location = New System.Drawing.Point(578, 201)
        Me.ShowPasswordCheckBox2.Name = "ShowPasswordCheckBox2"
        Me.ShowPasswordCheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.ShowPasswordCheckBox2.TabIndex = 17
        Me.ShowPasswordCheckBox2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(489, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Show Password"
        '
        'Register_password
        '
        Me.Register_password.BackColor = System.Drawing.Color.Beige
        Me.Register_password.Location = New System.Drawing.Point(391, 178)
        Me.Register_password.Name = "Register_password"
        Me.Register_password.Size = New System.Drawing.Size(199, 20)
        Me.Register_password.TabIndex = 15
        '
        'Register_username
        '
        Me.Register_username.BackColor = System.Drawing.Color.Beige
        Me.Register_username.Location = New System.Drawing.Point(391, 108)
        Me.Register_username.Name = "Register_username"
        Me.Register_username.Size = New System.Drawing.Size(199, 20)
        Me.Register_username.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(388, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(388, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "User Name"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(466, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Register"
        '
        'Form_register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 450)
        Me.Controls.Add(Me.Back_btn)
        Me.Controls.Add(Me.Register_btn)
        Me.Controls.Add(Me.ShowPasswordCheckBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Register_password)
        Me.Controls.Add(Me.Register_username)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_register"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Back_btn As Button
    Friend WithEvents Register_btn As Button
    Friend WithEvents ShowPasswordCheckBox2 As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Register_password As TextBox
    Friend WithEvents Register_username As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
