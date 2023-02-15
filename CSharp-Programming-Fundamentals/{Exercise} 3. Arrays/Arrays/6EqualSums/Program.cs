using System;
using System.Linq;

namespace Arrays
{
    class EqualSums
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isThereANumber = false;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                int rightSum = 0;
                int leftSum = 0;

                for (int j = i + 1; j < array.Length; j++)
                {
                    rightSum += array[j];
                }

                for (int k = 0; k < i; k++)
                {
                    leftSum += array[k];
                }

                if (leftSum == rightSum)
                {
                    isThereANumber = true;
                    Console.WriteLine($"{Array.IndexOf(array, currentNumber)} ");
                }
            }

            if (!isThereANumber) Console.WriteLine("no");
        }
    }
}