using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString
{
    public class CompanyUsers
    {
        public static void Main()
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" -> ");

                string company = commandArgs[0];
                string ID = commandArgs[1];

                if (companies.ContainsKey(company))
                {
                    if (companies[company].Contains(ID))
                    {

                    }
                    else
                    {
                        companies[company].Add(ID);
                    }
                }
                else
                {
                    companies.Add(company, new List<string>());
                    companies[company].Add(ID);
                }

                command = Console.ReadLine();
            }

            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);

                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine($"-- {item.Value[i]}");
                }
            }
        }
    }
}