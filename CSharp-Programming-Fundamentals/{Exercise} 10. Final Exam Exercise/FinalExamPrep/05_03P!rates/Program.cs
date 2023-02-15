using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class Settlement
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }

    class Pirates
    {
        static void Main()
        {
            Dictionary<string, Settlement> settlements = new Dictionary<string, Settlement>();

            string arg = Console.ReadLine();

            while (arg != "Sail")
            {
                string[] args = arg.Split("||");
                int population = int.Parse(args[1]);
                int gold = int.Parse(args[2]);

                if (settlements.ContainsKey(args[0]))
                {
                    settlements[args[0]].Population += population;
                    settlements[args[0]].Gold += gold;
                }
                else
                {
                    Settlement settlement = new Settlement();
                    settlement.Population = population;
                    settlement.Gold = gold;

                    settlements.Add(args[0], settlement);
                }

                arg = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfo = command.Split("=>");
                string commandName = commandInfo[0];
                string townName = commandInfo[1];

                if (commandName == "Plunder")
                {
                    int people = int.Parse(commandInfo[2]);
                    int gold = int.Parse(commandInfo[3]);

                    settlements[townName].Population -= people;
                    settlements[townName].Gold -= gold;

                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (settlements[townName].Population <= 0 || settlements[townName].Gold <= 0)
                    {
                        settlements.Remove(townName);
                        Console.WriteLine($"{townName} has been wiped off the map!");
                    }
                }
                else if (commandName == "Prosper")
                {
                    int gold = int.Parse(commandInfo[2]);

                    if (gold >= 0)
                    {
                        settlements[townName].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {settlements[townName].Gold} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }

                command = Console.ReadLine();
            }

            if (settlements.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {settlements.Count} wealthy settlements to go to:");

                foreach (var (townName, town) in settlements)
                {
                    Console.WriteLine($"{townName} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}