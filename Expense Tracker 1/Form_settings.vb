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
        ' Get the username from the user (you may use a TextBox or another input method)
        Dim usernameToRemove As String = InputBox("Enter the username to remove:", "Remove User")

        ' Call the RemoveUser function
        RemoveUser(usernameToRemove)
    End Sub
    Private Sub RemoveUser(username As String)
        Try
            ' Open the database connection
            con.Open()

            ' Execute SQL command to delete user by username
            Dim sql As String = "DELETE FROM users WHERE Username = @Username"
            Using cmd As New SqlCommand(sql, con)
                ' Replace the parameter with the actual value
                cmd.Parameters.AddWithValue("@Username", username)

                ' Execute the command
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                ' Check if any rows were affected to determine if the user was deleted
                If rowsAffected > 0 Then
                    MessageBox.Show("User removed successfully")
                Else
                    MessageBox.Show("User not found or could not be removed")
                End If
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during database operations
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection in the finally block to ensure it's always closed
            con.Close()
        End Try
    End Sub

    Private Sub Financial_goals_btn_Click(sender As Object, e As EventArgs) Handles Financial_goals_btn.Click
        Me.Hide()
        Form_goals.Show()
    End Sub
End Class