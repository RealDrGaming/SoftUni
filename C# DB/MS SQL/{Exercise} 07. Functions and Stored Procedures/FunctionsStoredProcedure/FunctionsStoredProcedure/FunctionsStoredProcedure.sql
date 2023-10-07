USE [SoftUni]

-- 01. Employees with Salary Above 35000

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [Salary] > 35000

EXEC usp_GetEmployeesSalaryAbove35000

-- 02. Employees with Salary Above Number

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber
@salaryLevel DECIMAL(18, 4)
AS
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [Salary] >= @salaryLevel

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- 03. Town Names Starting With

CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith
@inputString NVARCHAR(50)
AS
	SELECT [Name]
	FROM [Towns]
	WHERE [Name] LIKE @inputString + '%'

EXEC usp_GetTownsStartingWith 'b'

-- 04. Employees from Town

CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown
@townName NVARCHAR(50)
AS
	SELECT [FirstName], [LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
	JOIN [Towns] AS t ON t.[TownID] = a.[TownID]
	WHERE t.[Name] = @townName

EXEC usp_GetEmployeesFromTown 'Sofia'

-- 05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(20)
AS
BEGIN
	IF @salary < 30000
		RETURN 'Low'
	ELSE IF	@salary <= 50000
		RETURN 'Average'

	RETURN 'High'
END

SELECT dbo.ufn_GetSalaryLevel(20000)

-- 06. Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel
@salaryLevel NVARCHAR(50)
AS
BEGIN
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'Low'

-- 07. Define Function

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1
	WHILE @i <= LEN(@word)
	BEGIN
		DECLARE @ch NVARCHAR(1) = SUBSTRING(@word, @i, 1)
		IF CHARINDEX(@ch, @setOfLetters) = 0
			RETURN 0
		ELSE
			SET @i += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('abcd', 'cabs')

-- 09. Find Full Name

USE [Bank]

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT_WS(' ', [FirstName], [LastName])
	FROM [AccountHolders]

-- 10. People With Balance Higher Than

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan
@accountThreshold MONEY
AS
	SELECT [FirstName], [LastName]
	FROM [AccountHolders] AS ah
	LEFT JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
	GROUP BY ah.[Id], ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @accountThreshold
	ORDER BY [FirstName], [LastName]

EXEC usp_GetHoldersWithBalanceHigherThan 0.2

-- 11. Future Value Function

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
	(@sum DECIMAL(18, 2), @rate FLOAT, @years INT)
RETURNS DECIMAL (20, 4)
AS
BEGIN
	RETURN @sum * POWER((1 + @rate), @years)
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- 12. Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
	DECLARE @years INT = 5
	SELECT a.[Id] [Account Id], ah.[FirstName], ah.[LastName], a.[Balance],
		dbo.ufn_CalculateFutureValue(a.[Balance], @interestRate, @years) [Balance in 5 years]
	FROM [AccountHolders] ah
	JOIN [Accounts] a ON a.[AccountHolderId] = ah.[Id]
	WHERE a.[Id] = 1

EXEC usp_CalculateFutureValueForAccount 1 0.1