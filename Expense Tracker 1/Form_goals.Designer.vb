<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_goals
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Add_goal_btn = New System.Windows.Forms.Button()
        Me.Remove_goal_btn = New System.Windows.Forms.Button()
        Me.Edit_goal_btn = New System.Windows.Forms.Button()
        Me.Back3_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-3, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 62)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(119, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 43)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Financial Goals"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-3, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(440, 236)
        Me.DataGridView1.TabIndex = 5
        '
        'Add_goal_btn
        '
        Me.Add_goal_btn.BackColor = System.Drawing.Color.Beige
        Me.Add_goal_btn.Location = New System.Drawing.Point(25, 303)
        Me.Add_goal_btn.Name = "Add_goal_btn"
        Me.Add_goal_btn.Size = New System.Drawing.Size(75, 23)
        Me.Add_goal_btn.TabIndex = 7
        Me.Add_goal_btn.Text = "Add Goal"
        Me.Add_goal_btn.UseVisualStyleBackColor = False
        '
        'Remove_goal_btn
        '
        Me.Remove_goal_btn.BackColor = System.Drawing.Color.Beige
        Me.Remove_goal_btn.Location = New System.Drawing.Point(242, 303)
        Me.Remove_goal_btn.Name = "Remove_goal_btn"
        Me.Remove_goal_btn.Size = New System.Drawing.Size(75, 23)
        Me.Remove_goal_btn.TabIndex = 8
        Me.Remove_goal_btn.Text = "Remove Goal"
        Me.Remove_goal_btn.UseVisualStyleBackColor = False
        '
        'Edit_goal_btn
        '
        Me.Edit_goal_btn.BackColor = System.Drawing.Color.Beige
        Me.Edit_goal_btn.Location = New System.Drawing.Point(142, 303)
        Me.Edit_goal_btn.Name = "Edit_goal_btn"
        Me.Edit_goal_btn.Size = New System.Drawing.Size(75, 23)
        Me.Edit_goal_btn.TabIndex = 9
        Me.Edit_goal_btn.Text = "Edit Goal"
        Me.Edit_goal_btn.UseVisualStyleBackColor = False
        '
        'Back3_btn
        '
        Me.Back3_btn.BackColor = System.Drawing.Color.Beige
        Me.Back3_btn.Location = New System.Drawing.Point(347, 303)
        Me.Back3_btn.Name = "Back3_btn"
        Me.Back3_btn.Size = New System.Drawing.Size(75, 23)
        Me.Back3_btn.TabIndex = 10
        Me.Back3_btn.Text = "Back"
        Me.Back3_btn.UseVisualStyleBackColor = False
        '
        'Form_goals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(434, 338)
        Me.Controls.Add(Me.Back3_btn)
        Me.Controls.Add(Me.Edit_goal_btn)
        Me.Controls.Add(Me.Remove_goal_btn)
        Me.Controls.Add(Me.Add_goal_btn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_goals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Financial Goals"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Add_goal_btn As Button
    Friend WithEvents Remove_goal_btn As Button
    Friend WithEvents Edit_goal_btn As Button
    Friend WithEvents Back3_btn As Button
End Class
