using System;

namespace IntegerOperations
{
    class IntegerOperations
    {
        static void Main() 
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            int sum = (num1 + num2);
            sum = (int)(sum / num3);
            sum = (int)(sum * num4);

            Console.WriteLine(sum);
        }
    }
}