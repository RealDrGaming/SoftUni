using System;

namespace IntegerOperations
{
    class SumOfChars
    {
        static void Main()
        {
            int numOfLines = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= numOfLines; i++)
            {
                sum += Convert.ToChar(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}