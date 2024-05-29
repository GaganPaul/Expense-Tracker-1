CREATE TABLE [users] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Username UNIQUE (Username)
);


CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(255) NOT NULL,
    IsPredefined BIT NOT NULL DEFAULT 0,
    CreatedByUserID INT, -- Add column to track the user who created the category
    CONSTRAINT FK_Category_User FOREIGN KEY (CreatedByUserID) REFERENCES [users](UserID) ON DELETE CASCADE
);


-- Create the Expense table
CREATE TABLE Expense (
    ExpenseID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    CategoryID INT,
    ExpenseDate DATE,
    Amount DECIMAL(10, 2),
    Description NVARCHAR(255),
    CONSTRAINT FK_Expense_User FOREIGN KEY (UserID) REFERENCES users(UserID) ON DELETE CASCADE, -- Update foreign key constraint
    CONSTRAINT FK_Expense_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE -- Update foreign key constraint
);

-- Create the Budget table
CREATE TABLE Budget (
    BudgetID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    CategoryID INT,
    IsPredefined BIT, -- New column to indicate if the category is predefined (1) or user-defined (0)
    BudgetAmount DECIMAL(10, 2),
    CONSTRAINT FK_Budget_User FOREIGN KEY (UserID) REFERENCES users(UserID) ON DELETE CASCADE, -- Update foreign key constraint
    CONSTRAINT FK_Budget_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE -- Update foreign key constraint
);

CREATE TABLE FinancialGoals (
    GoalID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    GoalName NVARCHAR(255),
    TargetAmount DECIMAL(10, 2),
    TargetDate DATE,
    CONSTRAINT FK_FinancialGoals_User FOREIGN KEY (UserID) REFERENCES [users](UserID) ON DELETE CASCADE -- Update foreign key constraint
);

CREATE TABLE ExpenseToGoal (
    ExpenseID INT,
    GoalID INT,
    CONSTRAINT PK_ExpenseToGoal PRIMARY KEY (ExpenseID, GoalID),
    CONSTRAINT FK_ExpenseToGoal_Expense FOREIGN KEY (ExpenseID) REFERENCES Expense(ExpenseID) ON DELETE CASCADE, -- Update foreign key constraint
    CONSTRAINT FK_ExpenseToGoal_Goal FOREIGN KEY (GoalID) REFERENCES FinancialGoals(GoalID) ON DELETE CASCADE -- Update foreign key constraint
);


drop table Category;
drop table FinancialGoals;