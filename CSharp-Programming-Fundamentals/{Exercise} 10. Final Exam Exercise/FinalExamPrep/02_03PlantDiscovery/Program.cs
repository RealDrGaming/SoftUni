using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class Plant
    {
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }
    }

    class PlantDiscovery
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split("<->");
                string plantName = args[0];
                int plantRarity = int.Parse(args[1]);

                if (!plants.ContainsKey(plantName))
                {
                    Plant plant = new Plant();
                    plant.Rarity = plantRarity;
                    plant.Ratings = new List<double>();

                    plants.Add(plantName, plant);
                }
                else
                {
                    plants[plantName].Rarity = plantRarity;
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                string[] commandInfo = command.Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandInfo[0];
                string plantName = commandInfo[1];

                if (commandName == "Rate")
                {
                    double rating = double.Parse(commandInfo[2]);

                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Ratings.Add(rating);
                    }
                    else Console.WriteLine("error");
                }
                else if (commandName == "Update")
                {
                    int rarity = int.Parse(commandInfo[2]);

                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Rarity = rarity;
                    }
                    else Console.WriteLine("error");
                }
                else if (commandName == "Reset")
                {
                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Ratings.Clear();
                    }
                    else Console.WriteLine("error");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var plant in plants)
            {
                if (plant.Value.Ratings.Count > 0)
                {
                    double avgRating = plant.Value.Ratings.Average();

                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {avgRating:f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {0:f2}");
                }
            }
        }
    }
}