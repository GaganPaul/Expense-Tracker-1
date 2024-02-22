<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_budget
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Back_label = New System.Windows.Forms.Label()
        Me.txtBudgetAmount = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RemoveBudget_btn = New System.Windows.Forms.Button()
        Me.Btn_edit = New System.Windows.Forms.Button()
        Me.View_budget_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 45)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(160, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Budget"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel2.Controls.Add(Me.Back_label)
        Me.Panel2.Location = New System.Drawing.Point(0, 327)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(421, 49)
        Me.Panel2.TabIndex = 1
        '
        'Back_label
        '
        Me.Back_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Back_label.Font = New System.Drawing.Font("Microsoft Tai Le", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Back_label.Location = New System.Drawing.Point(3, 0)
        Me.Back_label.Name = "Back_label"
        Me.Back_label.Size = New System.Drawing.Size(80, 36)
        Me.Back_label.TabIndex = 5
        Me.Back_label.Text = "<----"
        '
        'txtBudgetAmount
        '
        Me.txtBudgetAmount.BackColor = System.Drawing.Color.Beige
        Me.txtBudgetAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBudgetAmount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBudgetAmount.Location = New System.Drawing.Point(94, 152)
        Me.txtBudgetAmount.Multiline = True
        Me.txtBudgetAmount.Name = "txtBudgetAmount"
        Me.txtBudgetAmount.Size = New System.Drawing.Size(219, 43)
        Me.txtBudgetAmount.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Beige
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnSave.Location = New System.Drawing.Point(94, 228)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 30)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cboCategory
        '
        Me.cboCategory.BackColor = System.Drawing.Color.Beige
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(94, 89)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(219, 21)
        Me.cboCategory.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(91, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Category"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(91, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Enter The Budget"
        '
        'RemoveBudget_btn
        '
        Me.RemoveBudget_btn.BackColor = System.Drawing.Color.Beige
        Me.RemoveBudget_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RemoveBudget_btn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RemoveBudget_btn.Location = New System.Drawing.Point(94, 276)
        Me.RemoveBudget_btn.Name = "RemoveBudget_btn"
        Me.RemoveBudget_btn.Size = New System.Drawing.Size(98, 30)
        Me.RemoveBudget_btn.TabIndex = 7
        Me.RemoveBudget_btn.Text = "Remove Budget"
        Me.RemoveBudget_btn.UseVisualStyleBackColor = False
        '
        'Btn_edit
        '
        Me.Btn_edit.BackColor = System.Drawing.Color.Beige
        Me.Btn_edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_edit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Btn_edit.Location = New System.Drawing.Point(215, 228)
        Me.Btn_edit.Name = "Btn_edit"
        Me.Btn_edit.Size = New System.Drawing.Size(98, 30)
        Me.Btn_edit.TabIndex = 8
        Me.Btn_edit.Text = "Edit Budget"
        Me.Btn_edit.UseVisualStyleBackColor = False
        '
        'View_budget_btn
        '
        Me.View_budget_btn.BackColor = System.Drawing.Color.Beige
        Me.View_budget_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.View_budget_btn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.View_budget_btn.Location = New System.Drawing.Point(215, 276)
        Me.View_budget_btn.Name = "View_budget_btn"
        Me.View_budget_btn.Size = New System.Drawing.Size(98, 30)
        Me.View_budget_btn.TabIndex = 9
        Me.View_budget_btn.Text = "View Budget"
        Me.View_budget_btn.UseVisualStyleBackColor = False
        '
        'Form_budget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(417, 374)
        Me.Controls.Add(Me.View_budget_btn)
        Me.Controls.Add(Me.Btn_edit)
        Me.Controls.Add(Me.RemoveBudget_btn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtBudgetAmount)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_budget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_budget"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Back_label As Label
    Friend WithEvents txtBudgetAmount As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RemoveBudget_btn As Button
    Friend WithEvents Btn_edit As Button
    Friend WithEvents View_budget_btn As Button
End Class
