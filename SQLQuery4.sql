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