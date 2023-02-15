using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class PasswordReset
    {
        static void Main()
        {
            StringBuilder passFinal = new StringBuilder(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandInfo[0];

                if (commandName == "TakeOdd")
                {
                    for (int i = 0; i < passFinal.Length; i++)
                    {
                        passFinal.Remove(i, 1);
                    }

                    Console.WriteLine(passFinal);
                }
                else if (commandName == "Cut")
                {
                    int index = int.Parse(commandInfo[1]);
                    int length = int.Parse(commandInfo[2]);

                    passFinal.Remove(index, length);

                    Console.WriteLine(passFinal);
                }
                else if (commandName == "Substitute")
                {
                    string substring = commandInfo[1];
                    string substitute = commandInfo[2];

                    if (passFinal.ToString().Contains(substring))
                    {
                        passFinal.Replace(substring, substitute);
                        Console.WriteLine(passFinal);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {passFinal}");
        }
    }
}