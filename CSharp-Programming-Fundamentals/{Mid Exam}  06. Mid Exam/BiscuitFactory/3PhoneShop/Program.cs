using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;

namespace BiscuitFactory
{
    class CoffeeLover
    {
        static void Main()
        {
            List<string> phoneModels = Console.ReadLine()
                .Split(", ")
                .ToList();

            string commandLine = Console.ReadLine();

            while (commandLine != "End")
            {
                string[] args = commandLine.Split(" - ");

                string command = args[0];

                if (command == "Add")
                {
                    string phone = args[1];

                    if (!phoneModels.Contains(phone))
                    {
                        phoneModels.Add(phone);
                    }
                }
                else if (command == "Remove")
                {
                    string phone = args[1];

                    if (phoneModels.Contains(phone))
                    {
                        phoneModels.Remove(phone);
                    }
                }
                else if (command == "Bonus phone")
                {
                    string[] phones = args[1].Split(':');

                    if (phoneModels.Contains(phones[0]))
                    {
                        phoneModels.Insert(phoneModels.FindIndex(0, phoneModels.Count, x => x == phones[0]) + 1, phones[1]);
                    }
                }
                else if (command == "Last")
                {
                    string phone = args[1];

                    if (phoneModels.Contains(phone))
                    {
                        phoneModels.Add(phone);
                        phoneModels.Remove(phone);
                    }
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phoneModels));
        }
    }
}