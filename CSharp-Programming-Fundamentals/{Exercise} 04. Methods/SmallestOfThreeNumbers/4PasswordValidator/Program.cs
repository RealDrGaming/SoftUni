using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class PasswordValidator
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (!IsBetweenSixAndTen(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ConsistsOfLettersAndDigitsOnly(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!HasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (IsBetweenSixAndTen(input) && ConsistsOfLettersAndDigitsOnly(input) && HasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsBetweenSixAndTen(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        static bool ConsistsOfLettersAndDigitsOnly(string pass)
        {
            char[] symbolsInPass = pass.ToCharArray();

            int symbolsValidated = 0;

            foreach (char symbol in symbolsInPass)
            {
                if (symbol >= 48 && symbol <= 57)
                {
                    symbolsValidated++;
                }
                else if (symbol >= 65 && symbol <= 90)
                {
                    symbolsValidated++;
                }
                else if (symbol >= 97 && symbol <= 122)
                {
                    symbolsValidated++;
                }
            }

            if (symbolsValidated == pass.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool HasAtLeastTwoDigits(string pass)
        {
            char[] symbolsInPass = pass.ToCharArray();

            int numOfDigits = 0;

            foreach (char symbol in symbolsInPass)
            {
                if (symbol >= 48 && symbol <= 57)
                {
                    numOfDigits++;
                }
            }

            if (numOfDigits >= 2)
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