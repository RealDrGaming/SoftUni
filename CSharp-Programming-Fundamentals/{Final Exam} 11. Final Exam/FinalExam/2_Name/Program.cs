using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace FinalExam
{
    class EncryptingPassword
    {
        static void Main()
        {
            string pattern = @"(.+)\>(?<firstGroup>[1-9]{3})\|(?<secondGroup>[a-z]{3})\|(?<thirdGroup>[A-Z]{3})\|(?<fourthGroup>[^\<\>]{3})\<\1";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();

                Match match = regex.Match(inputLine);

                if (match.Success)
                {
                    string firstGroup = match.Groups["firstGroup"].Value;
                    string secondGroup = match.Groups["secondGroup"].Value;
                    string thirdGroup = match.Groups["thirdGroup"].Value;
                    string fourthGroup = match.Groups["fourthGroup"].Value;

                    StringBuilder sb = new StringBuilder();

                    sb.Append(firstGroup + secondGroup + thirdGroup + fourthGroup);
                    Console.WriteLine($"Password: {sb}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}