using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class SecretChat
    {
        static void Main()
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] commandInfo = command.Split(":|:");
                string commandName = commandInfo[0];

                if (commandName == "InsertSpace")
                {
                    int index = int.Parse(commandInfo[1]);
                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (commandName == "Reverse")
                {
                    string substring = commandInfo[1];

                    if (message.Contains(substring))
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        message = message + string.Join("", substring.Reverse());

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commandName == "ChangeAll")
                {
                    string substring = commandInfo[1];
                    string replacement = commandInfo[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}