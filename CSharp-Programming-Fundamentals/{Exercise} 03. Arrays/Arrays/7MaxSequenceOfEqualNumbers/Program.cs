using System;
using System.Linq;

namespace Arrays
{
    class MaxSequenceOfEqualNumbers
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestSequenceCharacter = 0;

            int count = 1;

            int longestNum = array[0];

            int longestCount = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                {
                    count = 0;
                }

                count++;

                if (count > longestCount)
                {
                    longestCount = count;
                    longestNum = array[i];
                }
            }
            Console.WriteLine(string.Join(" ", Enumerable.Repeat(longestNum, longestCount)));
        }
    }
}