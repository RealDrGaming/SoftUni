using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class VowelsCount
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(CountVowels(input));
        }

        static int CountVowels(string word) 
        {
            char[] letters = word.ToLower().ToCharArray();

            int vowelsCount = 0;

            foreach (char letter in letters)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}