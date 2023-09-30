USE [SoftUni]

-- 01. Employee Address

SELECT TOP(5) e.[EmployeeId], e.[JobTitle], e.[AddressId], a.[AddressText]
FROM [Employees] AS e JOIN [Addresses] AS a ON e.[AddressId] = a.[AddressId]
ORDER BY e.[AddressId]

-- 02. Addresses with Towns

SELECT TOP(50) e.[FirstName], e.[LastName], t.[Name], a.[AddressText]
FROM [Employees] AS e JOIN [Addresses] AS a ON e.[AddressId] = a.[AddressId] JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName], e.[LastName]

-- 03. Sales Employee

SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name]
FROM [Employees] AS e JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentId]
WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

-- 04. Employee Departments

SELECT TOP(5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name]
FROM [Employees] AS e JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentId]
WHERE e.[Salary] > 15000
ORDER BY e.[DepartmentID]

-- 05. Employees Without Projects

SELECT TOP(3) e.[EmployeeID], e.[FirstName]
FROM [Employees] AS e
WHERE e.[EmployeeID] NOT IN
	(SELECT [EmployeeID] FROM [EmployeesProjects])
ORDER BY e.[EmployeeID]

-- 06. Employees Hired After

SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name]
FROM [Employees] AS e
JOIN [Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
WHERE d.[Name] IN ('Finance', 'Sales') AND 
	e.[HireDate] > '1999-01-01'
ORDER BY e.[HireDate]

-- 07. Employees With Project

SELECT TOP(5) e.[EmployeeID], e.[FirstName], p.[Name]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON p.[ProjectID] = ep.[ProjectID]
WHERE p.[StartDate] > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.[EmployeeID]

-- 08. Employee 24

SELECT e.[EmployeeID], e.[FirstName],
	CASE
		WHEN p.[StartDate] > '2004-12-31' THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON p.[ProjectID] = ep.[ProjectID]
WHERE e.[EmployeeID] = 24

-- 09. Employee Manager

SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], m.[FirstName] as [ManagerName]
FROM [Employees] AS e
JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID]

-- 10. Employees Summary

SELECT TOP 50 e.[EmployeeID], 
(e.[FirstName] + ' ' + e.[LastName]) AS [EmployeeName],
(m.[FirstName] + ' ' + m.[LastName]) AS [ManagerName],
d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]

-- 11. Min Average Salary

SELECT TOP 1 AVG(e.[Salary]) AS [MinAverageSalary]
FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
GROUP BY d.[Name]
ORDER BY AVG(e.Salary)

-- 12. Highest Peaks in Bulgaria

USE [Geography]

SELECT mc.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
FROM [MountainsCountries] AS mc
JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
JOIN [Peaks] AS p ON p.[MountainId] = mc.[MountainId]
WHERE p.[Elevation] > 2835 AND mc.[CountryCode] = 'BG'
ORDER BY p.[Elevation] DESC

-- 13. Count Mountain Ranges

SELECT mc.[CountryCode], COUNT(*) AS [MountainRanges]
FROM [MountainsCountries] AS mc
JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode]
WHERE c.[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY  mc.[CountryCode]

-- 14. Countries With or Without Rivers

SELECT TOP 5 c.[CountryName] AS [CountryName], r.[RiverName] FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.Id
WHERE c.[ContinentCode] = 'AF'
ORDER BY [CountryName]

-- 16. Countries Without any Mountains

SELECT COUNT(*) AS [Count] 
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
WHERE mc.[MountainId] IS NULL

-- 17. Highest Peak and Longest River by Country

SELECT TOP(5) 
  c.[CountryName], 
  MAX(p.[Elevation]) AS [HighestPeakElevation], 
  MAX(r.Length) AS [LongestRiverLength] 
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
JOIN [Mountains] AS m ON m.Id = mc.[MountainId]
JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
JOIN [CountriesRivers] AS cr ON cr.[CountryCode] = c.[CountryCode]
JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]