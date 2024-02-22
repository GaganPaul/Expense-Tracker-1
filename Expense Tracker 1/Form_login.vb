Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form_login
    Public con As New SqlConnection("Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False")

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click
        ' Call a method to handle login function
        PerformLogin()
    End Sub
    Private Sub PerformLogin()
        Try
            ' Open the database connection
            con.Open()

            ' Execute SQL command
            Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Username", username_txt.Text)
                cmd.Parameters.AddWithValue("@Password", Password_txt.Text)

                ' Execute the command
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                ' Check if there is a row with matching username and password
                If reader.HasRows Then
                    ' User is authenticated
                    MessageBox.Show("Login successful")
                    Me.Hide() ' To hide the login form
                    Mainform.Show() ' To link the main form to the login form
                    Mainform.Login_info1.Text = "User: " & username_txt.Text
                Else
                    ' User authentication failed
                    MessageBox.Show("Invalid username or password")
                End If

                ' Close the SqlDataReader
                reader.Close()
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during database operations
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection in the finally block to ensure it's always closed
            con.Close()
        End Try
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        Application.Exit()
    End Sub

    Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged
        ' Toggle the PasswordChar based on the CheckBox state
        If ShowPasswordCheckBox.Checked Then
            Password_txt.PasswordChar = ControlChars.NullChar ' Show characters
        Else
            Password_txt.PasswordChar = "*" ' Hide characters
        End If
    End Sub

    Private Sub Registerlink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Registerlink.LinkClicked
        Dim registrationForm As New Form_register()
        Me.Hide()
        registrationForm.Show()
    End Sub
    Private Sub Password_txt_TextChanged(sender As Object, e As EventArgs) Handles Password_txt.TextChanged
        Password_txt.PasswordChar = "*"
    End Sub

    Private Sub Form_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
