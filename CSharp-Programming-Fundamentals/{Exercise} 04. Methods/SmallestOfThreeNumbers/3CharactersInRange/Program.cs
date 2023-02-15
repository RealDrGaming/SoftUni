using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class CharactersInRange
    {
        static void Main()
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintAsciiBetween(start, end);
        }

        static void PrintAsciiBetween(char startingChar, char endingChar)
        {
            if (startingChar < endingChar)
            {
                for (int i = startingChar + 1; i < endingChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else if (startingChar > endingChar)
            {
                for (int i = endingChar + 1; i < startingChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}