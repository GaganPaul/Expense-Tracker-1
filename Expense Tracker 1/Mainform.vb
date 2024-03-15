Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Mainform
    Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Login_info2.Text = Date.Now.ToString("dd-MM-yyyy")
        Login_info_3.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub Budget_btn_Click(sender As Object, e As EventArgs) Handles Budget_btn.Click
        Me.Hide()
        Form_budget.Show()
    End Sub

    Private Sub Settings_btn_Click(sender As Object, e As EventArgs) Handles Settings_btn.Click
        Me.Hide()
        Form_settings.Show()
    End Sub

    Private Sub Logout_label_Click(sender As Object, e As EventArgs) Handles Logout_label.Click
        Application.Exit()
    End Sub

    Private Sub Expense_btn_Click(sender As Object, e As EventArgs) Handles Expense_btn.Click
        Me.Hide()
        Form_expense.Show()
    End Sub

    Private Sub Report_btn_Click(sender As Object, e As EventArgs) Handles Report_btn.Click
        Me.Hide()
        Form_report.Show()
    End Sub

    Private Sub Custom_PictureBox_Click(sender As Object, e As EventArgs) Handles Custom_PictureBox.Click
        Me.Hide()
        Form_categories.Show()
    End Sub

    Private Sub Financial_PictureBox_Click(sender As Object, e As EventArgs) Handles Financial_PictureBox.Click
        Me.Hide()
        Form_goals.Show()
    End Sub
    Private Sub Year_Overview_PictureBox_Click(sender As Object, e As EventArgs) Handles Year_Overview_PictureBox.Click
        Me.Hide()
        Try
            Dim yearlyOverviewForm As New YearlyOverviewForm()
            yearlyOverviewForm.Show()


            yearlyOverviewForm.GenerateYearlyOverviewGraph()
        Catch ex As Exception
            MessageBox.Show($"Error displaying yearly overview: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class