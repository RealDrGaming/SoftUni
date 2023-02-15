using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Train
{
    class ChangeList
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string arg = Console.ReadLine();

            while (arg != "end") 
            {
                string[] args = arg.Split(' ').ToArray();

                string command = args[0];

                if (command == "Delete")
                {
                    int value = int.Parse(args[1]);

                    numbers.RemoveAll(x => x == value);
                }
                else if (command == "Insert") 
                {
                    int value = int.Parse(args[1]);
                    int position = int.Parse(args[2]);

                    numbers.Insert(position, value);
                }

                arg = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}