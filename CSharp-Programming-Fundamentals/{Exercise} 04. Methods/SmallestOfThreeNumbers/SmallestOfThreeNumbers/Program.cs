using System;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        static void Main() 
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintSmallestNumbersOfThree(num1, num2, num3));
        }

        static int PrintSmallestNumbersOfThree(int num1, int num2, int num3) 
        {
            if (num1 <= num2 && num1 <= num3)
            {
                return num1;
            }
            else if (num2 <= num1 && num2 <= num3) 
            {
                return num2;
            }
            else if (num3 <= num1 && num3 <= num2)
            {
                return num3;
            }
            else
            {
                return 0;
            }
        }
    }
}