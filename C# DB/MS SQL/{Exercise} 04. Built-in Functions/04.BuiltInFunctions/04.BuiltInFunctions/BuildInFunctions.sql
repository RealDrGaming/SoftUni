USE [SoftUni]

-- 01. Find Names of All Employees by First Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'

-- 02. Find Names of All Employees by Last Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'

-- 03. Find First Names of All Employees

SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3, 10) AND [HireDate] BETWEEN '1995-01-01' AND '2005-12-31'

-- 04. Find All Employees Except Engineers

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'

-- 05. Find Towns with Name Length

SELECT [Name]
FROM [Towns]
WHERE Len([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

-- 06. Find Towns Starting With

SELECT *
FROM [Towns]
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 07. Find Towns Not Starting With

SELECT *
FROM [Towns]
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

-- 08. Create View Employees Hired After 2000 Year

GO
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [HireDate] > '2000-12-31'
GO

-- 09. Length of Last Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE Len([LastName]) = 5

-- 10. Rank Employees by Salary

SELECT [EmployeeId], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- 12. Countries Holding 'A' 3 or More Times

USE [Geography]

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- 13. Mix of Peak and River Names

SELECT p.[PeakName], r.[RiverName],
LOWER(LEFT(p.[PeakName], Len(p.[PeakName]) - 1)+ r.[RiverName]) AS [Mix]
FROM [Peaks] AS p, [Rivers] AS r
WHERE RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
ORDER BY [Mix]

-- 14. Games from 2011 and 2012 Year

USE [Diablo]

SELECT TOP 50 [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE YEAR([Start]) BETWEEN 2011 and 2012
ORDER BY [Start], [Name]

-- 15. User Email Providers

SELECT [Username],
SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, Len([Email])) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider], [Username]

-- 16. Get Users with IP Address Like Pattern

SELECT [Username], [IpAddress] AS [IP Address]
FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

-- 17. Show All Games with Duration & Part of the Day

SELECT [Name] AS Game,
CASE
   WHEN DATEPART(HOUR, [START]) BETWEEN 0 AND 11 THEN 'Morning'
   WHEN DATEPART(HOUR, [START]) BETWEEN 12 AND 17 THEN 'Afternoon'
   WHEN DATEPART(HOUR, [START]) BETWEEN 18 AND 23 THEN 'Evening'
END AS [Part of the Day],
CASE
   WHEN [Duration] BETWEEN 0 AND 3 THEN 'Extra Short'
   WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
   WHEN [Duration] > 6 THEN 'Long'
   ELSE 'Extra Long'
END AS [Duration]
FROM [Games]
ORDER BY [Name], [Duration], [Part of the Day] 

-- 18. Orders Table

SELECT [ProductName], [OrderDate],
	DATEADD(day, 3, [OrderDate]) AS [Pay Due],
	DATEADD(month, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders]