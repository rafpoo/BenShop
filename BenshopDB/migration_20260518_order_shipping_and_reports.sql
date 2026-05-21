IF COL_LENGTH('Transactions', 'RecipientName') IS NULL
    ALTER TABLE Transactions ADD RecipientName NVARCHAR(100) NULL;
GO

IF COL_LENGTH('Transactions', 'RecipientPhone') IS NULL
    ALTER TABLE Transactions ADD RecipientPhone NVARCHAR(20) NULL;
GO

IF COL_LENGTH('Transactions', 'ShippingAddress') IS NULL
    ALTER TABLE Transactions ADD ShippingAddress NVARCHAR(255) NULL;
GO

IF OBJECT_ID('vw_TransactionSummary', 'V') IS NOT NULL
    DROP VIEW vw_TransactionSummary;
GO

CREATE VIEW vw_TransactionSummary AS
SELECT
    CAST(CreatedAt AS DATE)       AS TxDate,
    DATENAME(MONTH, CreatedAt)    AS MonthName,
    YEAR(CreatedAt)               AS TxYear,
    COUNT(*)                      AS TotalTransactions,
    SUM(Subtotal)                 AS TotalSubtotal,
    SUM(DiscountAmount)           AS TotalDiscount,
    SUM(Total)                    AS TotalRevenue
FROM Transactions
WHERE ISNULL(Status, '') <> 'Dibatalkan'
GROUP BY CAST(CreatedAt AS DATE), DATENAME(MONTH, CreatedAt), YEAR(CreatedAt);
GO

IF OBJECT_ID('vw_TopProducts', 'V') IS NOT NULL
    DROP VIEW vw_TopProducts;
GO

CREATE VIEW vw_TopProducts AS
SELECT
    p.ProductID,
    p.Name,
    p.Category,
    SUM(td.Quantity)    AS TotalSold,
    SUM(td.Subtotal)    AS TotalRevenue
FROM TransactionDetails td
JOIN Products p ON td.ProductID = p.ProductID
JOIN Transactions t ON td.TransactionID = t.TransactionID
WHERE ISNULL(t.Status, '') <> 'Dibatalkan'
GROUP BY p.ProductID, p.Name, p.Category;
GO

IF OBJECT_ID('vw_ProfitTrend', 'V') IS NOT NULL
    DROP VIEW vw_ProfitTrend;
GO

CREATE VIEW vw_ProfitTrend AS
SELECT
    YEAR(CreatedAt)               AS TxYear,
    MONTH(CreatedAt)              AS TxMonth,
    DATENAME(MONTH, CreatedAt)    AS MonthName,
    SUM(Total)                    AS Revenue,
    COUNT(*)                      AS Transactions
FROM Transactions
WHERE ISNULL(Status, '') <> 'Dibatalkan'
GROUP BY YEAR(CreatedAt), MONTH(CreatedAt), DATENAME(MONTH, CreatedAt);
GO
