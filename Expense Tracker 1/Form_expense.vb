Imports System.Data.SqlClient
Imports System.Text

Public Class Form_expense
    Private connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=FalseData Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

    Private Sub Form_expense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCategories()
    End Sub

    Private Sub PopulateCategories()
        Try
            Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
            Dim userID As Integer = GetUserIDByUsername(connectionString, username)

            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT c.CategoryID, c.CategoryName, 
                            CASE WHEN c.CategoryID IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11) THEN 1 ELSE 0 END AS IsPredefined
                            FROM Category c
                            WHERE c.CreatedByUserID = @UserID OR c.IsPredefined = 1"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)

                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim categoryID As Integer = Convert.ToInt32(reader("CategoryID"))
                        Dim categoryName As String = Convert.ToString(reader("CategoryName"))
                        Dim isPredefined As Boolean = Convert.ToBoolean(reader("IsPredefined"))
                        Dim categoryItem As New CategoryItem(categoryID, categoryName, isPredefined)
                        Cbo1Category.Items.Add(categoryItem)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Save_expense_btn_Click(sender As Object, e As EventArgs) Handles Save_expense_btn.Click
        Dim categoryItem As CategoryItem = DirectCast(Cbo1Category.SelectedItem, CategoryItem)
        Dim categoryID As Integer = categoryItem.CategoryID
        Dim amount As Decimal
        Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        If Decimal.TryParse(Txt_ExpenseAmount.Text, amount) Then
            Dim description As String = Text_description.Text.Trim()


            Dim goals As List(Of FinancialGoal) = GetFinancialGoals(userID)


            Dim goalIDNameInput As String = "Enter the financial goal ID:" & vbCrLf
            For Each goal As FinancialGoal In goals
                goalIDNameInput &= $"{goal.GoalID}: {goal.GoalName}" & vbCrLf
            Next


            Dim goalIDInput As String = InputBox(goalIDNameInput, "Financial Goal", "")

            If Not String.IsNullOrEmpty(goalIDInput) Then
                Dim goalID As Integer
                If Integer.TryParse(goalIDInput, goalID) Then

                    SaveExpenseAndAssociateWithGoal(userID, categoryID, DateTime.Now.Date, amount, description, goalID)
                Else
                    MessageBox.Show("Invalid financial goal ID. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else

                SaveExpense(userID, categoryID, DateTime.Now.Date, amount, description)
            End If
        Else
            MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function GetFinancialGoals(userID As Integer) As List(Of FinancialGoal)
        Dim goals As New List(Of FinancialGoal)()

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT GoalID, GoalName FROM FinancialGoals WHERE UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim goalID As Integer = Convert.ToInt32(reader("GoalID"))
                            Dim goalName As String = reader("GoalName").ToString()
                            Dim goal As New FinancialGoal(goalID, goalName)
                            goals.Add(goal)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving financial goals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return goals
    End Function

    Private Sub Edit_expense_btn_Click(sender As Object, e As EventArgs) Handles Edit_expense_btn.Click
        Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        Try
            Dim expenses As List(Of ExpenseItem) = GetExpensesForUser(connectionString, userID)

            If expenses.Count > 0 Then
                Dim selectedExpense As ExpenseItem = SelectExpense(expenses)
                If selectedExpense IsNot Nothing Then
                    Dim newExpenseAmount As Decimal = EditExpenseAmount(selectedExpense.ExpenseAmount)
                    If newExpenseAmount <> selectedExpense.ExpenseAmount Then
                        UpdateExpenseAmount(connectionString, selectedExpense.ExpenseID, newExpenseAmount)
                    End If
                End If
            Else
                MessageBox.Show("No expenses found for the current user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveExpenseAndAssociateWithGoal(userID As Integer, categoryID As Integer, expenseDate As Date, amount As Decimal, description As String, goalID As Integer)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "INSERT INTO Expense (UserID, CategoryID, ExpenseDate, Amount, Description) " &
                                  "VALUES (@UserID, @CategoryID, @ExpenseDate, @Amount, @Description); SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                    cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate)
                    cmd.Parameters.AddWithValue("@Amount", amount)
                    cmd.Parameters.AddWithValue("@Description", description)
                    Dim expenseID As Integer = Convert.ToInt32(cmd.ExecuteScalar())


                    InsertExpenseToGoal(con, expenseID, goalID)
                End Using
            End Using
            MessageBox.Show("Expense saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertExpenseToGoal(con As SqlConnection, expenseID As Integer, goalID As Integer)
        Dim query As String = "INSERT INTO ExpenseToGoal (ExpenseID, GoalID) VALUES (@ExpenseID, @GoalID)"
        Using cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ExpenseID", expenseID)
            cmd.Parameters.AddWithValue("@GoalID", goalID)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub SaveExpense(userID As Integer, categoryID As Integer, expenseDate As Date, amount As Decimal, description As String)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "INSERT INTO Expense (UserID, CategoryID, ExpenseDate, Amount, Description) " &
                                  "VALUES (@UserID, @CategoryID, @ExpenseDate, @Amount, @Description)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                    cmd.Parameters.AddWithValue("@ExpenseDate", expenseDate)
                    cmd.Parameters.AddWithValue("@Amount", amount)
                    cmd.Parameters.AddWithValue("@Description", description)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Expense saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetExpensesForUser(connectionString As String, userID As Integer) As List(Of ExpenseItem)
        Dim expenses As New List(Of ExpenseItem)()

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT ExpenseID, CategoryID, Amount FROM Expense WHERE UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)

                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim expenseID As Integer = Convert.ToInt32(reader("ExpenseID"))
                        Dim categoryID As Integer = Convert.ToInt32(reader("CategoryID"))
                        Dim expenseAmount As Decimal = Convert.ToDecimal(reader("Amount"))
                        Dim expenseItem As New ExpenseItem(expenseID, categoryID, expenseAmount)
                        expenses.Add(expenseItem)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return expenses
    End Function

    Private Function SelectExpense(ByVal expenses As List(Of ExpenseItem)) As ExpenseItem
        Dim selectedExpense As ExpenseItem = Nothing

        Dim expenseIDInput As String = InputBox("Enter the expense ID you want to edit:" & vbCrLf & GetExpenseListAsString(expenses), "Edit Expense", "")

        If Not String.IsNullOrEmpty(expenseIDInput) Then
            Dim expenseID As Integer
            If Integer.TryParse(expenseIDInput, expenseID) Then
                selectedExpense = expenses.FirstOrDefault(Function(e) e.ExpenseID = expenseID)
            Else
                MessageBox.Show("Invalid input. Please enter a valid expense ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Return selectedExpense
    End Function

    Private Function GetExpenseListAsString(ByVal expenses As List(Of ExpenseItem)) As String
        Dim sb As New StringBuilder()

        For Each expense As ExpenseItem In expenses
            sb.AppendLine($"Expense ID: {expense.ExpenseID}, Category ID: {expense.CategoryID}, Amount: {expense.ExpenseAmount}")
        Next

        Return sb.ToString()
    End Function

    Private Function EditExpenseAmount(ByVal currentAmount As Decimal) As Decimal
        Dim result As String = InputBox($"Enter the new expense amount (current amount: {currentAmount}):", "Edit Expense", currentAmount.ToString())

        Dim newAmount As Decimal
        If Decimal.TryParse(result, newAmount) Then
            Return newAmount
        Else
            Return currentAmount
        End If
    End Function

    Private Sub UpdateExpenseAmount(ByVal connectionString As String, ByVal expenseID As Integer, ByVal newAmount As Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "UPDATE Expense SET Amount = @Amount WHERE ExpenseID = @ExpenseID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@ExpenseID", expenseID)
                    cmd.Parameters.AddWithValue("@Amount", newAmount)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Expense amount updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetUserIDByUsername(connectionString As String, username As String) As Integer
        Dim userID As Integer = 0

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

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

    Private Sub Remove_expense_btn_Click(sender As Object, e As EventArgs) Handles Remove_expense_btn.Click
        Dim expenseID As Integer = GetExpenseIDFromUserInput("Enter the ID of the expense you want to remove:")
        If expenseID > 0 Then
            ' Remove the expense from the database
            If RemoveExpense(expenseID) Then
                MessageBox.Show("Expense removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Failed to remove expense.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Function GetExpenseIDFromUserInput(prompt As String) As Integer
        Dim input As String = InputBox(prompt, "Expense ID")
        Dim expenseID As Integer
        If Integer.TryParse(input, expenseID) AndAlso expenseID > 0 Then
            Return expenseID
        Else
            MessageBox.Show("Invalid expense ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End If
    End Function

    Private Function GetExpenseDetails(expenseID As Integer) As Tuple(Of Integer, Integer, Date, Decimal, String)
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        Dim query As String = "SELECT CategoryID, ExpenseDate, Amount, Description FROM Expense WHERE ExpenseID = @ExpenseID"
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ExpenseID", expenseID)
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim categoryID As Integer = Convert.ToInt32(reader("CategoryID"))
                    Dim expenseDate As Date = Convert.ToDateTime(reader("ExpenseDate"))
                    Dim amount As Decimal = Convert.ToDecimal(reader("Amount"))
                    Dim description As String = If(reader.IsDBNull(reader.GetOrdinal("Description")), String.Empty, reader("Description").ToString())
                    Return Tuple.Create(expenseID, categoryID, expenseDate, amount, description)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    Private Function RemoveExpense(expenseID As Integer) As Boolean
        Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
        Dim query As String = "DELETE FROM Expense WHERE ExpenseID = @ExpenseID"
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ExpenseID", expenseID)
                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using
        End Using
    End Function

    Private Sub View_expense_btn_Click(sender As Object, e As EventArgs) Handles View_expense_btn.Click
        Dim viewExpenseDialog As New Form()
        viewExpenseDialog.Text = "View Expenses"
        viewExpenseDialog.StartPosition = FormStartPosition.CenterScreen
        viewExpenseDialog.ShowIcon = False

        Dim dgvExpenses As New DataGridView()
        dgvExpenses.Dock = DockStyle.Fill
        dgvExpenses.ReadOnly = True
        dgvExpenses.AllowUserToAddRows = False
        viewExpenseDialog.Controls.Add(dgvExpenses)

        Dim colExpenseID As New DataGridViewTextBoxColumn()
        colExpenseID.HeaderText = "Expense ID"
        colExpenseID.Name = "colExpenseID"
        dgvExpenses.Columns.Add(colExpenseID)

        Dim colCategoryName As New DataGridViewTextBoxColumn()
        colCategoryName.HeaderText = "Category Name"
        colCategoryName.Name = "colCategoryName"
        dgvExpenses.Columns.Add(colCategoryName)

        Dim colExpenseDate As New DataGridViewTextBoxColumn()
        colExpenseDate.HeaderText = "Expense Date"
        colExpenseDate.Name = "colExpenseDate"
        dgvExpenses.Columns.Add(colExpenseDate)

        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.HeaderText = "Amount"
        colAmount.Name = "colAmount"
        dgvExpenses.Columns.Add(colAmount)

        Dim colDescription As New DataGridViewTextBoxColumn()
        colDescription.HeaderText = "Description"
        colDescription.Name = "colDescription"
        dgvExpenses.Columns.Add(colDescription)

        Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        LoadExpenses(dgvExpenses, userID)

        viewExpenseDialog.ShowDialog()
    End Sub

    Private Sub LoadExpenses(ByVal dgv As DataGridView, ByVal userID As Integer)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT e.ExpenseID, c.CategoryName, e.ExpenseDate, e.Amount, e.Description " &
                                      "FROM Expense e " &
                                      "INNER JOIN Category c ON e.CategoryID = c.CategoryID " &
                                      "WHERE e.UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim expenseID As Integer = Convert.ToInt32(reader("ExpenseID"))
                        Dim categoryName As String = Convert.ToString(reader("CategoryName"))
                        Dim expenseDate As Date = Convert.ToDateTime(reader("ExpenseDate"))
                        Dim amount As Decimal = Convert.ToDecimal(reader("Amount"))
                        Dim description As String = Convert.ToString(reader("Description"))

                        dgv.Rows.Add(expenseID, categoryName, expenseDate, amount, description)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Back2_label_Click(sender As Object, e As EventArgs) Handles Back2_label.Click
        Me.Close()
        Mainform.Show()
    End Sub


End Class

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

Public Class ExpenseItem
    Public Property ExpenseID As Integer
    Public Property CategoryID As Integer
    Public Property ExpenseAmount As Decimal

    Public Sub New(ByVal id As Integer, ByVal categoryId As Integer, ByVal amount As Decimal)
        ExpenseID = id
        categoryId = categoryId
        ExpenseAmount = amount
    End Sub
End Class
Public Class FinancialGoal
    Public Property GoalID As Integer
    Public Property GoalName As String

    Public Sub New(ByVal id As Integer, ByVal name As String)
        Me.GoalID = id
        Me.GoalName = name
    End Sub
End Class
