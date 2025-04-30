-- ��������� ������������� ���� ������
IF DB_ID('MasterFloorDB') IS NOT NULL
BEGIN
    USE master;
    ALTER DATABASE MasterFloorDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MasterFloorDB;
END
GO

-- ������� ����� ���� ������
CREATE DATABASE MasterFloorDB;
GO

USE MasterFloorDB;
GO

-- ������� ������������ �������, ���� ��� ����
IF EXISTS (SELECT * FROM sys.views WHERE name = 'PartnerSalesSummary')
    DROP VIEW PartnerSalesSummary;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'UpdatePartnerDiscount')
    DROP PROCEDURE UpdatePartnerDiscount;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'AddNewSale')
    DROP PROCEDURE AddNewSale;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'GetPartnerSalesHistory')
    DROP PROCEDURE GetPartnerSalesHistory;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'SalesHistory')
    DROP TABLE SalesHistory;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Partner')
    DROP TABLE Partner;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Product')
    DROP TABLE Product;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'PartnerType')
    DROP TABLE PartnerType;
GO

-- ������� ������� ������
CREATE TABLE PartnerType (
    TypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) NOT NULL
);

CREATE TABLE Partner (
    PartnerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    TypeID INT FOREIGN KEY REFERENCES PartnerType(TypeID),
    Rating INT NOT NULL DEFAULT 0,
    Address NVARCHAR(255),
    DirectorFullName NVARCHAR(150),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    TotalSalesAmount DECIMAL(18,2) DEFAULT 0,
    Discount DECIMAL(5,2) DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT CHK_Rating CHECK (Rating >= 0),
    CONSTRAINT CHK_Email CHECK (Email LIKE '%@%.%')
);

CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ArticleNumber NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    MinPrice DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT CHK_MinPrice CHECK (MinPrice >= 0)
);

CREATE TABLE SalesHistory (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    PartnerID INT FOREIGN KEY REFERENCES Partner(PartnerID),
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
    Quantity INT NOT NULL,
    SaleDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2) NOT NULL,
    CONSTRAINT CHK_Quantity CHECK (Quantity > 0),
    CONSTRAINT CHK_TotalAmount CHECK (TotalAmount >= 0)
);
GO

-- ��������� ��������� ������
INSERT INTO PartnerType (TypeName) VALUES 
    (N'��������� �������'),
    (N'������� �������'),
    (N'��������-�������'),
    (N'������������ ��������');
GO

-- ��������� �������� ��������
INSERT INTO Product (ArticleNumber, Name, Description, MinPrice) VALUES
    ('FL001_NEW', N'������� Classic', N'������������ ������� 32 ������', 899.00),
    ('FL002_NEW', N'������ �������', N'����������� ������� ������', 2499.00),
    ('FL003_NEW', N'�������� Premium', N'������������� ��������', 599.00),
    ('FL004_NEW', N'�������� Office', N'������������ ��������', 799.00);
GO

-- ��������� �������� ���������
INSERT INTO Partner (Name, TypeID, Rating, Address, DirectorFullName, Phone, Email) VALUES
    (N'��� "�����������"', 1, 5, N'�. ������, ��. ����������, 15', N'������ ���� ��������', '+7(900)123-45-67', 'info@stroymarket.ru'),
    (N'�� ������', 2, 4, N'�. �����-���������, ��. �������, 100', N'������ ���� ��������', '+7(900)234-56-78', 'petrov@mail.ru'),
    (N'FloorOnline', 3, 5, N'�. ������, ��. �����������, 1', N'������� ������� ������������', '+7(900)345-67-89', 'sales@flooronline.ru');
GO

-- ��������� �������� ������� ������ � ����������� ������
INSERT INTO SalesHistory (PartnerID, ProductID, Quantity, SaleDate, TotalAmount)
SELECT 1, 1, 100, DATEADD(day, -15, GETDATE()), 89900.00
UNION ALL
SELECT 1, 2, 50, DATEADD(day, -10, GETDATE()), 124950.00
UNION ALL
SELECT 2, 3, 200, DATEADD(day, -5, GETDATE()), 119800.00
UNION ALL
SELECT 3, 4, 150, DATEADD(day, -1, GETDATE()), 119850.00;
GO

-- ������� ������������� ��� ������ �� ���������
CREATE VIEW PartnerSalesSummary AS
SELECT 
    p.PartnerID,
    p.Name AS PartnerName,
    pt.TypeName AS PartnerType,
    p.Rating,
    COUNT(sh.SaleID) AS TotalSales,
    SUM(sh.TotalAmount) AS TotalAmount,
    p.Discount AS CurrentDiscount
FROM Partner p
JOIN PartnerType pt ON p.TypeID = pt.TypeID
LEFT JOIN SalesHistory sh ON p.PartnerID = sh.PartnerID
GROUP BY p.PartnerID, p.Name, pt.TypeName, p.Rating, p.Discount;
GO

-- ������� ��������� ���������� ������ ��������
CREATE PROCEDURE UpdatePartnerDiscount
    @PartnerID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TotalAmount DECIMAL(18,2)
    
    SELECT @TotalAmount = ISNULL(SUM(TotalAmount), 0)
    FROM SalesHistory
    WHERE PartnerID = @PartnerID;

    UPDATE Partner
    SET 
        Discount = 
            CASE 
                WHEN @TotalAmount >= 300000 THEN 15
                WHEN @TotalAmount >= 50000 THEN 10
                WHEN @TotalAmount >= 10000 THEN 5
                ELSE 0
            END,
        TotalSalesAmount = @TotalAmount
    WHERE PartnerID = @PartnerID;

    SELECT 
        p.PartnerID,
        p.Name,
        p.TotalSalesAmount,
        p.Discount
    FROM Partner p
    WHERE p.PartnerID = @PartnerID;
END;
GO

-- ������� ��������� ���������� ����� �������
CREATE PROCEDURE AddNewSale
    @PartnerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MinPrice DECIMAL(18,2);
    SELECT @MinPrice = MinPrice FROM Product WHERE ProductID = @ProductID;
    
    INSERT INTO SalesHistory (PartnerID, ProductID, Quantity, TotalAmount)
    VALUES (@PartnerID, @ProductID, @Quantity, @MinPrice * @Quantity);
    
    EXEC UpdatePartnerDiscount @PartnerID;
    
    SELECT 
        sh.SaleID,
        p.Name AS PartnerName,
        pr.Name AS ProductName,
        sh.Quantity,
        sh.TotalAmount,
        sh.SaleDate
    FROM SalesHistory sh
    JOIN Partner p ON sh.PartnerID = p.PartnerID
    JOIN Product pr ON sh.ProductID = pr.ProductID
    WHERE sh.SaleID = SCOPE_IDENTITY();
END;
GO

-- ������� ��������� ��������� ������� ������ ��������
CREATE PROCEDURE GetPartnerSalesHistory
    @PartnerID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        sh.SaleID,
        p.Name AS ProductName,
        sh.Quantity,
        sh.TotalAmount,
        sh.SaleDate
    FROM SalesHistory sh
    JOIN Product p ON sh.ProductID = p.ProductID
    WHERE sh.PartnerID = @PartnerID
    ORDER BY sh.SaleDate DESC;
END;
GO

-- ������� ������� ��� �����������
CREATE INDEX IX_SalesHistory_PartnerID ON SalesHistory(PartnerID);
CREATE INDEX IX_SalesHistory_ProductID ON SalesHistory(ProductID);
CREATE INDEX IX_Partner_TypeID ON Partner(TypeID);
GO