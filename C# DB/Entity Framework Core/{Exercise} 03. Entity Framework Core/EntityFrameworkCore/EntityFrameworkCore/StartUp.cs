using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            // Change method based on task
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
        }

        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).ToList();

            return string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
        }

        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .AsNoTracking()
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).
                Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} - {e.Salary:f2}"));
        }

        // 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .AsNoTracking()
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenBy(e => e.FirstName)
                .ToList();

            return string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}"));
        }

        // 06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new 
                {
                    e.AddressId,
                    e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.AddressText}"));
        }

        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context) 
        {

        }

        // 08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context) 
        {

        }

        // 09. Employee 147
        public static string GetEmployee147(SoftUniContext context) 
        {

        }

        // 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

        }

        // 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context) 
        {

        }

        // 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context) 
        {

        }

        // 13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context) 
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("sa"))
                .ToList();

            return string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
        }

        // 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context) 
        {

        }

        // 15. Remove Town
        public static string RemoveTown(SoftUniContext context) 
        {

        }
    }
}