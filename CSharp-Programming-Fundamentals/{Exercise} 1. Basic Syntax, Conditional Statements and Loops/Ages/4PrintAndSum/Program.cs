using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main()
        {
            int startN = int.Parse(Console.ReadLine());
            int endN = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startN; i <= endN; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}