using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString
{
    public class Courses
    {
        public static void Main()
        {
            Dictionary<string, List<string>> coursists = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split(" : ");

                string course = commandArgs[0];
                string name = commandArgs[1];

                if (coursists.ContainsKey(course))
                {
                    coursists[course].Add(name);
                }
                else 
                {
                    coursists.Add(course, new List<string>());
                    coursists[course].Add(name);
                }

                command = Console.ReadLine();
            }

            foreach (var item in coursists)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine($"-- {item.Value[i]}");
                }
            }
        }
    }
}