using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Train
{
    class HouseParty
    {
        static void Main()
        {
            List<string> guests = new List<string>();

            int argLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= argLines; i++)
            {
                string line = Console.ReadLine();

                string[] args = line.Split(' ');

                string name = args[0];

                if (args[2] == "not")
                {
                    if (guests.Contains(name)) guests.Remove(name);
                    else Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    if (guests.Contains(name)) Console.WriteLine($"{name} is already in the list!");
                    else guests.Add(name);
                }
            }

            Console.WriteLine(String.Join("\n", guests));
        }
    }
}