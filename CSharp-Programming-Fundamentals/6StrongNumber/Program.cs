using System;

namespace StrongNumber
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int factorialSum = 0;

            int numberCopy = number;
            while (numberCopy > 0)
            {
                int lastDigit = numberCopy % 10;
                numberCopy /= 10;

                int factorial = 1;

                for (int i = 2; i <= lastDigit; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
            }

            if (factorialSum == number) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}