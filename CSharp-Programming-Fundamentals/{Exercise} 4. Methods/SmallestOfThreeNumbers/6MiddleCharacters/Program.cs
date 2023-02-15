using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class MiddleCharacters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(MiddleSymbol(input));
        }

        static string MiddleSymbol(string line)
        {
            char[] symbols = line.ToCharArray();

            if (line.Length % 2 == 1)
            {
                return symbols[(int)(line.Length / 2)].ToString();
            }
            else
            {
                return symbols[(int)Math.Floor((line.Length / 2) - 0.1)].ToString() + symbols[(int)(line.Length / 2)].ToString();
            }
        }
    }
}