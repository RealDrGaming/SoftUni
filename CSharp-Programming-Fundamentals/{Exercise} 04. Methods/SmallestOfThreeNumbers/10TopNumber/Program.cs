using System;
using System.Globalization;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class TopNumber
    {
        static void Main()
        {
            int endingValue = int.Parse(Console.ReadLine());

            PrintAllTopNumbersTo(endingValue);
        }

        static void PrintAllTopNumbersTo(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (AreDigitsDevisibleBy8(i) && HasOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool AreDigitsDevisibleBy8(int number)
        {
            char[] digits = number.ToString().ToCharArray();

            int sumOfDigits = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sumOfDigits += digits[i];
            }

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool HasOddDigit(int number)
        {
            char[] digits = number.ToString().ToCharArray();

            bool hasOddDigit = false;

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] % 2 == 1)
                {
                    hasOddDigit = true;
                }
            }

            if (hasOddDigit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}