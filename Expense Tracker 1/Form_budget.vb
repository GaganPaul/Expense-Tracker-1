Imports System.Data.SqlClient
Imports System.Text

Public Class Form_budget
    Private connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
    Private Sub Back_label_Click(sender As Object, e As EventArgs) Handles Back_label.Click
        Me.Hide()
        Mainform.Show()
    End Sub

    Private Sub Form_budget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        PopulateCategories(connectionString)
    End Sub

    Private Sub PopulateCategories(connectionString As String)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
                Dim userID As Integer = GetUserIDByUsername(connectionString, username)

                ' Query to fetch both predefined and user-defined categories from Category and Budget tables
                Dim query As String = "SELECT c.CategoryID, c.CategoryName, CASE WHEN c.CategoryID IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11) THEN 1 ELSE 0 END AS IsPredefined
                                    FROM Category c
                                    LEFT JOIN Budget b ON c.CategoryID = b.CategoryID AND b.UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)

                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim categoryID As Integer = Convert.ToInt32(reader("CategoryID"))
                        Dim categoryName As String = Convert.ToString(reader("CategoryName"))
                        Dim isPredefined As Boolean = Convert.ToBoolean(reader("IsPredefined"))
                        Dim categoryItem As New CategoryItem(categoryID, categoryName, isPredefined)
                        cboCategory.Items.Add(categoryItem)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        If cboCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedCategory As CategoryItem = DirectCast(cboCategory.SelectedItem, CategoryItem)
        Dim categoryID As Integer = selectedCategory.CategoryID
        Dim categoryName As String = selectedCategory.CategoryName
        Dim isPredefined As Integer = If(selectedCategory.IsPredefined, 1, 0) ' Set IsPredefined based on the selected category

        Dim budgetAmount As Decimal
        If Decimal.TryParse(txtBudgetAmount.Text, budgetAmount) Then
            Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
            Dim userID As Integer = GetUserIDByUsername(connectionString, username)

            Try
                Using con As New SqlConnection(connectionString)
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    Dim query As String = "INSERT INTO Budget (UserID, CategoryID, IsPredefined, BudgetAmount, BudgetDate) VALUES (@UserID, @CategoryID, @IsPredefined, @BudgetAmount, @BudgetDate)"

                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@UserID", userID)
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                        cmd.Parameters.AddWithValue("@IsPredefined", isPredefined) ' Set IsPredefined based on the selected category
                        cmd.Parameters.AddWithValue("@BudgetAmount", budgetAmount)
                        cmd.Parameters.AddWithValue("@BudgetDate", DateTime.Now) ' Use current date and time
                        cmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Budget data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please enter a valid budget amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub RemoveBudget_btn_Click(sender As Object, e As EventArgs) Handles RemoveBudget_btn.Click
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

        If cboCategory.SelectedItem IsNot Nothing Then
            Dim selectedCategory As CategoryItem = DirectCast(cboCategory.SelectedItem, CategoryItem)
            Dim categoryID As Integer = selectedCategory.CategoryID
            Dim categoryName As String = selectedCategory.CategoryName

            Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
            Dim userID As Integer = GetUserIDByUsername(connectionString, username)
            RemoveBudget(connectionString, categoryID, userID)
        Else
            MessageBox.Show("Please select a category to remove the budget.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RemoveBudget(connectionString As String, categoryID As Integer, userID As Integer)
        Try
            Using con As New SqlConnection(connectionString)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim query As String = "DELETE FROM Budget WHERE UserID = @UserID AND CategoryID = @CategoryID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Budget removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_edit_Click(sender As Object, e As EventArgs) Handles Btn_edit.Click
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

        Try
            Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
            Dim userID As Integer = GetUserIDByUsername(connectionString, username)

            Dim budgets As New List(Of BudgetItem)()
            ' Retrieve all budgets for the current user
            budgets = GetBudgetsForUser(connectionString, userID)

            If budgets.Count > 0 Then
                ' Display a dialog box to select the budget to edit
                Dim selectedBudget As BudgetItem = SelectBudget(budgets, connectionString)
                If selectedBudget IsNot Nothing Then
                    ' Display a form to edit the budget amount
                    Dim newBudgetAmount As Decimal = EditBudgetAmount(selectedBudget.BudgetAmount)
                    If newBudgetAmount <> selectedBudget.BudgetAmount Then
                        ' Update the budget amount in the database
                        UpdateBudgetAmount(connectionString, selectedBudget.BudgetID, newBudgetAmount)
                    End If
                End If
            Else
                MessageBox.Show("No budgets found for the current user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetBudgetsForUser(connectionString As String, userID As Integer) As List(Of BudgetItem)
        Dim budgets As New List(Of BudgetItem)()

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT BudgetID, CategoryID, IsPredefined, BudgetAmount, BudgetDate FROM Budget WHERE UserID = @UserID"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserID", userID)

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim budgetID As Integer = Convert.ToInt32(reader("BudgetID"))
                    Dim categoryID As Integer = Convert.ToInt32(reader("CategoryID"))
                    Dim isPredefined As Boolean = Convert.ToBoolean(reader("IsPredefined"))
                    Dim budgetAmount As Decimal = Convert.ToDecimal(reader("BudgetAmount"))
                    Dim budgetDate As DateTime = If(reader("BudgetDate") IsNot DBNull.Value, Convert.ToDateTime(reader("BudgetDate")), DateTime.MinValue)
                    Dim budgetItem As New BudgetItem(budgetID, categoryID, isPredefined, budgetAmount)
                    budgets.Add(budgetItem)
                End While
            End Using
        End Using

        Return budgets
    End Function

    Private Function SelectBudget(ByVal budgets As List(Of BudgetItem), ByVal connectionString As String) As BudgetItem
        Dim selectedBudget As BudgetItem = Nothing

        ' Prompt the user to enter the budget ID
        Dim budgetIDInput As String = InputBox("Enter the budget ID you want to edit:" & vbCrLf & GetBudgetListAsString(budgets, connectionString), "Edit Budget", "")

        If Not String.IsNullOrEmpty(budgetIDInput) Then
            Dim budgetID As Integer
            If Integer.TryParse(budgetIDInput, budgetID) Then
                selectedBudget = budgets.FirstOrDefault(Function(b) b.BudgetID = budgetID)
            Else
                MessageBox.Show("Invalid input. Please enter a valid budget ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Return selectedBudget
    End Function


    Private Function GetBudgetListAsString(ByVal budgets As List(Of BudgetItem), ByVal connectionString As String) As String
        Dim sb As New StringBuilder()

        For Each budget As BudgetItem In budgets
            ' Append the budget details to the string builder
            sb.AppendLine($"Budget ID: {budget.BudgetID},  Is Predefined: {budget.IsPredefined}, Amount: {budget.BudgetAmount}")
        Next

        Return sb.ToString()
    End Function

    Private Function EditBudgetAmount(ByVal currentAmount As Decimal) As Decimal
        ' Display a dialog box or form to allow the user to edit the budget amount
        Dim result As String = InputBox($"Enter the new budget amount (current amount: {currentAmount}):", "Edit Budget", currentAmount.ToString())

        Dim newAmount As Decimal
        If Decimal.TryParse(result, newAmount) Then
            Return newAmount
        Else
            Return currentAmount
        End If
    End Function

    Private Sub UpdateBudgetAmount(ByVal connectionString As String, ByVal budgetID As Integer, ByVal newAmount As Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim query As String = "UPDATE Budget SET BudgetAmount = @BudgetAmount WHERE BudgetID = @BudgetID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@BudgetID", budgetID)
                    cmd.Parameters.AddWithValue("@BudgetAmount", newAmount)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Budget amount updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Class CategoryItem
        Public Property CategoryID As Integer
        Public Property CategoryName As String
        Public Property IsPredefined As Boolean

        Public Sub New(ByVal id As Integer, ByVal name As String, ByVal isPredefined As Boolean)
            CategoryID = id
            CategoryName = name
            Me.IsPredefined = isPredefined
        End Sub

        Public Overrides Function ToString() As String
            Return CategoryName
        End Function
    End Class

    Public Class BudgetItem
        Public Property BudgetID As Integer
        Public Property CategoryID As Integer
        Public Property IsPredefined As Boolean
        Public Property BudgetAmount As Decimal

        Public Sub New(ByVal id As Integer, ByVal categoryId As Integer, ByVal isPredefined As Boolean, ByVal amount As Decimal)
            BudgetID = id
            categoryId = categoryId ' Fixed the assignment to properly set the CategoryID property
            Me.IsPredefined = isPredefined
            Me.BudgetAmount = amount
        End Sub
    End Class

    Private Sub View_budget_btn_Click(sender As Object, e As EventArgs) Handles View_budget_btn.Click
        Dim viewBudgetDialog As New Form()
        viewBudgetDialog.Text = "View Budgets"

        ' Create DataGridView control
        Dim dgvBudget As New DataGridView()
        dgvBudget.Dock = DockStyle.Fill
        dgvBudget.ReadOnly = True
        dgvBudget.AllowUserToAddRows = False
        viewBudgetDialog.Controls.Add(dgvBudget)

        ' Create and configure DataGridView columns
        Dim colBudgetID As New DataGridViewTextBoxColumn()
        colBudgetID.HeaderText = "Budget ID"
        colBudgetID.Name = "colBudgetID"
        dgvBudget.Columns.Add(colBudgetID)

        Dim colCategoryName As New DataGridViewTextBoxColumn()
        colCategoryName.HeaderText = "Category Name"
        colCategoryName.Name = "colCategoryName"
        dgvBudget.Columns.Add(colCategoryName)

        Dim colIsPredefined As New DataGridViewTextBoxColumn()
        colIsPredefined.HeaderText = "IsPredefined"
        colIsPredefined.Name = "colIsPredefined"
        dgvBudget.Columns.Add(colIsPredefined)

        Dim colBudgetAmount As New DataGridViewTextBoxColumn()
        colBudgetAmount.HeaderText = "Budget Amount"
        colBudgetAmount.Name = "colBudgetAmount"
        dgvBudget.Columns.Add(colBudgetAmount)

        Dim colBudgetDate As New DataGridViewTextBoxColumn()
        colBudgetDate.HeaderText = "Budget Date"
        colBudgetDate.Name = "colBudgetDate"
        dgvBudget.Columns.Add(colBudgetDate)

        ' Load Budget data into DataGridView
        LoadBudgets(dgvBudget)

        ' Show the dialog box
        viewBudgetDialog.ShowDialog()
    End Sub

    Private Sub LoadBudgets(ByVal dgv As DataGridView)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT b.BudgetID, c.CategoryName, b.IsPredefined, b.BudgetAmount, b.BudgetDate " &
                      "FROM Budget b " &
                      "INNER JOIN Category c ON b.CategoryID = c.CategoryID"

                Using cmd As New SqlCommand(query, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim BudgetID As Integer = Convert.ToInt32(reader("BudgetID"))
                        Dim categoryName As String = Convert.ToString(reader("CategoryName"))
                        Dim isPredefined As Boolean = Convert.ToBoolean(reader("IsPredefined"))
                        Dim BudgetAmount As Decimal = Convert.ToDecimal(reader("BudgetAmount"))
                        Dim BudgetDate As Date = Convert.ToDateTime(reader("BudgetDate"))
                        ' Add Budget details to DataGridView
                        dgv.Rows.Add(BudgetID, categoryName, isPredefined, BudgetAmount, BudgetDate)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class