using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class ActivationKeys
    {
        static void Main()
        {
            StringBuilder rawKey = new StringBuilder(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] commandInfo = command.Split(">>>");
                string commandName = commandInfo[0];

                if (commandName == "Contains")
                {
                    string substring = commandInfo[1];

                    if (rawKey.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commandName == "Flip")
                {
                    string upperLower = commandInfo[1];
                    int startIndex = int.Parse(commandInfo[2]);
                    int endIndex = int.Parse(commandInfo[3]);

                    string substring = rawKey.ToString().Substring(startIndex, endIndex - startIndex);

                    if (upperLower == "Upper")
                    {
                        rawKey.Replace(substring, substring.ToUpper());
                    }
                    else if (upperLower == "Lower")
                    {
                        rawKey.Replace(substring, substring.ToLower());
                    }

                    Console.WriteLine(rawKey);
                }
                else if (commandName == "Slice")
                {
                    int startIndex = int.Parse(commandInfo[1]);
                    int endIndex = int.Parse(commandInfo[2]);

                    rawKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(rawKey);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}