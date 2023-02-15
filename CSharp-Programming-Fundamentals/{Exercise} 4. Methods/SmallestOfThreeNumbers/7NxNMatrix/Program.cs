using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class NxNMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            MiddleSymbol(n);
        }

        static void MiddleSymbol(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
            }
        }
    }
}