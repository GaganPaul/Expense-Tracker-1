<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_expense
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
        Me.Remove_expense_btn = New System.Windows.Forms.Button()
        Me.Edit_expense_btn = New System.Windows.Forms.Button()
        Me.Save_expense_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Back2_label = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cbo1Category = New System.Windows.Forms.ComboBox()
        Me.Txt_ExpenseAmount = New System.Windows.Forms.TextBox()
        Me.View_expense_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Text_description = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Remove_expense_btn
        '
        Me.Remove_expense_btn.BackColor = System.Drawing.Color.Beige
        Me.Remove_expense_btn.Location = New System.Drawing.Point(40, 304)
        Me.Remove_expense_btn.Name = "Remove_expense_btn"
        Me.Remove_expense_btn.Size = New System.Drawing.Size(137, 23)
        Me.Remove_expense_btn.TabIndex = 8
        Me.Remove_expense_btn.Text = "Remove Expenses"
        Me.Remove_expense_btn.UseVisualStyleBackColor = False
        '
        'Edit_expense_btn
        '
        Me.Edit_expense_btn.BackColor = System.Drawing.Color.Beige
        Me.Edit_expense_btn.Location = New System.Drawing.Point(245, 255)
        Me.Edit_expense_btn.Name = "Edit_expense_btn"
        Me.Edit_expense_btn.Size = New System.Drawing.Size(137, 23)
        Me.Edit_expense_btn.TabIndex = 7
        Me.Edit_expense_btn.Text = "Edit Expense"
        Me.Edit_expense_btn.UseVisualStyleBackColor = False
        '
        'Save_expense_btn
        '
        Me.Save_expense_btn.BackColor = System.Drawing.Color.Beige
        Me.Save_expense_btn.Location = New System.Drawing.Point(40, 255)
        Me.Save_expense_btn.Name = "Save_expense_btn"
        Me.Save_expense_btn.Size = New System.Drawing.Size(137, 23)
        Me.Save_expense_btn.TabIndex = 6
        Me.Save_expense_btn.Text = "Save"
        Me.Save_expense_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(154, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Expenses"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 49)
        Me.Panel1.TabIndex = 9
        '
        'Back2_label
        '
        Me.Back2_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Back2_label.Font = New System.Drawing.Font("Microsoft Tai Le", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back2_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Back2_label.Location = New System.Drawing.Point(3, 3)
        Me.Back2_label.Name = "Back2_label"
        Me.Back2_label.Size = New System.Drawing.Size(80, 36)
        Me.Back2_label.TabIndex = 5
        Me.Back2_label.Text = "<----"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel2.Controls.Add(Me.Back2_label)
        Me.Panel2.Location = New System.Drawing.Point(0, 345)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(421, 43)
        Me.Panel2.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(163, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Enter Amount"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(156, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 18)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select Category"
        '
        'Cbo1Category
        '
        Me.Cbo1Category.BackColor = System.Drawing.Color.Beige
        Me.Cbo1Category.FormattingEnabled = True
        Me.Cbo1Category.Location = New System.Drawing.Point(90, 81)
        Me.Cbo1Category.Name = "Cbo1Category"
        Me.Cbo1Category.Size = New System.Drawing.Size(233, 21)
        Me.Cbo1Category.TabIndex = 12
        '
        'Txt_ExpenseAmount
        '
        Me.Txt_ExpenseAmount.BackColor = System.Drawing.Color.Beige
        Me.Txt_ExpenseAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ExpenseAmount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txt_ExpenseAmount.Location = New System.Drawing.Point(90, 135)
        Me.Txt_ExpenseAmount.Multiline = True
        Me.Txt_ExpenseAmount.Name = "Txt_ExpenseAmount"
        Me.Txt_ExpenseAmount.Size = New System.Drawing.Size(233, 23)
        Me.Txt_ExpenseAmount.TabIndex = 11
        '
        'View_expense_btn
        '
        Me.View_expense_btn.BackColor = System.Drawing.Color.Beige
        Me.View_expense_btn.Location = New System.Drawing.Point(245, 304)
        Me.View_expense_btn.Name = "View_expense_btn"
        Me.View_expense_btn.Size = New System.Drawing.Size(137, 23)
        Me.View_expense_btn.TabIndex = 15
        Me.View_expense_btn.Text = "View Expenses"
        Me.View_expense_btn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(172, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Description"
        '
        'Text_description
        '
        Me.Text_description.BackColor = System.Drawing.Color.Beige
        Me.Text_description.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_description.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text_description.Location = New System.Drawing.Point(90, 191)
        Me.Text_description.Multiline = True
        Me.Text_description.Name = "Text_description"
        Me.Text_description.Size = New System.Drawing.Size(233, 46)
        Me.Text_description.TabIndex = 16
        '
        'Form_expense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(418, 388)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Text_description)
        Me.Controls.Add(Me.View_expense_btn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cbo1Category)
        Me.Controls.Add(Me.Txt_ExpenseAmount)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Remove_expense_btn)
        Me.Controls.Add(Me.Edit_expense_btn)
        Me.Controls.Add(Me.Save_expense_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_expense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_expense"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Remove_expense_btn As Button
    Friend WithEvents Edit_expense_btn As Button
    Friend WithEvents Save_expense_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Back2_label As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Cbo1Category As ComboBox
    Friend WithEvents Txt_ExpenseAmount As TextBox
    Friend WithEvents View_expense_btn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Text_description As TextBox
End Class
