using System;
using System.Linq;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class Students
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 1; i <= lines; i++)
            {
                List<string> studentLine = Console.ReadLine()
                .Split(" ")
                .ToList();

                Student student = new Student(studentLine[0], studentLine[1], studentLine[2]);
                students.Add(student);
            }

            students = students.OrderBy(x => x.Grade).ToList();
            students.Reverse();

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].FirstName} {students[i].LastName}: {students[i].Grade}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, string grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
    }
}