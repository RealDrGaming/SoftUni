using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FinalExamPrep
{
    class DestinationMapper
    {
        static void Main()
        {
            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            int destPoints = 0;
            List<string> destinations = new List<string>();

            foreach (Match match in matches)
            {
                string matchDestination = match.Groups["destination"].Value;

                destPoints += matchDestination.Length;

                destinations.Add(matchDestination);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {destPoints}");
        }
    }
}