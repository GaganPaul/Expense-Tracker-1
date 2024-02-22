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
            ' Validate input: Check if both username and password are provided
            If String.IsNullOrWhiteSpace(Register_username.Text) OrElse String.IsNullOrWhiteSpace(Register_password.Text) Then
                MessageBox.Show("Please enter username and password.")
                Return ' Exit the method without proceeding to database operations
            End If
            ' Open the database connection
            con.Open()

            ' Execute SQL command to insert new user registration
            Dim sql As String = "INSERT INTO users (Username, Password) VALUES (@Username, @Password)"
            Using cmd As New SqlCommand(sql, con)
                ' Replace these parameters with actual values or retrieve them from controls
                cmd.Parameters.AddWithValue("@Username", Register_username.Text)
                cmd.Parameters.AddWithValue("@Password", Register_password.Text)

                ' Execute the command
                cmd.ExecuteNonQuery()

                ' Display registration success message
                MessageBox.Show("Registration successful")
                Me.Hide()
                Form_login.Show()
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during database operations
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection in the finally block to ensure it's always closed
            con.Close()
        End Try
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles Back_btn.Click
        Me.Hide()
        Form_login.Show()
    End Sub

    Private Sub Register_password_TextChanged(sender As Object, e As EventArgs) Handles Register_password.TextChanged
        Register_password.PasswordChar = "*"
    End Sub

    Private Sub ShowPasswordCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox2.CheckedChanged
        ' Toggle the PasswordChar based on the CheckBox state
        If ShowPasswordCheckBox2.Checked Then
            Register_password.PasswordChar = ControlChars.NullChar ' Show characters
        Else
            Register_password.PasswordChar = "*" ' Hide characters
        End If
    End Sub

    Private Sub Form_register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class