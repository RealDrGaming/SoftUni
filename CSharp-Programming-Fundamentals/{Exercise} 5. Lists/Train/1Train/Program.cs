using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Train
{
    class Train
    {
        static void Main()
        {
            List<int> wagons = new List<int>();

            wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxWagonCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParts = command.Split().ToArray();

                string firstPart = commandParts[0];

                if (firstPart == "Add")
                {
                    int secondPart = int.Parse(commandParts[1]);

                    wagons.Add(secondPart);
                }
                else
                {
                    int value = int.Parse(firstPart);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (value <= maxWagonCapacity - wagons[i])
                        {
                            wagons[i] += value;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}