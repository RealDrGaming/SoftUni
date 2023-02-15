using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace FinalExamPrep
{
    class EmojiDetector
    {
        static void Main()
        {
            string input = Console.ReadLine();
            MatchCollection digits = Regex.Matches(input, @"\d");
            MatchCollection emojis = Regex.Matches(input, @"([:*])\1[A-Z][a-z]{2,}\1\1");

            BigInteger coolThreshold = new BigInteger(1);

            foreach (Match digit in digits)
            {
                coolThreshold *= int.Parse(digit.Value);
            }

            List<string> coolEmojis = new List<string>();

            foreach (Match emoji in emojis)
            {
                string emojiString = emoji.Value;
                int emojiValue = 0;
                for (int i = 0; i < emoji.Value.Length; i++)
                {
                    if (char.IsLetter(emojiString[i]))
                        emojiValue += (int)emojiString[i];
                }
                if (emojiValue > coolThreshold)
                    coolEmojis.Add(emojiString);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(String.Join("\n", coolEmojis));
        }
    }
}