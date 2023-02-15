using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class AdAstra
    {
        static void Main()
        {
            List<Item> lists = new List<Item>();
            int sumCalories = 0;

            string pattern = @"([\#|\|])(?<food>[A-Za-z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string name = match.Groups["food"].Value;
                string expirationDate = match.Groups["expirationDate"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                sumCalories += calories;

                Item item = new Item(name, expirationDate, calories);
                lists.Add(item);
            }

            int daysToLast = sumCalories / 2000;
            Console.WriteLine($"You have food to last you for: {daysToLast} days!");

            foreach (var item in lists)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.Date}, Nutrition: {item.Calories}");
            }
        }

        public class Item
        {
            public Item(string name, string date, int calories)
            {
                Name = name;
                Date = date;
                Calories = calories;
            }

            public string Name { get; set; }
            public string Date { get; set; }
            public int Calories { get; set; }
        }
    }
}