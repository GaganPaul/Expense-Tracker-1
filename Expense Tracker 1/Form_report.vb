Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form_report
    Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"

    Private Sub Daily_report_btn_Click(sender As Object, e As EventArgs) Handles Daily_report_btn.Click
        ' Extract the username from the label
        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2) ' Assuming the label text format is "User: username"

        Dim selectedDate As Date = DateTime.Today ' Use current date

        ' Retrieve user ID based on the logged-in username
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        ' Retrieve daily budget data for the selected date
        Dim dailyBudgetData As Decimal = GetBudgetForDate(userID, selectedDate)

        ' Retrieve daily expense data for the selected date
        Dim dailyExpenseData As Decimal = GetExpenseForDate(userID, selectedDate)

        ' Generate column chart for daily report
        GenerateColumnChart(Chart1, selectedDate, dailyBudgetData, dailyExpenseData)
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

    Private Function GetDailyExpenseData(userID As Integer, selectedDate As Date) As List(Of Decimal)
        Dim dailyExpenseData As New List(Of Decimal)()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT Amount FROM Expense WHERE UserID = @UserID AND ExpenseDate = @ExpenseDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@ExpenseDate", selectedDate)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim expenseAmount As Decimal = Convert.ToDecimal(reader("Amount"))
                            dailyExpenseData.Add(expenseAmount)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving daily expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dailyExpenseData
    End Function
    Private Function GetDailyBudgetData(userID As Integer, selectedDate As Date) As List(Of Decimal)
        Dim dailyBudgetData As New List(Of Decimal)()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT BudgetAmount FROM Budget WHERE UserID = @UserID AND BudgetDate = @BudgetDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@BudgetDate", selectedDate)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim budgetAmount As Decimal = Convert.ToDecimal(reader("BudgetAmount"))
                            dailyBudgetData.Add(budgetAmount)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving daily budget data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dailyBudgetData
    End Function

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles Back_btn.Click
        Me.Hide()
        Mainform.Show()
    End Sub

    Private Sub week_report_btn_Click(sender As Object, e As EventArgs) Handles week_report_button.Click
        ' Extract the username from the label
        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2) ' Assuming the label text format is "User: username"

        Dim startDate As Date = DateTime.Today.AddDays(-6) ' Start date of the week (7 days ago)
        Dim endDate As Date = DateTime.Today ' End date (today)

        ' Retrieve user ID based on the logged-in username
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        ' Retrieve weekly budget data
        Dim weeklyBudgetData As Dictionary(Of Date, Decimal) = GetBudgetsForWeek(userID, startDate, endDate)

        ' Retrieve weekly expense data
        Dim weeklyExpenseData As Dictionary(Of Date, Decimal) = GetExpensesForWeek(userID, startDate, endDate)

        ' Generate column chart for weekly report
        GenerateColumnChart(Chart1, startDate, endDate, weeklyBudgetData, weeklyExpenseData)
    End Sub



    Private Sub GenerateColumnChart(chart As Chart, selectedDate As Date, budgetData As Decimal, expenseData As Decimal)
        chart.Series.Clear()

        ' Add budget series
        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column
        budgetSeries.Points.AddXY("Budget", budgetData)
        chart.Series.Add(budgetSeries)

        ' Add expense series
        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column
        expenseSeries.Points.AddXY("Expense", expenseData)
        chart.Series.Add(expenseSeries)

        ' Customize chart appearance
        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.Maximum = 90000
        chart.ChartAreas(0).AxisX.Title = "Category"
        chart.ChartAreas(0).AxisY.Title = "Amount"
        chart.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
        chart.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    End Sub

    Private Sub GenerateColumnChart(chart As Chart, startDate As Date, endDate As Date, budgetData As Dictionary(Of Date, Decimal), expenseData As Dictionary(Of Date, Decimal))
        chart.Series.Clear()

        ' Add budget series
        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column
        For Each kvp As KeyValuePair(Of Date, Decimal) In budgetData
            budgetSeries.Points.AddXY(kvp.Key.ToShortDateString(), kvp.Value)
        Next
        chart.Series.Add(budgetSeries)

        ' Add expense series
        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column
        For Each kvp As KeyValuePair(Of Date, Decimal) In expenseData
            expenseSeries.Points.AddXY(kvp.Key.ToShortDateString(), kvp.Value)
        Next
        chart.Series.Add(expenseSeries)

        ' Customize chart appearance
        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.Maximum = 90000
        chart.ChartAreas(0).AxisX.Title = "Date"
        chart.ChartAreas(0).AxisY.Title = "Amount"
        chart.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
        chart.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    End Sub



    Private Function GetBudgetsForWeek(userID As Integer, startDate As Date, endDate As Date) As Dictionary(Of Date, Decimal)
        Dim budgetData As New Dictionary(Of Date, Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT BudgetDate, BudgetAmount FROM Budget WHERE UserID = @UserID AND BudgetDate BETWEEN @StartDate AND @EndDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim budgetDate As Date = Convert.ToDateTime(reader("BudgetDate"))
                            Dim budgetAmount As Decimal = Convert.ToDecimal(reader("BudgetAmount"))
                            If Not budgetData.ContainsKey(budgetDate) Then
                                budgetData.Add(budgetDate, budgetAmount)
                            Else
                                budgetData(budgetDate) += budgetAmount
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving weekly budget data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return budgetData
    End Function


    Private Function GetExpensesForWeek(userID As Integer, startDate As Date, endDate As Date) As Dictionary(Of Date, Decimal)
        Dim expenseData As New Dictionary(Of Date, Decimal)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT ExpenseDate, SUM(Amount) AS TotalAmount FROM Expense WHERE UserID = @UserID AND ExpenseDate BETWEEN @StartDate AND @EndDate GROUP BY ExpenseDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim expenseDate As Date = Convert.ToDateTime(reader("ExpenseDate"))
                            Dim expenseAmount As Decimal = Convert.ToDecimal(reader("TotalAmount"))
                            If Not expenseData.ContainsKey(expenseDate) Then
                                expenseData.Add(expenseDate, expenseAmount)
                            Else
                                expenseData(expenseDate) += expenseAmount
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving weekly expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return expenseData
    End Function
    Private Function GetBudgetForDate(userID As Integer, selectedDate As Date) As Decimal
        Dim budgetAmount As Decimal = 0
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT BudgetAmount FROM Budget WHERE UserID = @UserID AND BudgetDate = @BudgetDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@BudgetDate", selectedDate)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        budgetAmount = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving budget data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return budgetAmount
    End Function

    Private Function GetExpenseForDate(userID As Integer, selectedDate As Date) As Decimal
        Dim expenseAmount As Decimal = 0
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT SUM(Amount) FROM Expense WHERE UserID = @UserID AND ExpenseDate = @ExpenseDate"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@ExpenseDate", selectedDate)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        expenseAmount = Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return expenseAmount
    End Function

    Private Sub Monthly_report_btn_Click(sender As Object, e As EventArgs) Handles Monthly_report_btn.Click
        ' Extract the username from the label
        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2) ' Assuming the label text format is "User: username"

        ' Retrieve user ID based on the logged-in username
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        ' Get the selected month and year
        Dim selectedMonth As Integer = DateTime.Today.Month ' Use the current month
        Dim selectedYear As Integer = DateTime.Today.Year ' Use the current year

        ' Retrieve the budget data for the selected month
        Dim monthlyBudgetData As Dictionary(Of Integer, Decimal) = GetMonthlyBudgetData(userID, selectedMonth, selectedYear)

        ' Retrieve the expense data for the selected month
        Dim monthlyExpenseData As Dictionary(Of Integer, Decimal) = GetMonthlyExpenseData(userID, selectedMonth, selectedYear)

        ' Generate column chart for monthly report
        GenerateColumnChart(Chart1, monthlyBudgetData, monthlyExpenseData)
    End Sub


    Private Function GetMonthlyBudgetData(userID As Integer, month As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim monthlyBudgetData As New Dictionary(Of Integer, Decimal)()
        Try
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
                            monthlyBudgetData(monthNumber) = totalBudget
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving monthly budget data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return monthlyBudgetData
    End Function

    Private Function GetMonthlyExpenseData(userID As Integer, month As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim monthlyExpenseData As New Dictionary(Of Integer, Decimal)()
        Try
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
                            monthlyExpenseData(monthNumber) = totalExpense
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving monthly expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return monthlyExpenseData
    End Function

    Private Sub GenerateColumnChart(chart As Chart, budgetData As Dictionary(Of Integer, Decimal), expenseData As Dictionary(Of Integer, Decimal))
        chart.Series.Clear()

        ' Add budget series
        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column

        ' Add each budget amount to the chart
        For Each kvp As KeyValuePair(Of Integer, Decimal) In budgetData
            Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(kvp.Key)
            Dim budgetAmount As Decimal = kvp.Value
            budgetSeries.Points.AddXY(monthName, budgetAmount)
        Next

        chart.Series.Add(budgetSeries)

        ' Add expense series
        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column

        ' Add each expense amount to the chart
        For Each kvp As KeyValuePair(Of Integer, Decimal) In expenseData
            Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(kvp.Key)
            Dim expenseAmount As Decimal = kvp.Value
            expenseSeries.Points.AddXY(monthName, expenseAmount)
        Next

        chart.Series.Add(expenseSeries)

        ' Customize chart appearance
        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.Maximum = 90000
        chart.ChartAreas(0).AxisX.Title = "Month"
        chart.ChartAreas(0).AxisY.Title = "Amount"
        chart.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
        chart.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    End Sub
    Private Sub Yearly_report_btn_Click(sender As Object, e As EventArgs) Handles Yearly_report_btn.Click
        ' Extract the username from the label
        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2) ' Assuming the label text format is "User: username"

        ' Retrieve user ID based on the logged-in username
        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        ' Retrieve the list of years from the database
        Dim years As List(Of Integer) = GetYearsFromDatabase()

        ' Retrieve the budget data for each year
        Dim yearlyBudgetData As New Dictionary(Of Integer, Dictionary(Of Integer, Decimal))()
        For Each year As Integer In years
            yearlyBudgetData(year) = GetYearlyBudgetData(userID, year)
        Next

        ' Retrieve the expense data for each year
        Dim yearlyExpenseData As New Dictionary(Of Integer, Dictionary(Of Integer, Decimal))()
        For Each year As Integer In years
            yearlyExpenseData(year) = GetYearlyExpenseData(userID, year)
        Next

        ' Generate column chart for yearly report
        GenerateYearlyColumnChart(Chart1, years, yearlyBudgetData, yearlyExpenseData)
    End Sub

    Private Sub GenerateYearlyColumnChart(chart As Chart, years As List(Of Integer), budgetData As Dictionary(Of Integer, Dictionary(Of Integer, Decimal)), expenseData As Dictionary(Of Integer, Dictionary(Of Integer, Decimal)))
        chart.Series.Clear()

        For Each year As Integer In years
            ' Add budget series for the current year
            Dim budgetSeries As New Series($"Budget ({year})")
            budgetSeries.ChartType = SeriesChartType.Column

            ' Add each budget amount to the chart
            For Each kvp As KeyValuePair(Of Integer, Decimal) In budgetData(year)
                Dim monthName As String = kvp.Key.ToString()
                Dim budgetAmount As Decimal = kvp.Value
                budgetSeries.Points.AddXY(monthName, budgetAmount)
            Next

            chart.Series.Add(budgetSeries)

            ' Add expense series for the current year
            Dim expenseSeries As New Series($"Expense ({year})")
            expenseSeries.ChartType = SeriesChartType.Column

            ' Add each expense amount to the chart
            For Each kvp As KeyValuePair(Of Integer, Decimal) In expenseData(year)
                Dim monthName As String = kvp.Key.ToString()
                Dim expenseAmount As Decimal = kvp.Value
                expenseSeries.Points.AddXY(monthName, expenseAmount)
            Next

            chart.Series.Add(expenseSeries)
        Next

        ' Customize chart appearance
        chart.ChartAreas(0).AxisX.Interval = 1
        chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        chart.ChartAreas(0).AxisY.Maximum = 90000 ' Set maximum y-axis value to 90000
        chart.ChartAreas(0).AxisX.Title = "Year" ' Change axis title to "Month"
        chart.ChartAreas(0).AxisY.Title = "Amount"
        chart.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
        chart.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
    End Sub

    Private Function GetYearsFromDatabase() As List(Of Integer)
        Dim years As New List(Of Integer)()

        ' Query distinct years from the Expense table
        Dim expenseQuery As String = "SELECT DISTINCT YEAR(ExpenseDate) AS Year FROM Expense"
        ' Query distinct years from the Budget table
        Dim budgetQuery As String = "SELECT DISTINCT YEAR(BudgetDate) AS Year FROM Budget"

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Query distinct years from the Expense table
                Using cmd As New SqlCommand(expenseQuery, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            years.Add(Convert.ToInt32(reader("Year")))
                        End While
                    End Using
                End Using

                ' Query distinct years from the Budget table
                Using cmd As New SqlCommand(budgetQuery, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim year As Integer = Convert.ToInt32(reader("Year"))
                            ' Add year to the list if it's not already present
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

        ' Sort the list of years in ascending order
        years.Sort()

        Return years
    End Function
    Private Function GetYearlyBudgetData(userID As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim yearlyBudgetData As New Dictionary(Of Integer, Decimal)()
        Try
            ' Initialize the dictionary with entries for all months of the year
            For month As Integer = 1 To 12
                yearlyBudgetData(month) = 0 ' Initialize budget amount for each month to 0
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
            ' Initialize the dictionary with entries for all months of the year
            For month As Integer = 1 To 12
                yearlyExpenseData(month) = 0 ' Initialize expense amount for each month to 0
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


End Class
