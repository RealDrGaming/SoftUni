using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Train
{
    class ListOperations
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string arg = Console.ReadLine();

            while (arg != "End")
            {
                string[] args = arg.Split(' ').ToArray();

                string command = args[0];

                if (command == "Add")
                {
                    int value = int.Parse(args[1]);

                    numbers.Add(value);
                }
                else if (command == "Insert")
                {
                    int value = int.Parse(args[1]);
                    int index = int.Parse(args[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(args[1]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Shift")
                {
                    int count = int.Parse(args[2]);

                    if (args[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstNum = numbers[0];

                            numbers.RemoveAt(0);
                            numbers.Add(firstNum);
                        }
                    }
                    else if (args[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastNum = numbers[numbers.Count - 1];

                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastNum);
                        }
                    }
                }

                arg = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}