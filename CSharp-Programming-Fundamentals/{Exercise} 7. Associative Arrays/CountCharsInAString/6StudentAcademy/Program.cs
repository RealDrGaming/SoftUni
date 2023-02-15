using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Xsl;

namespace CountCharsInAString
{
    public class StudentAcademy
    {
        public static void Main()
        {
            Dictionary<string, double> students = new Dictionary<string, double>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    double oldGrade = students[name];
                    students[name] = (grade + oldGrade) / 2;
                }
                else
                {
                    students.Add(name, grade);
                }
            }

            foreach (var item in students)
            {
                if (item.Value >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value:F2}");
                }
            }
        }
    }
}