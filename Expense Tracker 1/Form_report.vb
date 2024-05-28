Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Printing

Public Class Form_report
    Dim connectionString As String = "Data Source=LAPTOP-QDECFD8R\SQLEXPRESS01;Initial Catalog=expense;Integrated Security=True;Encrypt=False"
    Private currentReport As String = ""

    Private Sub Daily_report_btn_Click(sender As Object, e As EventArgs) Handles Daily_report_btn.Click

        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2)

        Dim selectedDate As Date = DateTime.Today


        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        DisplayBudgetAndExpenses(userID, selectedDate)


        Dim dailyBudgetData As Decimal = GetBudgetForDate(userID, selectedDate)


        Dim dailyExpenseData As Decimal = GetExpenseForDate(userID, selectedDate)


        GenerateColumnChart(Chart1, selectedDate, dailyBudgetData, dailyExpenseData)


        Dim progressTowardsGoals As Dictionary(Of String, Decimal) = CalculateProgressTowardsGoals(userID)


        SendGoalNotifications(progressTowardsGoals)
        currentReport = "Daily Report"
    End Sub
    Private Sub DisplayBudgetAndExpenses(userID As Integer, selectedDate As Date)

        Dim query As String = "
        SELECT 
            B.BudgetDate, 
            B.BudgetAmount AS 'Budget Amount', 
            E.ExpenseDate,
            E.Amount AS 'Expense Amount', 
            E.Description 
        FROM 
            (SELECT DISTINCT CategoryID FROM Expense WHERE UserID = @userID) AS Categories
        LEFT JOIN 
            Budget B
        ON 
            Categories.CategoryID = B.CategoryID
            AND B.UserID = @userID 
            AND CONVERT(DATE, B.BudgetDate) = @selectedDate
        LEFT JOIN 
            Expense E
        ON 
            Categories.CategoryID = E.CategoryID
            AND E.UserID = @userID 
            AND CONVERT(DATE, E.ExpenseDate) = @selectedDate
        WHERE 
            (B.BudgetAmount IS NOT NULL OR E.Amount IS NOT NULL)
    "


        Dim mergedTable As New DataTable()


        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate)

                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(mergedTable)
            End Using
        End Using


        DataGridView2.DataSource = mergedTable
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

        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2)

        Dim startDate As Date = DateTime.Today.AddDays(-6)
        Dim endDate As Date = DateTime.Today


        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        DisplayWeeklyBudgetAndExpenses(userID, startDate, endDate)

        Dim weeklyBudgetData As Dictionary(Of Date, Decimal) = GetBudgetsForWeek(userID, startDate, endDate)


        Dim weeklyExpenseData As Dictionary(Of Date, Decimal) = GetExpensesForWeek(userID, startDate, endDate)


        GenerateColumnChart(Chart1, startDate, endDate, weeklyBudgetData, weeklyExpenseData)


        Dim progressTowardsGoals As Dictionary(Of String, Decimal) = CalculateProgressTowardsGoals(userID)


        SendGoalNotifications(progressTowardsGoals)
        currentReport = "Weekly Report"
    End Sub

    Private Sub DisplayWeeklyBudgetAndExpenses(userID As Integer, startDate As Date, endDate As Date)

        Dim query As String = "
        SELECT 
            B.BudgetDate, 
            COALESCE(B.BudgetAmount, 0) AS 'Budget Amount', 
            E.ExpenseDate,
            COALESCE(E.Amount, 0) AS 'Expense Amount', 
            E.Description 
        FROM 
            (SELECT DISTINCT CategoryID FROM Expense WHERE UserID = @userID) AS Categories
        LEFT JOIN 
            Budget B
        ON 
            Categories.CategoryID = B.CategoryID
            AND B.UserID = @userID 
            AND CONVERT(DATE, B.BudgetDate) BETWEEN @startDate AND @endDate
        LEFT JOIN 
            Expense E
        ON 
            Categories.CategoryID = E.CategoryID
            AND E.UserID = @userID 
            AND CONVERT(DATE, E.ExpenseDate) BETWEEN @startDate AND @endDate
        WHERE 
            (B.BudgetAmount IS NOT NULL OR E.Amount IS NOT NULL)
    "


        Dim mergedTable As New DataTable()


        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@startDate", startDate)
                cmd.Parameters.AddWithValue("@endDate", endDate)

                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(mergedTable)
            End Using
        End Using


        DataGridView2.DataSource = mergedTable
    End Sub


    Private Sub GenerateColumnChart(chart As Chart, selectedDate As Date, budgetData As Decimal, expenseData As Decimal)
        chart.Series.Clear()


        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column
        budgetSeries.Points.AddXY("Budget", budgetData)
        chart.Series.Add(budgetSeries)


        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column
        expenseSeries.Points.AddXY("Expense", expenseData)
        chart.Series.Add(expenseSeries)


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


        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column
        For Each kvp As KeyValuePair(Of Date, Decimal) In budgetData
            budgetSeries.Points.AddXY(kvp.Key.ToShortDateString(), kvp.Value)
        Next
        chart.Series.Add(budgetSeries)


        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column
        For Each kvp As KeyValuePair(Of Date, Decimal) In expenseData
            expenseSeries.Points.AddXY(kvp.Key.ToShortDateString(), kvp.Value)
        Next
        chart.Series.Add(expenseSeries)


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

        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2)


        Dim userID As Integer = GetUserIDByUsername(connectionString, username)


        Dim selectedMonth As Integer = DateTime.Today.Month
        Dim selectedYear As Integer = DateTime.Today.Year

        DisplayMonthlyBudgetAndExpenses(userID, selectedMonth, selectedYear)


        Dim monthlyBudgetData As Dictionary(Of Integer, Decimal) = GetMonthlyBudgetData(userID, selectedMonth, selectedYear)


        Dim monthlyExpenseData As Dictionary(Of Integer, Decimal) = GetMonthlyExpenseData(userID, selectedMonth, selectedYear)


        GenerateColumnChart(Chart1, monthlyBudgetData, monthlyExpenseData)


        Dim progressTowardsGoals As Dictionary(Of String, Decimal) = CalculateProgressTowardsGoals(userID)


        SendGoalNotifications(progressTowardsGoals)
        currentReport = "Monthly Report"
    End Sub

    Private Sub DisplayMonthlyBudgetAndExpenses(userID As Integer, selectedMonth As Integer, selectedYear As Integer)

        Dim query As String = "
        SELECT 
            B.BudgetDate, 
            COALESCE(B.BudgetAmount, 0) AS 'Budget Amount', 
            E.ExpenseDate,
            COALESCE(E.Amount, 0) AS 'Expense Amount', 
            E.Description 
        FROM 
            (SELECT DISTINCT CategoryID FROM Expense WHERE UserID = @userID) AS Categories
        LEFT JOIN 
            Budget B
        ON 
            Categories.CategoryID = B.CategoryID
            AND B.UserID = @userID 
            AND MONTH(CONVERT(DATE, B.BudgetDate)) = @selectedMonth
            AND YEAR(CONVERT(DATE, B.BudgetDate)) = @selectedYear
        LEFT JOIN 
            Expense E
        ON 
            Categories.CategoryID = E.CategoryID
            AND E.UserID = @userID 
            AND MONTH(CONVERT(DATE, E.ExpenseDate)) = @selectedMonth
            AND YEAR(CONVERT(DATE, E.ExpenseDate)) = @selectedYear
        WHERE 
            (B.BudgetAmount IS NOT NULL OR E.Amount IS NOT NULL)
    "


        Dim mergedTable As New DataTable()

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@selectedMonth", selectedMonth)
                cmd.Parameters.AddWithValue("@selectedYear", selectedYear)

                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(mergedTable)
            End Using
        End Using

        DataGridView2.DataSource = mergedTable
    End Sub

    Private Function GetMonthlyBudgetData(userID As Integer, month As Integer, year As Integer) As Dictionary(Of Integer, Decimal)
        Dim monthlyBudgetData As New Dictionary(Of Integer, Decimal)()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT SUM(BudgetAmount) AS TotalBudget FROM Budget WHERE UserID = @UserID AND MONTH(BudgetDate) = @Month AND YEAR(BudgetDate) = @Year"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@Month", month)
                    cmd.Parameters.AddWithValue("@Year", year)
                    Dim totalBudget As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    monthlyBudgetData(month) = totalBudget
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
                Dim query As String = "SELECT SUM(Amount) AS TotalExpense FROM Expense WHERE UserID = @UserID AND MONTH(ExpenseDate) = @Month AND YEAR(ExpenseDate) = @Year"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@Month", month)
                    cmd.Parameters.AddWithValue("@Year", year)
                    Dim totalExpense As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                    monthlyExpenseData(month) = totalExpense
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving monthly expense data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return monthlyExpenseData
    End Function

    Private Sub GenerateColumnChart(chart As Chart, budgetData As Dictionary(Of Integer, Decimal), expenseData As Dictionary(Of Integer, Decimal))
        chart.Series.Clear()


        Dim budgetSeries As New Series("Budget")
        budgetSeries.ChartType = SeriesChartType.Column


        For Each kvp As KeyValuePair(Of Integer, Decimal) In budgetData
            Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(kvp.Key)
            Dim budgetAmount As Decimal = kvp.Value
            budgetSeries.Points.AddXY(monthName, budgetAmount)
        Next

        chart.Series.Add(budgetSeries)


        Dim expenseSeries As New Series("Expense")
        expenseSeries.ChartType = SeriesChartType.Column


        For Each kvp As KeyValuePair(Of Integer, Decimal) In expenseData
            Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(kvp.Key)
            Dim expenseAmount As Decimal = kvp.Value
            expenseSeries.Points.AddXY(monthName, expenseAmount)
        Next

        chart.Series.Add(expenseSeries)


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

        Dim labelContent As String = Mainform.Login_info1.Text
        Dim username As String = labelContent.Substring(labelContent.IndexOf(":") + 2)


        Dim userID As Integer = GetUserIDByUsername(connectionString, username)

        Dim currentYear As Integer = DateTime.Today.Year

        DisplayYearlyBudgetAndExpenses(userID, currentYear)

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
        currentReport = "Yearly Overview"
    End Sub
    Private Sub DisplayYearlyBudgetAndExpenses(userID As Integer, selectedYear As Integer)
        ' Query to fetch budget amount and expense amount with description for each month in the selected year
        Dim query As String = "
    SELECT 
        MONTH_NUMBER.Month AS 'Month', 
        B.BudgetDate AS 'Budget Date',
        COALESCE(B.BudgetAmount, 0) AS 'Budget Amount', 
        E.ExpenseDate AS 'Expense Date',
        COALESCE(E.Amount, 0) AS 'Expense Amount', 
        E.Description 
    FROM 
        (
            SELECT 1 AS Month
            UNION SELECT 2
            UNION SELECT 3
            UNION SELECT 4
            UNION SELECT 5
            UNION SELECT 6
            UNION SELECT 7
            UNION SELECT 8
            UNION SELECT 9
            UNION SELECT 10
            UNION SELECT 11
            UNION SELECT 12
        ) AS MONTH_NUMBER
    LEFT JOIN 
        (
            SELECT MONTH(BudgetDate) AS Month, BudgetDate, BudgetAmount, CategoryID 
            FROM Budget 
            WHERE UserID = @userID AND YEAR(BudgetDate) = @selectedYear
        ) AS B
    ON 
        MONTH_NUMBER.Month = B.Month
    LEFT JOIN 
        (
            SELECT MONTH(ExpenseDate) AS Month, ExpenseDate, Amount, Description, CategoryID 
            FROM Expense 
            WHERE UserID = @userID AND YEAR(ExpenseDate) = @selectedYear
        ) AS E
    ON 
        MONTH_NUMBER.Month = E.Month
    WHERE 
        (B.BudgetAmount IS NOT NULL OR E.Amount IS NOT NULL)
    ORDER BY 
        'Month' ASC
    "

        ' Create a new DataTable to hold the merged data
        Dim yearlyMergedTable As New DataTable()

        ' Execute the query and fill the DataTable
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@selectedYear", selectedYear)

                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(yearlyMergedTable)
            End Using
        End Using

        ' Bind the merged data to DataGridView2
        DataGridView2.DataSource = yearlyMergedTable
    End Sub

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

    Private Sub Print_btn_Click(sender As Object, e As EventArgs) Handles Print_btn.Click
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintPageHandler
        Dim previewDialog As New PrintPreviewDialog()
        previewDialog.Document = pd
        previewDialog.ShowIcon = False
        If previewDialog.ShowDialog() = DialogResult.OK Then
            pd.Print()
        End If
    End Sub

    Private rowIndex As Integer = 0 ' Variable to track the index of the current row being printed
    Private printedRowIndex As Integer = 0

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        ' Set the origin at the upper-left corner of the printing page
        Dim startX As Integer = e.MarginBounds.Left
        Dim startY As Integer = e.MarginBounds.Top

        ' Print the chart at the top of the page
        Dim chartBitmap As New Bitmap(Chart1.Width, Chart1.Height)
        Chart1.DrawToBitmap(chartBitmap, New Rectangle(0, 0, Chart1.Width, Chart1.Height))
        e.Graphics.DrawImage(chartBitmap, startX, startY)

        ' Print the report title below the chart
        Dim reportTitle As String = GetReportTitle()
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        startY += chartBitmap.Height + 50 ' Add spacing below the chart
        e.Graphics.DrawString(reportTitle, font, brush, startX, startY)

        ' Adjust startY for the DataGridView
        startY += e.Graphics.MeasureString(reportTitle, font).Height + 20 ' Add spacing below the report title

        ' Draw column headers
        For Each column As DataGridViewColumn In DataGridView2.Columns
            Dim headerBounds As New Rectangle(startX, startY, column.Width, DataGridView2.ColumnHeadersHeight)
            e.Graphics.DrawString(column.HeaderText, DataGridView2.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, headerBounds)
            startX += column.Width
        Next

        ' Adjust startY for the data rows
        startY += DataGridView2.ColumnHeadersHeight

        ' Calculate the available height for the DataGridView
        Dim availableHeight As Integer = e.MarginBounds.Height - startY

        ' Print the DataGridView onto the print page
        Dim rowsPerPage As Integer = availableHeight \ DataGridView2.RowTemplate.Height
        Dim rowCounter As Integer = 0

        While rowIndex < DataGridView2.RowCount AndAlso rowCounter < rowsPerPage
            Dim row As DataGridViewRow = DataGridView2.Rows(rowIndex)
            startX = e.MarginBounds.Left ' Reset startX for each row
            For Each cell As DataGridViewCell In row.Cells
                Dim cellBounds As New Rectangle(startX, startY + rowCounter * DataGridView2.RowTemplate.Height, cell.Size.Width, cell.Size.Height)
                e.Graphics.DrawString(cell.FormattedValue.ToString(), DataGridView2.Font, Brushes.Black, cellBounds)
                startX += cell.Size.Width
            Next
            rowCounter += 1
            startY += DataGridView2.RowTemplate.Height ' Move to the next row
            rowIndex += 1 ' Move to the next row index
        End While

        ' Check if there are more rows to print
        If rowIndex < DataGridView2.RowCount Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            rowIndex = 0 ' Reset rowIndex for the next print job
        End If
    End Sub



    Private Sub DrawDataGridView(ByVal dgv As DataGridView, ByVal g As Graphics, ByVal printArea As Rectangle)
        ' Set up pens and brushes
        Dim gridPen As New Pen(dgv.GridColor)
        Dim headerFont As Font = dgv.ColumnHeadersDefaultCellStyle.Font
        Dim cellFont As Font = dgv.DefaultCellStyle.Font
        Dim headerBrush As New SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor)
        Dim cellBrush As New SolidBrush(dgv.DefaultCellStyle.ForeColor)

        ' Calculate row height
        Dim rowHeight As Integer = dgv.RowTemplate.Height

        ' Draw column headers
        Dim x As Integer = printArea.Left
        Dim y As Integer = printArea.Top
        For Each col As DataGridViewColumn In dgv.Columns
            If x < printArea.Right Then
                g.DrawString(col.HeaderText, headerFont, headerBrush, x, y)
                x += col.Width
            End If
        Next

        ' Draw rows
        y += rowHeight
        Dim startRowIndex As Integer = printedRowIndex
        Dim endRowIndex As Integer = Math.Min(startRowIndex + (printArea.Height - y) \ rowHeight, dgv.RowCount - 1)

        For i As Integer = startRowIndex To endRowIndex
            x = printArea.Left
            For j As Integer = 0 To dgv.Columns.Count - 1
                If x < printArea.Right Then
                    Dim cellValue As String = dgv.Rows(i).Cells(j).FormattedValue.ToString()
                    g.DrawString(cellValue, cellFont, cellBrush, x, y)
                    x += dgv.Columns(j).Width
                End If
            Next
            y += rowHeight
        Next

        ' Draw grid lines
        x = printArea.Left
        y = printArea.Top + rowHeight
        For Each col As DataGridViewColumn In dgv.Columns
            If x < printArea.Right Then
                g.DrawLine(gridPen, x, printArea.Top, x, printArea.Bottom)
                x += col.Width
            End If
        Next
        x = printArea.Left
        For i As Integer = startRowIndex To endRowIndex
            If y < printArea.Bottom Then
                g.DrawLine(gridPen, printArea.Left, y, printArea.Right, y)
                y += rowHeight
            Else
                Exit For
            End If
        Next

        printedRowIndex = endRowIndex + 1
    End Sub


    Private Function GetReportTitle() As String
        Return currentReport
    End Function

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class
