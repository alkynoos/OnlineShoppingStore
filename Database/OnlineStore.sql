CREATE DATABASE dbMyOnlineShopping
GO
USE dbMyOnlineShopping
GO

CREATE TABLE Category(

CategoryId INT IDENTITY PRIMARY KEY,
CategoryName VARCHAR(500) UNIQUE,
IsActive BIT NULL,
IsDelete BIT NULL
)

CREATE TABLE Product(
ProductId INT IDENTITY PRIMARY KEY,
ProductName VARCHAR(500) UNIQUE,
CategoryId INT,
IsActive BIT NULL,
IsDelete BIT NULL,
CreatedDate DATETIME NULL,
ModifiedDate DATETIME NULL,
Description VARCHAR(50) NULL,
ProductImage VARCHAR (MAX),
IsFeatured BIT NULL,
Quantity INT
FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
)

CREATE TABLE CartStatus(
CartStatusId INT IDENTITY PRIMARY KEY,
CartStatus VARCHAR(500)
)
 
 CREATE TABLE Members(
MemberId INT IDENTITY PRIMARY KEY,
FristName VARCHAR(200),
LastName VARCHAR(200) UNIQUE,
EmailId VARCHAR(200) UNIQUE,
Password VARCHAR(500),
IsActive BIT NULL,
IsDelete BIT NULL,
CreatedOn DATETIME,
ModifiedOn DATETIME
)

 CREATE TABLE ShippingDetails(
ShippingDetailId INT IDENTITY PRIMARY KEY,
MemberId INT,
Adress VARCHAR(500),
City VARCHAR(500),
State VARCHAR (500),
Country VARCHAR(50),
ZipCode VARCHAR(50),
OrderId INT,
AmountPaid DECIMAL,
PaymentType VARCHAR(50)
FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
)



CREATE TABLE Roles(
RoleId INT IDENTITY PRIMARY KEY,
RoleName VARCHAR(200) UNIQUE
)


CREATE TABLE Cart(
CartId INT PRIMARY KEY,
ProductId INT,
MemberId INT,
CartStatusId INT
FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
)

CREATE TABLE MemberRole(
MemberRoleID INT IDENTITY PRIMARY KEY,
memberId INT,
RoleId INT
)
 

CREATE TABLE SlideImage(
SlideId INT IDENTITY PRIMARY KEY,
SlideTitle VARCHAR(500),
SlideImage VARCHAR(MAX)
)



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,> GetBySearch 'PINK FLOYED'
-- =============================================
CREATE PROCEDURE GetBySearch
		@search NVARCHAR(MAX) = NULL
	
AS
BEGIN
	
	SELECT * FROM [dbo].[Product] P 
	LEFT JOIN [dbo].[Category] C ON P.CategoryId = C.CategoryId
	WHERE
	P.ProductName LIKE CASE WHEN @search IS NOT NULL THEN '%' +@search+'%' ELSE P.ProductName END
	OR
	C.CategoryName LIKE CASE WHEN @search IS NOT NULL THEN '%' +@search+'%' ELSE c.CategoryName END
END
GO