<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_categories
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_categories))
        Me.Enter_categories_txt = New System.Windows.Forms.TextBox()
        Me.Save2_btn = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Remove_btn = New System.Windows.Forms.Button()
        Me.View_categories_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Enter_categories_txt
        '
        Me.Enter_categories_txt.BackColor = System.Drawing.Color.Beige
        Me.Enter_categories_txt.Location = New System.Drawing.Point(41, 82)
        Me.Enter_categories_txt.Name = "Enter_categories_txt"
        Me.Enter_categories_txt.Size = New System.Drawing.Size(204, 20)
        Me.Enter_categories_txt.TabIndex = 0
        '
        'Save2_btn
        '
        Me.Save2_btn.BackColor = System.Drawing.Color.Beige
        Me.Save2_btn.Location = New System.Drawing.Point(74, 118)
        Me.Save2_btn.Name = "Save2_btn"
        Me.Save2_btn.Size = New System.Drawing.Size(137, 23)
        Me.Save2_btn.TabIndex = 1
        Me.Save2_btn.Text = "Save"
        Me.Save2_btn.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Beige
        Me.Button2.Location = New System.Drawing.Point(74, 245)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 45)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(69, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Categories"
        '
        'Remove_btn
        '
        Me.Remove_btn.BackColor = System.Drawing.Color.Beige
        Me.Remove_btn.Location = New System.Drawing.Point(74, 201)
        Me.Remove_btn.Name = "Remove_btn"
        Me.Remove_btn.Size = New System.Drawing.Size(137, 23)
        Me.Remove_btn.TabIndex = 4
        Me.Remove_btn.Text = "Remove Categories"
        Me.Remove_btn.UseVisualStyleBackColor = False
        '
        'View_categories_btn
        '
        Me.View_categories_btn.BackColor = System.Drawing.Color.Beige
        Me.View_categories_btn.Location = New System.Drawing.Point(74, 162)
        Me.View_categories_btn.Name = "View_categories_btn"
        Me.View_categories_btn.Size = New System.Drawing.Size(137, 23)
        Me.View_categories_btn.TabIndex = 5
        Me.View_categories_btn.Text = "View Categories"
        Me.View_categories_btn.UseVisualStyleBackColor = False
        '
        'Form_categories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(280, 280)
        Me.Controls.Add(Me.View_categories_btn)
        Me.Controls.Add(Me.Remove_btn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Save2_btn)
        Me.Controls.Add(Me.Enter_categories_txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_categories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Custom Categories"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Enter_categories_txt As TextBox
    Friend WithEvents Save2_btn As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Remove_btn As Button
    Friend WithEvents View_categories_btn As Button
End Class
