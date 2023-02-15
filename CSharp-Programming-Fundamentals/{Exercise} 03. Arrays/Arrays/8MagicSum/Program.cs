using System;
using System.Linq;

namespace Arrays
{
    class MagicSum
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int expectedSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (expectedSum - currentNumber == array[j])
                    {
                        Console.WriteLine($"{currentNumber} {array[j]}");
                    }
                }
            }
        }
    }
}