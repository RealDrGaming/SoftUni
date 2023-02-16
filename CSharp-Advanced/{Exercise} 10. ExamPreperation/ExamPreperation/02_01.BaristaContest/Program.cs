using System;
using System.Linq;
using System.Collections.Generic;

namespace BaristaContest
{
    public class BaristaContest
    {

        public static void Main()
        {
            Queue<int> coffeeQuantities  = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> coffees = new Dictionary<string, int>
            {
                { "Cortado", 0 },
                { "Espresso", 0 },
                { "Capuccino", 0 },
                { "Americano", 0 },
                { "Latte", 0 },
            };

            while (coffeeQuantities.Count > 0 && milkQuantities.Count > 0)
            {
                int firstCoffee = coffeeQuantities.Dequeue();
                int lastMilk = milkQuantities.Pop();

                if (firstCoffee + lastMilk == 50)
                {
                    coffees["Cortado"]++;
                }
                else if (firstCoffee + lastMilk == 75)
                {
                    coffees["Espresso"]++;
                }
                else if (firstCoffee + lastMilk == 100)
                {
                    coffees["Capuccino"]++;
                }
                else if (firstCoffee + lastMilk == 150)
                {
                    coffees["Americano"]++;
                }
                else if (firstCoffee + lastMilk == 200)
                {
                    coffees["Latte"]++;
                }
                else
                {
                    milkQuantities.Push(lastMilk - 5);
                }
            }

            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuantities.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine("Coffee left: " + string.Join(", ", coffeeQuantities));
            }

            if (milkQuantities.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Milk left: " + string.Join(", ", milkQuantities));
            }

            coffees = coffees.OrderBy(d => d.Value).ThenByDescending(d => d.Key).ToDictionary(d => d.Key, d => d.Value);

            foreach (var (coffeeName, coffeeCount) in coffees)
            {
                if (coffeeCount > 0)
                {
                    Console.WriteLine($"{coffeeName}: {coffeeCount}");
                }
            }
        }
    }
}