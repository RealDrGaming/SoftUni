using System;
using System.Reflection;

namespace FinalExamPrep 
{
    class ImitationGame 
    {
        static void Main() 
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] commandInfo = command.Split('|');

                if (commandInfo[0] == "Move")
                {
                    int numOfLetters = int.Parse(commandInfo[1]);

                    string movingString = message.Substring(0, numOfLetters);

                    message = message.Remove(0, numOfLetters);
                    message += movingString;
                }
                else if (commandInfo[0] == "Insert")
                {
                    int index = int.Parse(commandInfo[1]);
                    string value = commandInfo[2];

                    message = message.Insert(index, value);
                }
                else if (commandInfo[0] == "ChangeAll")
                {
                    string substring = commandInfo[1];
                    string replacement = commandInfo[2];

                    message = message.Replace(substring, replacement);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}