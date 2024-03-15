Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form_login
    Public con As New SqlConnection("Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False")

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click
        PerformLogin()
    End Sub
    Private Sub PerformLogin()
        Try
            If String.IsNullOrWhiteSpace(username_txt.Text) OrElse String.IsNullOrWhiteSpace(Password_txt.Text) Then
                MessageBox.Show("Please enter username and password.")
                Return
            End If

            con.Open()

            Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Username", username_txt.Text)
                cmd.Parameters.AddWithValue("@Password", Password_txt.Text)


                Dim reader As SqlDataReader = cmd.ExecuteReader()


                If reader.HasRows Then

                    MessageBox.Show("Login successful")
                    Me.Hide()
                    Mainform.Show()
                    Mainform.Login_info1.Text = "User: " & username_txt.Text
                    username_txt.Text = ""
                    Password_txt.Text = ""
                Else

                    MessageBox.Show("Invalid username or password")
                End If


                reader.Close()
            End Using
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        Application.Exit()
    End Sub

    Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged

        If ShowPasswordCheckBox.Checked Then
            Password_txt.PasswordChar = ControlChars.NullChar
        Else
            Password_txt.PasswordChar = "*"
        End If
    End Sub

    Private Sub Registerlink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Registerlink.LinkClicked
        Dim registrationForm As New Form_register()
        Me.Hide()
        username_txt.Text = ""
        Password_txt.Text = ""
        registrationForm.Show()
    End Sub
    Private Sub Password_txt_TextChanged(sender As Object, e As EventArgs) Handles Password_txt.TextChanged
        Password_txt.PasswordChar = "*"
    End Sub
End Class
