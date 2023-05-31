--CREATE DATABASE GameShop_DB

--USE GameShop_DB

-- ���� ��������
CREATE TABLE Categories_TBL
(
	CategoryId INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(255) NOT NULL,
	isDelete BIT NOT NULL,
)
GO

-- ���� ������
CREATE TABLE Products_TBL
(
	ProductId INT PRIMARY KEY IDENTITY(1, 1),
	ProductName VARCHAR(255) NOT NULL,
	ProductPrice DECIMAL(10, 2) NOT NULL,
	ProductPic VARCHAR(255) NOT NULL,
	QuantityInStock INT NOT NULL,
	isDelete BIT NOT NULL,
	CategoryId INT REFERENCES Categories_TBL NOT NULL
)
GO

-- ���� �������
CREATE TABLE Users_TBL
(
	UserId INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	UserPhone VARCHAR(25),
	UserEmail VARCHAR(255) NOT NULL,
	UserPassword VARCHAR(255) NOT NULL,
	UserAddress VARCHAR(255),
)
GO

-- ���� ������
CREATE TABLE Orders_TBL
(
	OrderId INT PRIMARY KEY IDENTITY(1, 1),
	OrderDate DATETIME NOT NULL,
	UserId INT REFERENCES Users_TBL NOT NULL,
	FinalPrice DECIMAL(10, 2) NOT NULL,
)
GO

-- ���� ���� ������
CREATE TABLE BuyingsDetails_TBL
(
	BuyingDetailesId INT PRIMARY KEY IDENTITY(1, 1),
	ProductId INT REFERENCES Products_TBL NOT NULL,
	OrderId INT REFERENCES Orders_TBL NOT NULL,
	Quantity INT DEFAULT(1) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
)
GO

--drop table BuyingsDetails_TBL
--drop table Orders_TBL
--drop table Products_TBL
--drop table Categories_TBL
--drop table Users_TBL

------------------------------------------------
INSERT INTO Categories_TBL
VALUES ('����� ������� ����', 0)
GO

INSERT INTO Categories_TBL
VALUES ('����� �����', 0)
GO

INSERT INTO Categories_TBL
VALUES ('����� ����� �������', 0)
GO

INSERT INTO Categories_TBL
VALUES ('������� ����� ������� �������', 0)
GO

INSERT INTO Categories_TBL
VALUES ('���� �� ����� ���� ���', 0)
GO

------------------------------------------------
INSERT INTO Products_TBL
VALUES ('���� ����', 150, 'childhood-teddy-retro-white-memorabilia.jpg', 20, 0, 1)
GO

INSERT INTO Products_TBL
VALUES ('����� �������', 50, 'colorful-toy-constructions.jpg', 20, 0, 2)
GO

INSERT INTO Products_TBL
VALUES ('����� �����', 99.5, 'child-toys-still-life.jpg', 20, 0, 4)
GO

INSERT INTO Products_TBL
VALUES ('��� �������', 200, 'two-teddy-bears-wood-background.jpg', 20, 0, 1)
GO

INSERT INTO Products_TBL
VALUES ('����', 115, 'closeup-shot-chess-figurines-chessboard.jpg', 20, 0, 2)
GO

INSERT INTO Products_TBL
VALUES ('���� �����', 75, 'vivid-paints-coloring-easter-eggs.jpg', 20, 0, 3)
GO

INSERT INTO Products_TBL
VALUES ('���� ����', 60, 'front-view-different-colorful.jpg', 20, 0, 5)
GO

INSERT INTO Products_TBL
VALUES ('�������', 45, 'different-type-paintbrush-house-model.jpg', 20, 0, 3)
GO

INSERT INTO Products_TBL
VALUES ('������ ���� ����', 70, 'building-blocks-wooden-background-colorful.jpg', 20, 0, 4)
GO

INSERT INTO Products_TBL
VALUES ('����� ���� ���', 300, 'close-up-school-bag-with-books-stationery.jpg', 20, 0, 5)
GO

------------------------------------------------
INSERT INTO Users_TBL
VALUES ('���', '�����', '058-322-0353', 'malkin.yaeli@gmail.com', 'Ym214100', '��� ���')
GO

INSERT INTO Users_TBL
VALUES ('���', '�����', '050-412-1107', 'chany.malkin@gmail.com', 'Cm217633', '��� ���')
GO

------------------------------------------------
INSERT INTO Orders_TBL
VALUES ('2022-12-14 19:04:10', 1, 350)
GO

INSERT INTO Orders_TBL
VALUES ('2022-12-14 18:08:05', 1, 115)
GO

INSERT INTO Orders_TBL
VALUES ('2022-12-15 13:14:10', 2, 420)
GO

------------------------------------------------
INSERT INTO BuyingsDetails_TBL(ProductId, OrderId, Quantity, Price)
VALUES (1, 1, 2, 300)
GO

INSERT INTO BuyingsDetails_TBL
VALUES (2, 1, 1, 50)
GO

INSERT INTO BuyingsDetails_TBL
VALUES (8, 2, 1, 45)
GO

INSERT INTO BuyingsDetails_TBL
VALUES (9, 2, 1, 70)
GO

INSERT INTO BuyingsDetails_TBL
VALUES (7, 3, 2, 120)
GO

INSERT INTO BuyingsDetails_TBL
VALUES (10, 3, 1, 300)
GO

