CREATE DATABASE [TouristAgency]
USE [TouristAgency]

-- 01. DDL

CREATE TABLE Countries 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Rooms 
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	BedCount INT NOT NULL
		CHECK(BedCount > 0 AND BedCount <= 10),
)

CREATE TABLE Hotels 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Tourists 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings 
(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL
		CHECK(AdultsCount >= 1 AND AdultsCount <= 10),
	ChildrenCount INT NOT NULL
		CHECK(ChildrenCount >= 0 AND ChildrenCount <= 9),
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
)

CREATE TABLE HotelsRooms
(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	PRIMARY KEY (HotelId, RoomId)
)

-- 02. INSERT

INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
	VALUES
	('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
	('Adeline Agla?', '122-654-8726', 'adeline.aglae@example.com', 2),
	('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
	('Johan M?ller', '322-876-9826', 'j.muller@example.com', 7),
	('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
	VALUES
	('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
	('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
	('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
	('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
	('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

-- 03. UPDATE

UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE DepartureDate > '2023-12-01'

UPDATE Tourists
SET Email = NULL
WHERE Email LIKE '%MA%'

-- 04. DELETE

DELETE FROM Bookings
WHERE TouristId IN (6, 16, 25)

DELETE FROM Tourists
WHERE [Name] LIKE '%Smith'

-- 05. Bookings by Price of Room and Arrival Date

SELECT FORMAT(ArrivalDate, 'yyyy-MM-dd') AS 'ArrivalDate', AdultsCount, ChildrenCount
FROM Bookings AS b JOIN Rooms AS r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate ASC

-- 06. Hotels by Count of Bookings

SELECT h.Id, h.[Name]
FROM Hotels AS h 
			JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
			JOIN Rooms AS r ON hr.RoomId = r.Id
			JOIN Bookings AS b ON b.HotelId = h.Id
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(h.Id) DESC

-- 07. Tourists without Bookings

SELECT t.Id, t.[Name], t.PhoneNumber
FROM Tourists AS t LEFT JOIN Bookings AS b ON b.TouristId = t.Id
WHERE b.HotelId IS NULL
ORDER BY t.[Name]

-- 08. First 10 Bookings

SELECT TOP(10) h.[Name] AS 'HotelName', d.[Name] AS 'DestinationName', c.[Name] AS 'CountryName'
FROM Bookings AS b
				JOIN Hotels AS h ON b.HotelId = h.id
				JOIN Destinations AS d ON h.DestinationId = d.Id
				JOIN Countries AS c ON d.CountryId = c.Id
WHERE ArrivalDate < '2023-12-31' AND h.Id % 2 <> 0
ORDER BY c.[Name] ASC, ArrivalDate ASC

-- 09. Tourists booked in Hotels

SELECT h.[Name], r.Price
FROM Tourists AS t
				JOIN Bookings AS b ON b.TouristId = t.Id
				JOIN Hotels AS h ON b.HotelId = h.Id
				JOIN Rooms AS r ON b.RoomId = r.Id
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC

-- 10. Hotels Revenue

SELECT h.[Name] AS 'HotelName', SUM(DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate) * r.Price) AS [HotelRevenue]
FROM Bookings AS b
				JOIN Hotels AS h ON b.HotelId = h.Id
				JOIN Rooms AS r ON b.RoomId = r.Id
GROUP BY h.[Name]
ORDER BY [HotelRevenue] DESC

-- 11. Rooms with Tourists

GO
CREATE FUNCTION udf_RoomsWithTourists(@name NVARCHAR(80))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT SUM(AdultsCount + ChildrenCount)
		FROM Rooms AS r 
					JOIN Bookings AS b ON b.RoomId = r.Id
					JOIN Tourists AS t ON b.TouristId = t.Id
		WHERE r.[Type] = @name
	)
END

-- 12. Search for Tourists from a Specific Country

GO

CREATE PROCEDURE usp_SearchByCountry(@country NVARCHAR(50))
AS
BEGIN
	SELECT t.[Name], t.PhoneNumber, t.Email, COUNT(b.Id) AS 'CountOfBookings'
	FROM Bookings AS b 
					JOIN Tourists AS t ON b.TouristId = t.Id
					JOIN Countries AS c ON t.CountryId = c.Id
	WHERE c.[Name] = @country
	GROUP BY t.[Name], t.PhoneNumber, t.Email
	ORDER BY t.[Name] ASC, COUNT(b.Id) DESC
END