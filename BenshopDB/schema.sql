-- ============================================================
-- BenshopDB — Full Database Schema
-- ============================================================

-- Users table
CREATE TABLE Users (
    UserID       INT PRIMARY KEY IDENTITY,
    Username     NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    FullName     NVARCHAR(100),
    Phone        NVARCHAR(20),
    Role         NVARCHAR(10) NOT NULL CHECK (Role IN ('Buyer', 'Seller')),
    CreatedAt    DATETIME DEFAULT GETDATE()
);

-- Products table
CREATE TABLE Products (
    ProductID    INT PRIMARY KEY IDENTITY,
    Name         NVARCHAR(100) NOT NULL,
    Category     NVARCHAR(50),
    Price        DECIMAL(18,2) NOT NULL,
    Stock        INT NOT NULL DEFAULT 0,
    ImagePath    NVARCHAR(255),
    IsActive     BIT DEFAULT 1,
    CreatedAt    DATETIME DEFAULT GETDATE()
);

-- Promo codes table
CREATE TABLE PromoCodes (
    PromoID      INT PRIMARY KEY IDENTITY,
    Code         NVARCHAR(30) UNIQUE NOT NULL,
    DiscountType NVARCHAR(10) NOT NULL CHECK (DiscountType IN ('Percent', 'Fixed')),
    DiscountVal  DECIMAL(18,2) NOT NULL,
    ValidFrom    DATE,
    ValidUntil   DATE,
    UsageCount   INT DEFAULT 0,
    IsActive     BIT DEFAULT 1
);

-- Transactions header table
CREATE TABLE Transactions (
    TransactionID   INT PRIMARY KEY IDENTITY,
    TransactionNo   NVARCHAR(20) UNIQUE NOT NULL,
    BuyerID         INT FOREIGN KEY REFERENCES Users(UserID),
    PromoID         INT FOREIGN KEY REFERENCES PromoCodes(PromoID) NULL,
    Subtotal        DECIMAL(18,2),
    DiscountAmount  DECIMAL(18,2) DEFAULT 0,
    Total           DECIMAL(18,2),
    PaymentMethod   NVARCHAR(20),
    Status          NVARCHAR(20) DEFAULT 'Diproses',
    RecipientName   NVARCHAR(100),
    RecipientPhone  NVARCHAR(20),
    ShippingAddress NVARCHAR(255),
    CreatedAt       DATETIME DEFAULT GETDATE()
);

-- Transaction detail / line items
CREATE TABLE TransactionDetails (
    DetailID      INT PRIMARY KEY IDENTITY,
    TransactionID INT FOREIGN KEY REFERENCES Transactions(TransactionID),
    ProductID     INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity      INT NOT NULL,
    UnitPrice     DECIMAL(18,2) NOT NULL,
    Subtotal      DECIMAL(18,2)
);

-- ============================================================
-- Views for Crystal Reports
-- ============================================================
GO

-- Daily / monthly summary view
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

-- Top products view
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

-- Profit trend view (monthly)
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
