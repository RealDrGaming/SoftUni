using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class MirrorWorlds
    {
        static void Main()
        {
            string patern = @"(\@|\#)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            Regex regex = new Regex(patern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            Dictionary<string, string> mirrorWorlds = new Dictionary<string, string>();

            foreach (Match match in matches) 
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;

                if (firstWord == string.Join("", secondWord.ToCharArray().Reverse().ToArray()))
                {
                    mirrorWorlds[firstWord] = secondWord;
                }
            }

            if (matches.Count <= 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (mirrorWorlds.Count <= 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(String.Join(", ", mirrorWorlds.Select(x => $"{x.Key} <=> {x.Value}")));
            }
        }
    }
}