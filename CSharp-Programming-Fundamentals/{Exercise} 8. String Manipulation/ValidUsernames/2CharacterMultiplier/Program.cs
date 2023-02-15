using System;
using System.Linq;
using System.Collections.Generic;

namespace ValidUsernames
{
    class CharacterMultiplier
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split(" ");

            Console.WriteLine(MultiplyCharacter(line[0], line[1]));
        }

        static int MultiplyCharacter(string word1, string word2) 
        {
            int sum = 0;

            if (word1.Length <= word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    sum += word1[i] * word2[i];
                }

                string charsLeft = word2.Substring(word1.Length);

                for (int i = 0; i < charsLeft.Length; i++)
                {
                    sum += charsLeft[i];
                }
            }
            else
            {
                for (int i = 0; i < word2.Length; i++)
                {
                    sum += word1[i] * word2[i];
                }

                string charsLeft = word1.Substring(word2.Length);

                for (int i = 0; i < charsLeft.Length; i++)
                {
                    sum += charsLeft[i];
                }
            }

            return sum;
        }
    }
}