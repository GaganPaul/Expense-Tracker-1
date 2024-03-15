Imports System.Data.SqlClient
Imports System.Text

Public Class Form_categories
    Public con As New SqlConnection("Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False")

    Private Sub Save2_btn_Click(sender As Object, e As EventArgs) Handles Save2_btn.Click

        Dim categoryName As String = Enter_categories_txt.Text.Trim()
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"


        If categoryName <> "" Then

            If IsCategoryExists(connectionString, categoryName) Then
                MessageBox.Show("Category already exists. Please enter a different category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
            Dim userID As Integer = GetUserIDByUsername(connectionString, username)

            Try
                Using con As New SqlConnection(connectionString)
                    con.Open()
                    Dim query As String = "INSERT INTO Category (CategoryName, IsPredefined, CreatedByUserID) VALUES (@CategoryName, @IsPredefined, @CreatedByUserID); SELECT @@IDENTITY;"
                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName)
                        cmd.Parameters.AddWithValue("@IsPredefined", 0)
                        cmd.Parameters.AddWithValue("@CreatedByUserID", userID)
                        Dim newCategoryID As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        MessageBox.Show($"Category '{categoryName}' added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please enter a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Mainform.Show()
    End Sub

    Private Sub Remove_btn_Click(sender As Object, e As EventArgs) Handles Remove_btn.Click
        Dim categoryToRemove As String = InputBox("Enter the category to remove:", "Remove Category")
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        If categoryToRemove <> "" Then
            Try
                Using con As New SqlConnection(connectionString)
                    con.Open()
                    Dim query As String = "DELETE FROM Category WHERE CategoryName = @CategoryName AND IsPredefined = 0 AND CreatedByUserID = @CreatedByUserID;"
                    Using cmd As New SqlCommand(query, con)
                        Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
                        Dim userID As Integer = GetUserIDByUsername(connectionString, username)
                        cmd.Parameters.AddWithValue("@CategoryName", categoryToRemove)
                        cmd.Parameters.AddWithValue("@CreatedByUserID", userID)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show($"Category '{categoryToRemove}' removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show($"Category '{categoryToRemove}' not found or could not be removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please enter a category to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function GetUserIDByUsername(connectionString As String, username As String) As Integer
        Dim userID As Integer = 0

        Try
            Using con As New SqlConnection(connectionString)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim query As String = "SELECT UserID FROM users WHERE Username = @Username"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Username", username)
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        userID = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return userID
    End Function
    Private Function IsCategoryExists(ByVal connectionString As String, ByVal categoryName As String) As Boolean
        Dim isExists As Boolean = False

        Try
            Using con As New SqlConnection(connectionString)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim query As String = "SELECT COUNT(*) FROM Category WHERE CategoryName = @CategoryName"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    isExists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error checking category existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return isExists
    End Function

    Private Sub View_categories_btn_Click(sender As Object, e As EventArgs) Handles View_categories_btn.Click
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        Try
            Dim customCategories As String = GetCustomCategories(connectionString)
            If customCategories <> "" Then
                MessageBox.Show("Custom Categories:" & vbCrLf & customCategories, "Custom Categories", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No custom categories found.", "Custom Categories", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCustomCategories(connectionString As String) As String
        Dim customCategories As New StringBuilder()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT CategoryName FROM Category WHERE IsPredefined = 0"

                Using cmd As New SqlCommand(query, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim categoryName As String = Convert.ToString(reader("CategoryName"))
                        customCategories.AppendLine(categoryName)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return customCategories.ToString()
    End Function


End Class

