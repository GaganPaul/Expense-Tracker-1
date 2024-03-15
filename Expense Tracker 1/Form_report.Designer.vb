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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_report))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Daily_report_btn = New System.Windows.Forms.Button()
        Me.Monthly_report_btn = New System.Windows.Forms.Button()
        Me.Yearly_report_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Back_btn = New System.Windows.Forms.Button()
        Me.week_report_button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Print_btn = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.Chart1.Location = New System.Drawing.Point(-1, 41)
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
        Me.Chart1.Size = New System.Drawing.Size(920, 582)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Daily_report_btn
        '
        Me.Daily_report_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Daily_report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Daily_report_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Daily_report_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Daily_report_btn.Location = New System.Drawing.Point(3, 3)
        Me.Daily_report_btn.Name = "Daily_report_btn"
        Me.Daily_report_btn.Size = New System.Drawing.Size(147, 43)
        Me.Daily_report_btn.TabIndex = 1
        Me.Daily_report_btn.Text = "Daily Report"
        Me.Daily_report_btn.UseVisualStyleBackColor = False
        '
        'Monthly_report_btn
        '
        Me.Monthly_report_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Monthly_report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Monthly_report_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monthly_report_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Monthly_report_btn.Location = New System.Drawing.Point(309, 3)
        Me.Monthly_report_btn.Name = "Monthly_report_btn"
        Me.Monthly_report_btn.Size = New System.Drawing.Size(147, 43)
        Me.Monthly_report_btn.TabIndex = 2
        Me.Monthly_report_btn.Text = "Monthly Report"
        Me.Monthly_report_btn.UseVisualStyleBackColor = False
        '
        'Yearly_report_btn
        '
        Me.Yearly_report_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Yearly_report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Yearly_report_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Yearly_report_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Yearly_report_btn.Location = New System.Drawing.Point(462, 3)
        Me.Yearly_report_btn.Name = "Yearly_report_btn"
        Me.Yearly_report_btn.Size = New System.Drawing.Size(147, 43)
        Me.Yearly_report_btn.TabIndex = 3
        Me.Yearly_report_btn.Text = "Year's Overview"
        Me.Yearly_report_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reports"
        '
        'Back_btn
        '
        Me.Back_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Back_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Back_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Back_btn.Location = New System.Drawing.Point(768, 3)
        Me.Back_btn.Name = "Back_btn"
        Me.Back_btn.Size = New System.Drawing.Size(149, 43)
        Me.Back_btn.TabIndex = 5
        Me.Back_btn.Text = "Back"
        Me.Back_btn.UseVisualStyleBackColor = False
        '
        'week_report_button
        '
        Me.week_report_button.BackColor = System.Drawing.Color.DarkCyan
        Me.week_report_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.week_report_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.week_report_button.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.week_report_button.Location = New System.Drawing.Point(156, 3)
        Me.week_report_button.Name = "week_report_button"
        Me.week_report_button.Size = New System.Drawing.Size(147, 43)
        Me.week_report_button.TabIndex = 6
        Me.week_report_button.Text = "Weekly Report"
        Me.week_report_button.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(-4, 626)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 52)
        Me.Panel1.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Controls.Add(Me.Daily_report_btn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Monthly_report_btn, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.week_report_button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Yearly_report_btn, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Print_btn, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Back_btn, 5, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(920, 49)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(-4, -3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(938, 41)
        Me.Panel2.TabIndex = 9
        '
        'Print_btn
        '
        Me.Print_btn.BackColor = System.Drawing.Color.DarkCyan
        Me.Print_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Print_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Print_btn.Location = New System.Drawing.Point(615, 3)
        Me.Print_btn.Name = "Print_btn"
        Me.Print_btn.Size = New System.Drawing.Size(147, 43)
        Me.Print_btn.TabIndex = 7
        Me.Print_btn.Text = "Print Report"
        Me.Print_btn.UseVisualStyleBackColor = False
        '
        'Form_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(919, 676)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Chart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Daily_report_btn As Button
    Friend WithEvents Monthly_report_btn As Button
    Friend WithEvents Yearly_report_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Back_btn As Button
    Friend WithEvents week_report_button As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Print_btn As Button
End Class
