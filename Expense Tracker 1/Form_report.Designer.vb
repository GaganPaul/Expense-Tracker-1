<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_report
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Daily_report_btn = New System.Windows.Forms.Button()
        Me.Monthly_report_btn = New System.Windows.Forms.Button()
        Me.Yearly_report_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Back_btn = New System.Windows.Forms.Button()
        Me.week_report_button = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.AliceBlue
        Me.Chart1.BorderlineColor = System.Drawing.Color.AliceBlue
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.AliceBlue
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 44)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.YValuesPerPoint = 4
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(907, 576)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Daily_report_btn
        '
        Me.Daily_report_btn.Location = New System.Drawing.Point(10, 626)
        Me.Daily_report_btn.Name = "Daily_report_btn"
        Me.Daily_report_btn.Size = New System.Drawing.Size(168, 47)
        Me.Daily_report_btn.TabIndex = 1
        Me.Daily_report_btn.Text = "Daily Report"
        Me.Daily_report_btn.UseVisualStyleBackColor = True
        '
        'Monthly_report_btn
        '
        Me.Monthly_report_btn.Location = New System.Drawing.Point(372, 626)
        Me.Monthly_report_btn.Name = "Monthly_report_btn"
        Me.Monthly_report_btn.Size = New System.Drawing.Size(168, 47)
        Me.Monthly_report_btn.TabIndex = 2
        Me.Monthly_report_btn.Text = "Monthly Report"
        Me.Monthly_report_btn.UseVisualStyleBackColor = True
        '
        'Yearly_report_btn
        '
        Me.Yearly_report_btn.Location = New System.Drawing.Point(546, 626)
        Me.Yearly_report_btn.Name = "Yearly_report_btn"
        Me.Yearly_report_btn.Size = New System.Drawing.Size(168, 47)
        Me.Yearly_report_btn.TabIndex = 3
        Me.Yearly_report_btn.Text = "Year's Overview"
        Me.Yearly_report_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(25, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reports"
        '
        'Back_btn
        '
        Me.Back_btn.Location = New System.Drawing.Point(737, 626)
        Me.Back_btn.Name = "Back_btn"
        Me.Back_btn.Size = New System.Drawing.Size(168, 47)
        Me.Back_btn.TabIndex = 5
        Me.Back_btn.Text = "Back"
        Me.Back_btn.UseVisualStyleBackColor = True
        '
        'week_report_button
        '
        Me.week_report_button.Location = New System.Drawing.Point(184, 626)
        Me.week_report_button.Name = "week_report_button"
        Me.week_report_button.Size = New System.Drawing.Size(168, 47)
        Me.week_report_button.TabIndex = 6
        Me.week_report_button.Text = "Weekly Report"
        Me.week_report_button.UseVisualStyleBackColor = True
        '
        'Form_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(919, 676)
        Me.Controls.Add(Me.week_report_button)
        Me.Controls.Add(Me.Back_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Yearly_report_btn)
        Me.Controls.Add(Me.Monthly_report_btn)
        Me.Controls.Add(Me.Daily_report_btn)
        Me.Controls.Add(Me.Chart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_report"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Daily_report_btn As Button
    Friend WithEvents Monthly_report_btn As Button
    Friend WithEvents Yearly_report_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Back_btn As Button
    Friend WithEvents week_report_button As Button
End Class
