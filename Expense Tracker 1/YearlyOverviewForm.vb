Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class YearlyOverviewForm
    Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
    Public Sub GenerateYearlyOverviewGraph()
        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2)


        Dim userID As Integer = GetUserIDByUsername(connectionString, username)


        Dim years As List(Of Integer) = GetYearsFromDatabase()


        Dim yearlyBudgetData As New Dictionary(Of Integer, Dictionary(Of Integer, Decimal))()
        For Each year As Integer In years
            yearlyBudgetData(year) = GetYearlyBudgetData(userID, year)
        Next


        Dim yearlyExpenseData As New Dictionary(Of Integer, Dictionary(Of Integer, Decimal))()
        For Each year As Integer In years
            yearlyExpenseData(year) = GetYearlyExpenseData(userID, year)
        Next


        GenerateYearlyColumnChart(Chart1, years, yearlyBudgetData, yearlyExpenseData)


        For Each year As Integer In years
            Dim progressTowardsGoals As Dictionary(Of String, Decimal) = CalculateProgressTowardsGoals(userID, year)

            SendGoalNotifications(progressTowardsGoals)
        Next
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
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        userID = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userID
    End Function

    Private Sub GenerateYearlyColumnChart(chart As Chart, years As List(Of Integer), budgetData As Dictionary(Of Integer, Dictionary(Of Integer, Decimal)), expenseData As Dictionary(Of Integer, Dictionary(Of Integer, Decimal)))

        chart.Series.Clear()


        For Each year As Integer In years

            Dim budgetSeries As New Series($"Budget ({year})")
            budgetSeries.ChartType = SeriesChartType.Column


            For Each kvp As KeyValuePair(Of Integer, Decimal) In budgetData(year)
                Dim monthName As String = kvp.Key.ToString()
                Dim budgetAmount As Decimal = kvp.Value
                budgetSeries.Points.AddXY(monthName, budgetAmount)
            Next


            chart.Series.Add(budgetSeries)


            Dim expenseSeries As New Series($"Expense ({year})")
            expenseSeries.ChartType = SeriesChartType.Column


            For Each kvp As KeyValuePair(Of Integer, Decimal) In expenseData(year)
                Dim monthName As String = kvp.Key.ToString()
                Dim expenseAmount As Decimal = kvp.Value
                expenseSeries.Points.AddXY(monthName, expenseAmount)
            Next


            chart.Series.Add(expenseSeries)
        Next


        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.Maximum = 90000
        chart.ChartAreas(0).AxisX.Title = "Year"
        chart.ChartAreas(0).AxisY.Title = "Amount"
        chart.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
        chart.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    End Sub

    Private Function GetYearsFromDatabase() As List(Of Integer)
        Dim years As New List(Of Integer)()


        Dim expenseQuery As String = "SELECT DISTINCT YEAR(ExpenseDate) AS Year FROM Expense"

        Dim budgetQuery As String = "SELECT DISTINCT YEAR(BudgetDate) AS Year FROM Budget"

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()


                Using cmd As New SqlCommand(expenseQuery, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            years.Add(Convert.ToInt32(reader("Year")))
                        End While
                    End Using
                End Using


                Using cmd As New SqlCommand(budgetQuery, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim year As Integer = Convert.ToInt32(reader("Year"))

                            If Not years.Contains(year) Then
                                years.Add(year)
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving years from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        years.Sort()

        Return years
    End Function
    Private Function GetYearlyBudgetData(userID As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim yearlyBudgetData As New Dictionary(Of Integer, Decimal)()
        Try

            For month As Integer = 1 To 12
                yearlyBudgetData(month) = 0
            Next

            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT MONTH(BudgetDate) AS Month, SUM(BudgetAmount) AS TotalBudget FROM Budget WHERE UserID = @UserID AND YEAR(BudgetDate) = @Year GROUP BY MONTH(BudgetDate)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@Year", year)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim monthNumber As Integer = Convert.ToInt32(reader("Month"))
                            Dim totalBudget As Decimal = Convert.ToDecimal(reader("TotalBudget"))
                            yearlyBudgetData(monthNumber) = totalBudget
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving yearly budget data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return yearlyBudgetData
    End Function

    Private Function GetYearlyExpenseData(userID As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim yearlyExpenseData As New Dictionary(Of Integer, Decimal)()
        Try

            For month As Integer = 1 To 12
                yearlyExpenseData(month) = 0
            Next

            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT MONTH(ExpenseDate) AS Month, SUM(Amount) AS TotalExpense FROM Expense WHERE UserID = @UserID AND YEAR(ExpenseDate) = @Year GROUP BY MONTH(ExpenseDate)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@Year", year)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim monthNumber As Integer = Convert.ToInt32(reader("Month"))
                            Dim totalExpense As Decimal = Convert.ToDecimal(reader("TotalExpense"))
                            yearlyExpenseData(monthNumber) = totalExpense
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving yearly expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return yearlyExpenseData
    End Function

    Private Function CalculateProgressTowardsGoals(userID As Integer, Optional year As Integer = 0) As Dictionary(Of String, Decimal)
        Dim progressData As New Dictionary(Of String, Decimal)()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT g.GoalName, g.TargetAmount, SUM(e.Amount) AS TotalExpense " &
                              "FROM FinancialGoals g " &
                              "LEFT JOIN ExpenseToGoal etg ON g.GoalID = etg.GoalID " &
                              "LEFT JOIN Expense e ON etg.ExpenseID = e.ExpenseID " &
                              "WHERE g.UserID = @UserID "
                If year <> 0 Then
                    query &= "AND YEAR(e.ExpenseDate) = @Year "
                End If
                query &= "GROUP BY g.GoalName, g.TargetAmount"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    If year <> 0 Then
                        cmd.Parameters.AddWithValue("@Year", year)
                    End If

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim goalName As String = reader("GoalName").ToString()
                            Dim targetAmount As Decimal = Convert.ToDecimal(reader("TargetAmount"))
                            Dim totalExpense As Decimal = If(reader("TotalExpense") IsNot DBNull.Value, Convert.ToDecimal(reader("TotalExpense")), 0)
                            Dim progress As Decimal = If(targetAmount > 0, totalExpense / targetAmount * 100, 0)
                            progressData.Add(goalName, progress)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error calculating progress toward financial goals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return progressData
    End Function

    Private Sub SendGoalNotifications(progressData As Dictionary(Of String, Decimal))
        Dim goalNotifications As New List(Of String)()
        Try
            For Each kvp As KeyValuePair(Of String, Decimal) In progressData
                Dim goalName As String = kvp.Key
                Dim progress As Decimal = kvp.Value

                If progress < 10 Then
                    goalNotifications.Add($"You are behind on your financial goal '{goalName}'.")
                End If
                If progress > 50 Then
                    goalNotifications.Add($"Congrats You are Halfway on your financial goal '{goalName}'.")
                End If
                If progress > 80 Then
                    goalNotifications.Add($"Congrats You have almost reached your financial goal '{goalName}'.")
                End If
                If progress = 100 Then
                    goalNotifications.Add($"Congrats You have reached your financial goal Edit, Remove and Make a new Goal. '{goalName}'.")
                End If
            Next

            If goalNotifications.Any() Then
                Dim notificationMessage As String = String.Join(Environment.NewLine, goalNotifications)
                MessageBox.Show(notificationMessage, "Goal Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error sending goal notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Back4_btn_Click(sender As Object, e As EventArgs) Handles Back4_btn.Click
        Me.Close()
        Mainform.Show()
    End Sub

End Class