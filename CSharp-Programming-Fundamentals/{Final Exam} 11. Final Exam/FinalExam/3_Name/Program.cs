using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace FinalExam
{
    class Animal
    {
        public int DailyFoodLimit { get; set; }
        public string Habitat { get; set; }
    }

    class WildZoo
    {
        static void Main()
        {
            Dictionary<string, Animal> animals = new Dictionary<string, Animal>();
            Dictionary<string, List<string>> habitats = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "EndDay")
            {
                string[] commandInfo = command.Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandInfo[0];
                string animalName = commandInfo[1];

                if (commandName == "Add")
                {
                    int neededFood = int.Parse(commandInfo[2]);
                    string area = commandInfo[3];

                    if (animals.ContainsKey(animalName))
                    {
                        animals[animalName].DailyFoodLimit += neededFood;
                    }
                    else
                    {
                        if (!habitats.ContainsKey(area))
                        {
                            habitats.Add(area, new List<string>());
                        }

                        habitats[area].Add(animalName);

                        Animal animal = new Animal();
                        animal.DailyFoodLimit = neededFood;
                        animal.Habitat = area;

                        animals.Add(animalName, animal);
                    }
                }
                else if (commandName == "Feed")
                {
                    int food = int.Parse(commandInfo[2]);

                    if (animals.ContainsKey(animalName))
                    {
                        animals[animalName].DailyFoodLimit -= food;

                        if (animals[animalName].DailyFoodLimit <= 0)
                        {
                            animals.Remove(animalName);

                            foreach (var (habitat, hungryAnimals) in habitats)
                            {
                                if (hungryAnimals.Contains(animalName))
                                {
                                    hungryAnimals.Remove(animalName);
                                }
                            }

                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            foreach (var (animalName, animal) in animals)
            {
                Console.WriteLine($" {animalName} -> {animal.DailyFoodLimit}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (var (habitat, hungryAnimals) in habitats)
            {
                if (hungryAnimals.Count > 0)
                {
                    Console.WriteLine($" {habitat}: {hungryAnimals.Count}");
                }
            }
        }
    }
}