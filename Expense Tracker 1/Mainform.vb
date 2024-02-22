Public Class Mainform
    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Login_info2.Text = Date.Now.ToString("dd-MM-yyyy    hh:mm:ss tt")
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
End Class