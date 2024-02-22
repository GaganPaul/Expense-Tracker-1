<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Budget_btn = New System.Windows.Forms.Button()
        Me.Expense_btn = New System.Windows.Forms.Button()
        Me.Report_btn = New System.Windows.Forms.Button()
        Me.Settings_btn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Logout_label = New System.Windows.Forms.Label()
        Me.Login_info2 = New System.Windows.Forms.Label()
        Me.Login_info1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 66)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(45, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Expense Tracker"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Budget_btn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Expense_btn, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Report_btn, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Settings_btn, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(347, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(437, 66)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Budget_btn
        '
        Me.Budget_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Budget_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Budget_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Budget_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Budget_btn.Location = New System.Drawing.Point(3, 3)
        Me.Budget_btn.Name = "Budget_btn"
        Me.Budget_btn.Size = New System.Drawing.Size(103, 60)
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
        Me.Expense_btn.Location = New System.Drawing.Point(112, 3)
        Me.Expense_btn.Name = "Expense_btn"
        Me.Expense_btn.Size = New System.Drawing.Size(103, 60)
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
        Me.Report_btn.Location = New System.Drawing.Point(221, 3)
        Me.Report_btn.Name = "Report_btn"
        Me.Report_btn.Size = New System.Drawing.Size(103, 60)
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
        Me.Settings_btn.Location = New System.Drawing.Point(330, 3)
        Me.Settings_btn.Name = "Settings_btn"
        Me.Settings_btn.Size = New System.Drawing.Size(104, 60)
        Me.Settings_btn.TabIndex = 5
        Me.Settings_btn.Text = "Settings"
        Me.Settings_btn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel2.Controls.Add(Me.Logout_label)
        Me.Panel2.Controls.Add(Me.Login_info2)
        Me.Panel2.Controls.Add(Me.Login_info1)
        Me.Panel2.Location = New System.Drawing.Point(0, 354)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(787, 66)
        Me.Panel2.TabIndex = 1
        '
        'Logout_label
        '
        Me.Logout_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Logout_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logout_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Logout_label.Location = New System.Drawing.Point(712, 15)
        Me.Logout_label.Name = "Logout_label"
        Me.Logout_label.Size = New System.Drawing.Size(62, 32)
        Me.Logout_label.TabIndex = 4
        Me.Logout_label.Text = "Exit"
        '
        'Login_info2
        '
        Me.Login_info2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_info2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login_info2.Location = New System.Drawing.Point(270, 15)
        Me.Login_info2.Name = "Login_info2"
        Me.Login_info2.Size = New System.Drawing.Size(330, 32)
        Me.Login_info2.TabIndex = 5
        Me.Login_info2.Text = "Date Time"
        '
        'Login_info1
        '
        Me.Login_info1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_info1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login_info1.Location = New System.Drawing.Point(28, 15)
        Me.Login_info1.Name = "Login_info1"
        Me.Login_info1.Size = New System.Drawing.Size(236, 32)
        Me.Login_info1.TabIndex = 4
        Me.Login_info1.Text = "User"
        '
        'Timer1
        '
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(786, 420)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Mainform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mainform"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
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
End Class
