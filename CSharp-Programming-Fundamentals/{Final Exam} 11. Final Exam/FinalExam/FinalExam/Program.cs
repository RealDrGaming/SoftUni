using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FinalExam 
{
    class StringManipulator
    {
        static void Main() 
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandInfo[0];

                if (commandName == "Translate")
                {
                    string charToFind = commandInfo[1];
                    string replacement = commandInfo[2];

                    input.Replace(charToFind, replacement);

                    Console.WriteLine(input);
                }
                else if (commandName == "Includes")
                {
                    string substring = commandInfo[1];

                    if (input.ToString().Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (commandName == "Start")
                {
                    string substring = commandInfo[1];

                    if (input.ToString().StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (commandName == "Lowercase")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = char.ToLower(input[i]);
                    }

                    Console.WriteLine(input);
                }
                else if (commandName == "FindIndex")
                {
                    string charToFind = commandInfo[1];
                    int lastOccurrence = input.ToString().LastIndexOf(charToFind);

                    Console.WriteLine(lastOccurrence);
                }
                else if (commandName == "Remove")
                {
                    int startIndex = int.Parse(commandInfo[1]);
                    int count = int.Parse(commandInfo[2]);

                    input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }
        }
    }
}