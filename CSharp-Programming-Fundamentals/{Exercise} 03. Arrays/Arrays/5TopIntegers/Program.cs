using System;
using System.Linq;

namespace Arrays
{
    class ArrayRotation
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                bool isTopInteger = true;

                for (int j = i + 1; j < array.Length; j++)
                {
                    int nextNumber = array[j];
                    if (nextNumber >= currentNumber)
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger) 
                {
                    Console.Write($"{currentNumber} ");
                }
            }
        }
    }
}