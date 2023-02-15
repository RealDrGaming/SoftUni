using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class AddAndSubtract
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sumOf1And2 = AddNumbers(num1, num2);

            int diferenceOfSumAnd3 = SubtractNumbers(sumOf1And2, num3);

            Console.WriteLine(diferenceOfSumAnd3);
        }

        static int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
        static int SubtractNumbers(int number1, int number2)
        {
            return number1 - number2;
        }
    }
}