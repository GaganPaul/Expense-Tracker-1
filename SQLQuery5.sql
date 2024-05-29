if OBJECT_ID('Budget..#temp') IS Not NULL
Drop Table Budget;
if OBJECT_ID('Expense..#temp') IS Not NULL
Drop Table Expense;
if OBJECT_ID('UserCustomCategory..#temp') IS Not NULL
Drop Table UserCustomCategory;
if OBJECT_ID('Category..#temp') IS Not NULL
Drop table Category;
if OBJECT_ID('[users]..#temp') IS Not NULL
Drop table [users];

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
    FOREIGN KEY (UserID) REFERENCES users(UserID),
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE
);

-- Create the Budget table
CREATE TABLE Budget (
    BudgetID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    CategoryID INT,
    IsPredefined BIT, -- New column to indicate if the category is predefined (1) or user-defined (0)
    BudgetAmount DECIMAL(10, 2),
    CONSTRAINT FK_Budget_User FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT FK_Budget_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE
);

CREATE TABLE FinancialGoals (
    GoalID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    GoalName NVARCHAR(255),
    TargetAmount DECIMAL(10, 2),
    TargetDate DATE,
    CONSTRAINT FK_FinancialGoals_User FOREIGN KEY (UserID) REFERENCES [users](UserID) ON DELETE CASCADE
);

CREATE TABLE ExpenseToGoal (
    ExpenseID INT,
    GoalID INT,
    CONSTRAINT PK_ExpenseToGoal PRIMARY KEY (ExpenseID, GoalID),
    CONSTRAINT FK_ExpenseID FOREIGN KEY (ExpenseID) REFERENCES Expense(ExpenseID),
    CONSTRAINT FK_GoalID FOREIGN KEY (GoalID) REFERENCES FinancialGoals(GoalID) ON DELETE CASCADE
);

-- Trigger for the User table
CREATE TRIGGER ResetUserID
ON [users]
AFTER DELETE
AS
BEGIN
    -- Check if the number of rows in the User table is zero
    IF NOT EXISTS (SELECT 1 FROM users)
    BEGIN
        -- Reset the identity seed to 1
        DBCC CHECKIDENT ('[users]', RESEED, 1);
    END
END
GO

-- Trigger for the Budget table
CREATE TRIGGER ResetBudgetID
ON Budget
AFTER DELETE
AS
BEGIN
    -- Check if the number of rows in the Budget table is zero
    IF NOT EXISTS (SELECT 1 FROM Budget)
    BEGIN
        -- Reset the identity seed to 1
        DBCC CHECKIDENT ('Budget', RESEED, 1);
    END
END
GO

-- Trigger for the Category table
CREATE TRIGGER ResetCategoryID
ON Category
AFTER DELETE
AS
BEGIN
    -- Check if the number of rows in the Category table is zero
    IF NOT EXISTS (SELECT 1 FROM Category)
    BEGIN
        -- Reset the identity seed to 1
        DBCC CHECKIDENT ('Category', RESEED, 1);
    END
END
GO

-- Trigger for the Expense table
CREATE TRIGGER ResetExpenseID
ON Expense
AFTER DELETE
AS
BEGIN
    -- Check if the number of rows in the Expense table is zero
    IF NOT EXISTS (SELECT 1 FROM Expense)
    BEGIN
        -- Reset the identity seed to 1
        DBCC CHECKIDENT ('Expense', RESEED, 1);
    END
END
GO

CREATE TRIGGER ResetFinancialGoalsIDSeed ON FinancialGoals
AFTER DELETE
AS
BEGIN
    -- Check if the table is empty after the delete operation
    IF NOT EXISTS (SELECT 1 FROM FinancialGoals)
    BEGIN
        -- Reset the identity column seed to 1
        DBCC CHECKIDENT ('FinancialGoals', RESEED, 0);
    END
END
GO




SELECT TOP (1000) [UserID]
      ,[Username]
      ,[Password]
  FROM [expense].[dbo].[users]

SELECT TOP (1000) [CategoryID]
      ,[CategoryName]
      ,[IsPredefined]
      ,[CreatedByUserID]
  FROM [expense].[dbo].[Category]

SELECT TOP (1000) [BudgetID]
      ,[UserID]
      ,[CategoryID]
      ,[IsPredefined]
      ,[BudgetAmount]
      ,[BudgetDate]
  FROM [expense].[dbo].[Budget]

  select * from ExpenseToGoal;

SELECT TOP (1000) [ExpenseID]
      ,[UserID]
      ,[CategoryID]
      ,[ExpenseDate]
      ,[Amount]
      ,[Description]
  FROM [expense].[dbo].[Expense]

DBCC CHECKIDENT ('[users]', RESEED, 1);
DBCC CHECKIDENT ('Category', RESEED, 1);
DBCC CHECKIDENT ('Expense', RESEED, 1);
DBCC CHECKIDENT ('Budget', RESEED, 1);
DBCC CHECKIDENT ('UserCustomCategory', RESEED, 1);

ALTER TABLE Category
ADD CreatedByUserID INT;

INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Groceries', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Utilities', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Transportation', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Insurance', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Savings', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Miscellaneous', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Housing', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Entertainment', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Healthcare', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Education', 1);
INSERT INTO Category (CategoryName, IsPredefined) VALUES ('Clothing', 1);

ALTER TABLE [expense].[dbo].[Budget]
ADD BudgetDate DATE;

drop table ExpenseToGoal;
drop table FinancialGoals;

ALTER TABLE Category
ADD CONSTRAINT UQ_Category_User UNIQUE (CategoryName, CreatedByUserID);

select * from Category;
DELETE FROM Category
WHERE CategoryID = 41;

ALTER TABLE Category
DROP COLUMN UserID;