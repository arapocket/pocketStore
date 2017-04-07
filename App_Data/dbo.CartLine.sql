CREATE TABLE [dbo].[CartLine]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductID] INT NOT NULL, 
    [ProductName] CHAR(50) NOT NULL, 
    [ProductNo] CHAR(10) NOT NULL, 
    [Price] NUMERIC(7, 2) NOT NULL, 
    [CartID] CHAR(10) NOT NULL, 
    [Quantity] INT NOT NULL
)
