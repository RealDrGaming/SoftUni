using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class PalindromeIntegers
    {
        static void Main()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                Console.WriteLine(IsPalindromeOrNot(command));

                command = Console.ReadLine();
            }
        }

        static string IsPalindromeOrNot(string line)
        {
            char[] symbols = line.ToCharArray();
            char[] symbolsCopy = line.ToCharArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                symbolsCopy[i] = symbols[symbols.Length - (i + 1)];
            }

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = symbolsCopy[i];
            }

            if (String.Join("", symbols) == line)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}