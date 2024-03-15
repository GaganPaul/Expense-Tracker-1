<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_settings))
        Me.Category_btn = New System.Windows.Forms.Button()
        Me.Back1_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Logout_btn = New System.Windows.Forms.Button()
        Me.Remove_user_btn = New System.Windows.Forms.Button()
        Me.Financial_goals_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Category_btn
        '
        Me.Category_btn.BackColor = System.Drawing.Color.Beige
        Me.Category_btn.Location = New System.Drawing.Point(87, 64)
        Me.Category_btn.Name = "Category_btn"
        Me.Category_btn.Size = New System.Drawing.Size(104, 23)
        Me.Category_btn.TabIndex = 0
        Me.Category_btn.Text = "Custom Categories"
        Me.Category_btn.UseVisualStyleBackColor = False
        '
        'Back1_btn
        '
        Me.Back1_btn.BackColor = System.Drawing.Color.Beige
        Me.Back1_btn.Location = New System.Drawing.Point(87, 227)
        Me.Back1_btn.Name = "Back1_btn"
        Me.Back1_btn.Size = New System.Drawing.Size(104, 23)
        Me.Back1_btn.TabIndex = 1
        Me.Back1_btn.Text = "Back"
        Me.Back1_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(81, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Settings"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(282, 51)
        Me.Panel1.TabIndex = 2
        '
        'Logout_btn
        '
        Me.Logout_btn.BackColor = System.Drawing.Color.Beige
        Me.Logout_btn.Location = New System.Drawing.Point(87, 185)
        Me.Logout_btn.Name = "Logout_btn"
        Me.Logout_btn.Size = New System.Drawing.Size(104, 23)
        Me.Logout_btn.TabIndex = 3
        Me.Logout_btn.Text = "Logout"
        Me.Logout_btn.UseVisualStyleBackColor = False
        '
        'Remove_user_btn
        '
        Me.Remove_user_btn.BackColor = System.Drawing.Color.Beige
        Me.Remove_user_btn.Location = New System.Drawing.Point(87, 143)
        Me.Remove_user_btn.Name = "Remove_user_btn"
        Me.Remove_user_btn.Size = New System.Drawing.Size(104, 23)
        Me.Remove_user_btn.TabIndex = 10
        Me.Remove_user_btn.Text = "Remove User"
        Me.Remove_user_btn.UseVisualStyleBackColor = False
        '
        'Financial_goals_btn
        '
        Me.Financial_goals_btn.BackColor = System.Drawing.Color.Beige
        Me.Financial_goals_btn.Location = New System.Drawing.Point(87, 103)
        Me.Financial_goals_btn.Name = "Financial_goals_btn"
        Me.Financial_goals_btn.Size = New System.Drawing.Size(104, 23)
        Me.Financial_goals_btn.TabIndex = 11
        Me.Financial_goals_btn.Text = "Financial Goals"
        Me.Financial_goals_btn.UseVisualStyleBackColor = False
        '
        'Form_settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(282, 262)
        Me.Controls.Add(Me.Financial_goals_btn)
        Me.Controls.Add(Me.Remove_user_btn)
        Me.Controls.Add(Me.Logout_btn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Back1_btn)
        Me.Controls.Add(Me.Category_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Category_btn As Button
    Friend WithEvents Back1_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Logout_btn As Button
    Friend WithEvents Remove_user_btn As Button
    Friend WithEvents Financial_goals_btn As Button
End Class
