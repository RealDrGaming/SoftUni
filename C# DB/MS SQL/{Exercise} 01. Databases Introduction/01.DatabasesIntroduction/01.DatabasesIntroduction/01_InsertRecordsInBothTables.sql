CREATE DATABASE [Minions]

USE [Minions]

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(10) NOT NULL,
	[Age] TINYINT,
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

-- 04. Insert records in both tables

INSERT INTO [Towns]([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM [Towns]
SELECT * FROM [Minions]

-- 07. Create table people

CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX),
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
('Gosho', NULL, NULL, 'm', '1976-06-21'),
('Ivan', 2.07, 103.4, 'm', '1993-07-15'),
('Petur', 1.71, 73.0, 'm', '1969-09-25'),
('Yordan', 1.80, 67.5, 'm', '2006-09-05')

SELECT * FROM [People]

-- 08. Create Table Users

CREATE TABLE [Users] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900 * 1024),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5) NOT NULL,
	CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
	VALUES
('RealDrGaming', '123456789', NULL, 'false'),
('BiggusBrainus', 'bfiagvre', NULL, 'true'),
('Titinko_man', '15154gvew', NULL, 'true'),
('Esibe_03', 'verw1grw', NULL, 'false'),
('Stanislav4o', '1f546wvwer', NULL, 'false')

SELECT * FROM [Users]

-- 13. Movies Database

CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Directors]([DirectorName], [Notes])
	VALUES
('Ivan Rashinski', NULL),
('Quentin Tarantino', NULL),
('Lucas', NULL),
('Steven Spielberg', NULL),
('Silvester Stalone', NULL)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Genres]([GenreName], [Notes])
	VALUES
('Horror', NULL),
('Sci-Fi', NULL),
('Mystery', NULL),
('Thriller', NULL),
('Fantasy', NULL)

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Categories]([CategoryName], [Notes])
	VALUES
('Everyone', NULL),
('Mature', NULL),
('General', NULL),
('PG-13', NULL),
('Restricted', NULL)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(MAX) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] SMALLINT NOT NULL,
	[Length] SMALLINT NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] SMALLINT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
	VALUES
('Interstellar', 1, 2004, 124, 1, 2, 10, NULL),
('Fight Club', 2, 1997, 102, 2, 1, 9, 'Pretty good overall'),
('Silence of the Lambs', 3, 1986, 145, 1, 2, 8, NULL),
('Rango', 2, 2013, 96, 1, 2, 9, NULL),
('Koziqt Rog', 3, 1975, 134, 2, 3, 9, NULL)

SELECT * FROM [Directors]
SELECT * FROM [Genres]
SELECT * FROM [Categories]
SELECT * FROM [Movies]

-- 14. Car Rental Database

CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(MAX) NOT NULL,
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL,
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
('Cars', 5, 30, 125, 4),
('Cars', 6, 35, 135, 5),
('Cars', 5, 28, 115, 3)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(MAX) NOT NULL,
	[Manufacturer] NVARCHAR(MAX) NOT NULL,
	[Model] NVARCHAR(MAX) NOT NULL,
	[CarYear] SMALLINT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] TINYINT NOT NULL,
	[Picture] IMAGE,
	[Condition] NVARCHAR(MAX),
	[Available] BIT NOT NULL
)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
	VALUES
('A 3472 TO', 'Honda', 'civic', 2000, 1, 4, NULL, 'Good', 1),
('CA 1452 TH', 'Nissan', 'GTR', 2016, 2, 2, NULL, 'Great', 0),
('CO 8245 CX', 'Mitsubishi', 'R600', 2003, 1, 4, NULL, 'Used', 1)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(MAX) NOT NULL,
	[LastName] NVARCHAR(MAX) NOT NULL,
	[Title] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
	VALUES
