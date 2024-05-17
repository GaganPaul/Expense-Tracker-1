Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form_settings
    Public con As New SqlConnection("Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False")
    Private Sub Back1_btn_Click(sender As Object, e As EventArgs) Handles Back1_btn.Click
        Me.Hide()
        Mainform.Show()
    End Sub

    Private Sub Category_btn_Click(sender As Object, e As EventArgs) Handles Category_btn.Click
        Me.Hide()
        Form_categories.Show()
    End Sub

    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles Logout_btn.Click
        Me.Hide()
        Form_login.Show()
    End Sub

    Private Sub Remove_user_btn_Click(sender As Object, e As EventArgs) Handles Remove_user_btn.Click

        Dim usernameToRemove As String = InputBox("Enter the username to remove:", "Remove User")


        RemoveUser(usernameToRemove)
    End Sub

    Private Sub RemoveUser(username As String)
        Try

            Dim password As String = InputBox("Enter your password to confirm deletion of the user.", "Confirm Deletion")


            If AuthenticateUser(username, password) Then

                con.Open()


                DeleteRelatedData(username)


                Dim sql As String = "DELETE FROM [users] WHERE Username = @Username"
                Using cmd As New SqlCommand(sql, con)

                    cmd.Parameters.AddWithValue("@Username", username)


                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()


                    If rowsAffected > 0 Then
                        MessageBox.Show("User removed successfully")
                        Me.Close()
                        Form_login.Show()
                    Else
                        MessageBox.Show("User not found or could not be removed")
                    End If
                End Using
            Else
                MessageBox.Show("Incorrect password. User deletion cancelled.")
            End If
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try
    End Sub

    Private Sub DeleteRelatedData(username As String)

        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"


        Using con As New SqlConnection(connectionString)
            Try

                con.Open()


                Dim sqlExpense As String = "DELETE FROM Expense WHERE UserID = (SELECT UserID FROM [users] WHERE Username = @Username)"
                Using cmdExpense As New SqlCommand(sqlExpense, con)
                    cmdExpense.Parameters.AddWithValue("@Username", username)
                    cmdExpense.ExecuteNonQuery()
                End Using


                Dim sqlBudget As String = "DELETE FROM Budget WHERE UserID = (SELECT UserID FROM [users] WHERE Username = @Username)"
                Using cmdBudget As New SqlCommand(sqlBudget, con)
                    cmdBudget.Parameters.AddWithValue("@Username", username)
                    cmdBudget.ExecuteNonQuery()
                End Using


                Dim sqlGoals As String = "DELETE FROM FinancialGoals WHERE UserID = (SELECT UserID FROM [users] WHERE Username = @Username)"
                Using cmdGoals As New SqlCommand(sqlGoals, con)
                    cmdGoals.Parameters.AddWithValue("@Username", username)
                    cmdGoals.ExecuteNonQuery()
                End Using


                Dim sqlExpenseToGoal As String = "DELETE FROM ExpenseToGoal WHERE ExpenseID IN (SELECT ExpenseID FROM Expense WHERE UserID = (SELECT UserID FROM [users] WHERE Username = @Username))"
                Using cmdExpenseToGoal As New SqlCommand(sqlExpenseToGoal, con)
                    cmdExpenseToGoal.Parameters.AddWithValue("@Username", username)
                    cmdExpenseToGoal.ExecuteNonQuery()
                End Using



            Catch ex As Exception

                MessageBox.Show("Error deleting related data: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Dim authenticated As Boolean = False
        Try

            con.Open()


            Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(sql, con)
                ' Replace the parameters with the actual values
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)


                Dim reader As SqlDataReader = cmd.ExecuteReader()


                authenticated = reader.HasRows
            End Using
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try

        Return authenticated
    End Function


    Private Sub Financial_goals_btn_Click(sender As Object, e As EventArgs) Handles Financial_goals_btn.Click
        Me.Hide()
        Form_goals.Show()
    End Sub

    Private Sub Form_settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class