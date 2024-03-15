Imports System.Data
Imports System.Data.SqlClient
Public Class Form_register
    Public con As New SqlConnection("Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False")
    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles Register_btn.Click
        PerformRegistration()
        Me.Hide()
        Form_login.Show()
    End Sub
    Private Sub PerformRegistration()
        Try

            If String.IsNullOrWhiteSpace(Register_username.Text) OrElse String.IsNullOrWhiteSpace(Register_password.Text) Then
                MessageBox.Show("Please enter username and password.")
                Return
            End If

            con.Open()

            Dim sql As String = "INSERT INTO users (Username, Password) VALUES (@Username, @Password)"
            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@Username", Register_username.Text)
                cmd.Parameters.AddWithValue("@Password", Register_password.Text)


                cmd.ExecuteNonQuery()


                MessageBox.Show("Registration successful")
                Me.Hide()
                Form_login.Show()
            End Using
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles Back_btn.Click
        Me.Close()
        Form_login.Show()
    End Sub

    Private Sub Register_password_TextChanged(sender As Object, e As EventArgs) Handles Register_password.TextChanged
        Register_password.PasswordChar = "*"
    End Sub

    Private Sub ShowPasswordCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox2.CheckedChanged

        If ShowPasswordCheckBox2.Checked Then
            Register_password.PasswordChar = ControlChars.NullChar
        Else
            Register_password.PasswordChar = "*"
        End If
    End Sub


End Class