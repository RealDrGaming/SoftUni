using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Furniture 
{
    class Furniture 
    {
        static void Main() 
        {
            string pattern = @">>([A-Z]{1,}[a-z]*)<<(\d+(\.)*\d*)!(\d+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            List<string> boughtFurniture = new List<string>();

            double totalMoney = 0;

            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    boughtFurniture.Add(match.Groups[1].Value);
                    totalMoney += double.Parse(match.Groups[2].Value) * double.Parse(match.Groups[4].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in boughtFurniture)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalMoney:F2}");
        }
    }
}