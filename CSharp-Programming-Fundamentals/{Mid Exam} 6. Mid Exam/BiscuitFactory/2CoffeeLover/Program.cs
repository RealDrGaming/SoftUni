using System;
using System.Linq;
using System.Collections.Generic;

namespace BiscuitFactory
{
    class CoffeeLover
    {
        static void Main()
        {
            List<string> coffeeNames = Console.ReadLine()
                .Split(' ')
                .ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {

                string commandLine = Console.ReadLine();
                
                string[] args = commandLine.Split(' ');

                string command = args[0];

                if (command == "Include")
                {
                    string value = args[1];

                    coffeeNames.Add(value);
                }
                else if (command == "Remove")
                {
                    string firstLast = args[1];
                    int numOfCoffees = int.Parse(args[2]);

                    if (numOfCoffees <= coffeeNames.Count)
                    {
                        if (firstLast == "first")
                        {
                            for (int j = 1; j <= numOfCoffees; j++)
                            {
                                coffeeNames.RemoveAt(0);
                            }
                        }
                        else if (firstLast == "last")
                        {
                            for (int j = 1; j <= numOfCoffees; j++)
                            {
                                coffeeNames.RemoveAt(coffeeNames.Count - 1);
                            }
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    int index1 = int.Parse(args[1]);
                    int index2 = int.Parse(args[2]);

                    if (index1 >= 0 && index1 < coffeeNames.Count && index2 >= 0 && index2 < coffeeNames.Count)
                    {
                        string firstCoffee = coffeeNames[index1];
                        string secondCoffee = coffeeNames[index2];

                        coffeeNames[index1] = secondCoffee;
                        coffeeNames[index2] = firstCoffee;
                    }
                }
                else if (command == "Reverse")
                {
                    coffeeNames.Reverse();
                }
            }

            Console.WriteLine("Coffees: ");
            Console.WriteLine(string.Join(" ", coffeeNames));
        }
    }
}