('Yordan', 'Nesheva', 'G.O.D', NULL),
('Petur', 'Nesheva', 'D.O.G', NULL),
('Galina', 'Manolova', 'M.O.M', NULL)

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenseNumber] BIGINT NOT NULL,
	[FullName] NVARCHAR(MAX) NOT NULL,
	[Address] NVARCHAR(MAX) NOT NULL,
	[City] NVARCHAR(MAX) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Customers]([DriverLicenseNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
	VALUES
(5278278287, 'Maksim Negrov', 'Simeon 32', 'Sofiq', 1000, NULL),
(2740828738, 'Petur Mladenov', 'Kniaz Boris 102', 'Stara Zagora', 6000, NULL),
(1417813171, 'Boiko Metodiev', 'Patriarh Evtimii 156', 'Stara Zagora', 6000, NULL)

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(4, 2) NOT NULL,
	[TaxRate] DECIMAL(4, 2) NOT NULL,
	[OrderStatus] BIT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd],
[TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
	VALUES
(1, 2, 3, 13, 1000, 2500, 1500, '2023-09-10', '2023-09-17', 7, 1.0, 2, 1, NULL),
(1, 3, 2, 14, 30000, 35500, 5500, '2023-04-11', '2023-07-06', 3, 1.3, 2.14, 1, NULL),
(2, 1, 1, 101, 45000, 63000, 18000, '2023-03-20', '2023-08-13', 3, 1.7, 2.21, 1, NULL)

SELECT * FROM [Categories]
SELECT * FROM [Cars]
SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RentalOrders]

-- 15. Hotel Database

CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL, 
Title NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL,
PhoneNumber INT NOT NULL, 
EmergencyName NVARCHAR(30) NOT NULL, 
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(
RoomStatus BIT NOT NULL,
Notes NVARCHAR(30)
)

CREATE TABLE RoomTypes 
(
RoomType NVARCHAR(30) NOT NULL,
Notes NVARCHAR(30)
)

CREATE TABLE BedTypes 
(
BedType NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(30)
)

CREATE TABLE Rooms 
(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(30) NOT NULL,
BedType NVARCHAR(30) NOT NULL, 
Rate DECIMAL (3,1) NOT NULL,
RoomStatus NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(30)
)

CREATE TABLE Payments
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL, 
TotalDays INT NOT NULL, 
AmountCharged DECIMAL(15,2) NOT NULL, 
TaxRate DECIMAL(15,2) NOT NULL,  
TaxAmount DECIMAL(15,2) NOT NULL, 
PaymentTotal DECIMAL(15,2) NOT NULL, 
Notes NVARCHAR(1000)
)
CREATE TABLE Occupancies 
(
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(15,2), 
PhoneCharge DECIMAL(15,2), 
Notes NVARCHAR(1000)
)

INSERT INTO Employees
VALUES ('Georgi','Georgiev','Hotelier', NULL),
('Georgi','Georgiev','Hotelier', NULL),
('Georgi','Georgiev','Hotelier', NULL)

INSERT INTO Customers
VALUES ('Petur','Petrov', 101010,'Panika', 191919,NULL),
('Petur','Petrov', 101010,'Panika', 191919,NULL),
('Petur','Petrov', 101010,'Panika', 191919,NULL)

INSERT INTO RoomStatus
VALUES (1,NULL),
(0,NULL),
(1,NULL)

INSERT INTO RoomTypes
VALUES ('Hubava', NULL),
('Hubava', NULL),
('Hubava', NULL)

INSERT INTO BedTypes
VALUES ('dvoino', NULL),
('edinichno', NULL),
('kingsize', NULL)

INSERT INTO Rooms
VALUES ('Hubava','dvoino',1,'gotova',NULL),
('Hubava','dvoino',1,'gotova',NULL),
('Hubava','dvoino',1,'gotova',NULL)

INSERT INTO Payments
VALUES (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL)

INSERT INTO Occupancies
VALUES (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL)

SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RoomStatus]
SELECT * FROM [RoomTypes]
SELECT * FROM [BedTypes]
SELECT * FROM [Rooms]
SELECT * FROM [Payments]
SELECT * FROM [Occupancies]

-- 16. Create SoftUni Database

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns 
(
Id INT PRIMARY KEY IDENTITY, 
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses 
(
Id INT PRIMARY KEY IDENTITY, 
AddressText NVARCHAR(30) NOT NULL, 
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
MiddleName NVARCHAR(30), 
LastName NVARCHAR(30) NOT NULL,  
JobTitle NVARCHAR(30) NOT NULL, 
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
HireDate DATE NOT NULL,
Salary DECIMAL (5,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

-- 19. Basic Select All Fields

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

-- 20. Basic Select All Fields and Order Them

SELECT * FROM [Towns]
ORDER BY [Name] ASC

SELECT * FROM [Departments]
ORDER BY [Name] ASC

SELECT * FROM [Employees]
ORDER BY Salary DESC

-- 21. Basic Select Some Fields

SELECT [Name] FROM [Towns]
ORDER BY [Name]

SELECT [Name] FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY Salary DESC

-- 22. Increase Employees Salary

UPDATE Employees 
SET Salary *= 1.1

SELECT Salary FROM Employees

-- 23. Decrease Tax Rate

USE Hotel

UPDATE Payments
SET TaxRate -= 0.03

SELECT TaxRate FROM Payments

-- 24. Delete All Records

DELETE FROM [Occupancies]