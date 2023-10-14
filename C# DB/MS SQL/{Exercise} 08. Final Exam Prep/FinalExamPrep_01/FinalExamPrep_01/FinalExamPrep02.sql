CREATE DATABASE [Zoo]
USE [Zoo]

-- 01. DDL

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

-- 02. Insert

INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
	VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
	VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)


-- 03. Update

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

-- 04. Delete

DELETE Volunteers WHERE DepartmentId = 2

DELETE VolunteersDepartments WHERE Id = 2

-- 05. Volunteers

SELECT [Name], PhoneNumber, [Address], AnimalId, DepartmentId
FROM Volunteers
ORDER BY [Name] ASC, AnimalId ASC, DepartmentId ASC

-- 06. Animals Data

SELECT a.[Name], [at].AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy')
FROM Animals AS a JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
ORDER BY a.[Name] ASC

-- 07. Owners and Their Animals

SELECT TOP(5) o.[Name] AS 'Owner', COUNT(a.OwnerId) AS 'CountOfAnimals'
FROM Animals AS a JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY COUNT(a.OwnerId) DESC, o.[Name]

-- 08. Owners, Animals and Cages

SELECT CONCAT_WS('-', o.[Name], a.[Name]) AS 'OwnersAnimals', o.PhoneNumber, ac.CageId
FROM Owners AS o 
				JOIN Animals AS a ON a.OwnerId = o.Id
				JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
				JOIN AnimalTypes AS [at] ON a.[AnimalTypeId] = [at].Id
WHERE [at].AnimalType = 'Mammals'
ORDER BY o.[Name] ASC, a.[Name] DESC

-- 09. Volunteers in Sofia

SELECT v.[Name], v.PhoneNumber, SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 2, LEN(v.[Address])) AS 'Address'
FROM Volunteers AS v JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE vd.DepartmentName = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name] ASC

-- 10. Animals for Adoption

SELECT a.[Name], FORMAT(a.BirthDate, 'yyyy') AS 'BirthYear', [at].AnimalType
FROM Animals AS a JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
WHERE DATEDIFF(YEAR, BirthDate, '01/01/2022') < 5 AND [at].AnimalType NOT LIKE 'Birds' AND OwnerId IS NULL
ORDER BY a.[Name]

-- 11. All Volunteers in a Department

GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN(SELECT COUNT(v.DepartmentId)
	FROM Volunteers AS v JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
	WHERE vd.DepartmentName = @VolunteersDepartment)
END

-- 12. Animals with Owner or Not

GO
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	IF(SELECT OwnerId FROM Animals WHERE [Name] = @AnimalName) IS NULL
		BEGIN
			SELECT [Name], 'For adoption' AS OwnerName
			FROM Animals
			WHERE Name = @AnimalName
		END
	ELSE
		BEGIN
			SELECT a.[Name], o.[Name] AS 'OwnersName'
			FROM Animals AS a JOIN Owners AS o ON a.OwnerId = o.Id
			WHERE a.[Name] = @AnimalName
		END
END

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'