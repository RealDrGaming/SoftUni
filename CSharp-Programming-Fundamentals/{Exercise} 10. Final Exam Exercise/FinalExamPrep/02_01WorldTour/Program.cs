using System;
using System.Text;

namespace FinalExamPrep
{
    class WorldTour
    {
        static void Main()
        {
            StringBuilder stops = new StringBuilder(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] commandInfo = command.Split(':');
                string commandName = commandInfo[0];

                if (commandName == "Add Stop")
                {
                    int index = int.Parse(commandInfo[1]);
                    string stringAdd = commandInfo[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops.Insert(index, stringAdd);
                        Console.WriteLine(stops.ToString());
                    }
                }
                else if (commandName == "Remove Stop")
                {
                    int startIndex = int.Parse(commandInfo[1]);
                    int endIndex = int.Parse(commandInfo[2]);

                    if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
                    {
                        stops.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(stops.ToString());
                    }
                }
                else if (commandName == "Switch")
                {
                    string oldString = commandInfo[1];
                    string newString = commandInfo[2];

                    stops.Replace(oldString, newString);
                    Console.WriteLine(stops.ToString());
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops.ToString()}");
        }
    }
}