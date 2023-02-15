using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class FactorialDivision
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{DevideFactorial(num1, num2):F2}");
        }

        static double DevideFactorial(int number1, int number2)
        {
            double factorial1 = 1;
            double factorial2 = 1;

            for (int i = 2; i <= number1; i++)
            {
                factorial1 *= i;
            }

            for (int j = 2; j <= number2; j++)
            {
                factorial2 *= j;
            }

            double devision = factorial1 / factorial2;

            return devision;
        }
    }
}