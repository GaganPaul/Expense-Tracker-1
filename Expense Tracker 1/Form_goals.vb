Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form_goals
    Private connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

    Private Sub Form_goals_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define columns for the DataGridView
        DataGridView1.Columns.Add("GoalIDColumn", "Goal ID")
        DataGridView1.Columns.Add("GoalNameColumn", "Goal Name")
        DataGridView1.Columns.Add("TargetAmountColumn", "Target Amount")
        DataGridView1.Columns.Add("TargetDateColumn", "Target Date")

        ' Set Goal ID column as read-only
        DataGridView1.Columns("GoalIDColumn").ReadOnly = True

        ' Load the goals for the current user when the form loads
        Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)
        If userID > 0 Then
            PopulateGoals(userID)
        Else
            MessageBox.Show("Failed to retrieve user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub PopulateGoals(userID As Integer)
        ' Clear existing items from DataGridView
        DataGridView1.Rows.Clear()

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT GoalID, GoalName, TargetAmount, TargetDate FROM FinancialGoals WHERE UserID = @UserID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim goalID As Integer = Convert.ToInt32(reader("GoalID"))
                        Dim goalName As String = Convert.ToString(reader("GoalName"))
                        Dim targetAmount As Decimal = Convert.ToDecimal(reader("TargetAmount"))
                        Dim targetDate As Date = Convert.ToDateTime(reader("TargetDate"))

                        ' Add goal details to DataGridView
                        DataGridView1.Rows.Add(goalID, goalName, targetAmount, targetDate)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Add_goal_btn_Click(sender As Object, e As EventArgs) Handles Add_goal_btn.Click
        ' Implement code to add a new financial goal
        Dim goalName As String = InputBox("Enter the goal name:", "Add New Goal")
        Dim targetAmountInput As String = InputBox("Enter the target amount:", "Add New Goal")
        Dim targetDateInput As String = InputBox("Enter the target date (YYYY-MM-DD):", "Add New Goal")

        ' Validate input
        If Not String.IsNullOrWhiteSpace(goalName) AndAlso Decimal.TryParse(targetAmountInput, Nothing) AndAlso Date.TryParse(targetDateInput, Nothing) Then
            Dim targetAmount As Decimal = Convert.ToDecimal(targetAmountInput)
            Dim targetDate As Date = Convert.ToDateTime(targetDateInput)

            ' Insert the new goal into the database
            If InsertNewGoal(goalName, targetAmount, targetDate) Then
                MessageBox.Show("Goal added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Refresh DataGridView to display the new goal
                PopulateGoals(GetUserIDByUsername(connectionString, Mainform.Login_info1.Text.Substring("User: ".Length).Trim()))
            Else
                MessageBox.Show("Failed to add goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid input. Please enter valid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function InsertNewGoal(goalName As String, targetAmount As Decimal, targetDate As Date) As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim username As String = Mainform.Login_info1.Text.Substring("User: ".Length).Trim()
                Dim query As String = "INSERT INTO FinancialGoals (UserID, GoalName, TargetAmount, TargetDate) VALUES (@UserID, @GoalName, @TargetAmount, @TargetDate)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", GetUserIDByUsername(connectionString, username))
                    cmd.Parameters.AddWithValue("@GoalName", goalName)
                    cmd.Parameters.AddWithValue("@TargetAmount", targetAmount)
                    cmd.Parameters.AddWithValue("@TargetDate", targetDate)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub Remove_goal_btn_Click(sender As Object, e As EventArgs) Handles Remove_goal_btn.Click
        ' Check if a goal is selected in the DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected goal ID
            Dim selectedGoalID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("GoalID").Value)

            ' Ask for confirmation before removing the goal
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove this goal?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Remove the goal from the database
                If RemoveGoal(selectedGoalID) Then
                    MessageBox.Show("Goal removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Refresh DataGridView to reflect changes
                    PopulateGoals(GetUserIDByUsername(connectionString, Mainform.Login_info1.Text.Substring("User: ".Length).Trim()))
                Else
                    MessageBox.Show("Failed to remove goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a goal to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function RemoveGoal(goalID As Integer) As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Delete the goal from the FinancialGoals table
                Dim query As String = "DELETE FROM FinancialGoals WHERE GoalID = @GoalID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@GoalID", goalID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub Edit_goal_btn_Click(sender As Object, e As EventArgs) Handles Edit_goal_btn.Click
        ' Check if a goal is selected in the DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected goal ID
            Dim selectedGoalID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("GoalID").Value)

            ' Open an input dialog to get the new goal name and target amount from the user
            Dim newGoalName As String = InputBox("Enter the new goal name:", "Edit Goal", DataGridView1.SelectedRows(0).Cells("GoalName").Value.ToString())
            Dim newTargetAmount As Decimal
            Dim targetAmountInput As String = InputBox("Enter the new target amount:", "Edit Goal", DataGridView1.SelectedRows(0).Cells("TargetAmount").Value.ToString())

            ' Validate the input for the new target amount
            If Decimal.TryParse(targetAmountInput, newTargetAmount) Then
                ' Update the goal in the database
                If UpdateGoal(selectedGoalID, newGoalName, newTargetAmount) Then
                    MessageBox.Show("Goal updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Refresh DataGridView to reflect changes
                    PopulateGoals(GetUserIDByUsername(connectionString, Mainform.Login_info1.Text.Substring("User: ".Length).Trim()))
                Else
                    MessageBox.Show("Failed to update goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid target amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please select a goal to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function UpdateGoal(goalID As Integer, newGoalName As String, newTargetAmount As Decimal) As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Update the goal in the FinancialGoals table
                Dim query As String = "UPDATE FinancialGoals SET GoalName = @GoalName, TargetAmount = @TargetAmount WHERE GoalID = @GoalID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@GoalID", goalID)
                    cmd.Parameters.AddWithValue("@GoalName", newGoalName)
                    cmd.Parameters.AddWithValue("@TargetAmount", newTargetAmount)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Back3_btn_Click(sender As Object, e As EventArgs) Handles Back3_btn.Click
        Me.Hide()
        Mainform.Show()
    End Sub
End Class