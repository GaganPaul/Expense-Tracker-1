Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form_goals
    Private connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

    Private Sub Form_goals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.Columns.Add("GoalIDColumn", "Goal ID")
        DataGridView1.Columns.Add("GoalNameColumn", "Goal Name")
        DataGridView1.Columns.Add("TargetAmountColumn", "Target Amount")
        DataGridView1.Columns.Add("TargetDateColumn", "Target Date")


        DataGridView1.Columns("GoalIDColumn").ReadOnly = True
        DataGridView1.Columns("GoalNameColumn").ReadOnly = True
        DataGridView1.Columns("TargetAmountColumn").ReadOnly = True
        DataGridView1.Columns("TargetDateColumn").ReadOnly = True



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


                        DataGridView1.Rows.Add(goalID, goalName, targetAmount, targetDate)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Add_goal_btn_Click(sender As Object, e As EventArgs) Handles Add_goal_btn.Click

        Dim goalName As String = InputBox("Enter the goal name:", "Add New Goal")
        Dim targetAmountInput As String = InputBox("Enter the target amount:", "Add New Goal")
        Dim targetDateInput As String = InputBox("Enter the target date (YYYY-MM-DD):", "Add New Goal")


        If Not String.IsNullOrWhiteSpace(goalName) AndAlso Decimal.TryParse(targetAmountInput, Nothing) AndAlso Date.TryParse(targetDateInput, Nothing) Then
            Dim targetAmount As Decimal = Convert.ToDecimal(targetAmountInput)
            Dim targetDate As Date = Convert.ToDateTime(targetDateInput)


            If InsertNewGoal(goalName, targetAmount, targetDate) Then
                MessageBox.Show("Goal added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Function RemoveGoal(goalID As Integer) As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()


                Dim query As String = "DELETE FROM FinancialGoals WHERE GoalID = @GoalID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@GoalID", goalID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("Goal not found or already removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function GetGoalListAsString(ByVal goals As List(Of String)) As String
        Dim goalList As New StringBuilder()

        For Each goal As String In goals
            goalList.AppendLine(goal)
        Next

        Return goalList.ToString()
    End Function
    Private Sub Remove_goal_btn_Click(sender As Object, e As EventArgs) Handles Remove_goal_btn.Click

        Dim goalsList As New List(Of String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim goalID As Integer = Convert.ToInt32(row.Cells("GoalIDColumn").Value)
            Dim goalName As String = Convert.ToString(row.Cells("GoalNameColumn").Value)

            If goalID <> 0 Then
                goalsList.Add($"{goalID}: {goalName}")
            End If
        Next


        Dim goalIDInput As String = InputBox("Enter the goal ID you want to remove:" & vbCrLf & GetGoalListAsString(goalsList), "Remove Goal", "")


        If Not String.IsNullOrEmpty(goalIDInput) Then
            Dim goalID As Integer
            If Integer.TryParse(goalIDInput, goalID) Then
                Dim goalToRemove As String = goalsList.FirstOrDefault(Function(g) g.StartsWith($"{goalID}:"))
                If goalToRemove IsNot Nothing Then

                    Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove this goal?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then

                        Dim selectedGoalIDString As String = goalToRemove.Split(":"c)(0).Trim()
                        Dim selectedGoalID As Integer = Integer.Parse(selectedGoalIDString)

                        If RemoveGoal(selectedGoalID) Then
                            MessageBox.Show("Goal removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            PopulateGoals(GetUserIDByUsername(connectionString, Mainform.Login_info1.Text.Substring("User: ".Length).Trim()))
                        Else
                            MessageBox.Show("Failed to remove goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("Goal with the provided ID was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid input. Please enter a valid goal ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Function SelectGoal(ByVal goals As List(Of String)) As String
        Dim selectedGoal As String = Nothing


        Dim goalIDInput As String = InputBox("Enter the goal ID you want to remove:" & vbCrLf & GetGoalListAsString(goals), "Remove Goal", "")


        If Not String.IsNullOrEmpty(goalIDInput) Then
            Dim goalID As Integer
            If Integer.TryParse(goalIDInput, goalID) Then
                selectedGoal = goals.FirstOrDefault(Function(g) g.StartsWith($"{goalID}:"))
                If selectedGoal Is Nothing Then
                    MessageBox.Show("Goal with the provided ID was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid input. Please enter a valid goal ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Return selectedGoal
    End Function

    Private Sub Edit_goal_btn_Click(sender As Object, e As EventArgs) Handles Edit_goal_btn.Click

        Dim goals As New List(Of String)()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("GoalIDColumn").Value IsNot Nothing AndAlso row.Cells("GoalNameColumn").Value IsNot Nothing Then
                goals.Add(row.Cells("GoalIDColumn").Value.ToString() & ": " & row.Cells("GoalNameColumn").Value.ToString())
            End If
        Next


        Dim selectedGoal As String = SelectGoal1(goals)


        If selectedGoal IsNot Nothing Then
            Dim goalID As Integer = Integer.Parse(selectedGoal.Split(":")(0))


            Dim newGoalName As String = InputBox("Enter the new goal name:", "Edit Goal", selectedGoal.Split(":")(1).Trim())
            Dim targetAmountInput As String = InputBox("Enter the new target amount:", "Edit Goal", "")


            Dim newTargetAmount As Decimal
            If Decimal.TryParse(targetAmountInput, newTargetAmount) Then

                If UpdateGoal(goalID, newGoalName, newTargetAmount) Then
                    MessageBox.Show("Goal updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    PopulateGoals(GetUserIDByUsername(connectionString, Mainform.Login_info1.Text.Substring("User: ".Length).Trim()))
                Else
                    MessageBox.Show("Failed to update goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid target amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please enter a valid goal ID to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Function SelectGoal1(ByVal goals As List(Of String)) As String
        Dim selectedGoal As String = Nothing


        Dim goalIDInput As String = InputBox("Enter the goal ID you want to edit:" & vbCrLf & GetGoalListAsString(goals), "Edit Goal", "")


        If Not String.IsNullOrEmpty(goalIDInput) Then
            Dim goalID As Integer
            If Integer.TryParse(goalIDInput, goalID) Then
                selectedGoal = goals.FirstOrDefault(Function(g) g.StartsWith($"{goalID}:"))
                If selectedGoal Is Nothing Then
                    MessageBox.Show("Goal with the provided ID was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid input. Please enter a valid goal ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Return selectedGoal
    End Function

    Private Function UpdateGoal(goalID As Integer, newGoalName As String, newTargetAmount As Decimal) As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()


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

    Private Sub Back3_btn_Click(sender As Object, e As EventArgs) Handles Back3_btn.Click
        Me.Hide()
        Mainform.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class