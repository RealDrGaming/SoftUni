using System;
using System.Linq;

namespace Arrays
{
    class ZigZagArrays
    {
        static void Main()
        {
            int args = int.Parse(Console.ReadLine());

            string firstArr = "";
            string secondArr = "";

            for (int i = 1; i <= args; i++)
            {
                string line = Console.ReadLine();

                string[] numbers = new string[2];

                numbers = line.Split().ToArray();

                if (i % 2 != 0)
                {
                    firstArr += numbers[0] + ' ';
                    secondArr += numbers[1] + ' ';
                }
                else
                {
                    firstArr += numbers[1] + ' ';
                    secondArr += numbers[0] + ' ';
                }
            }

            string[] array1 = firstArr.Split().ToArray();
            string[] array2 = secondArr.Split().ToArray();

            Console.WriteLine(string.Join(' ', array1));
            Console.WriteLine(string.Join(' ', array2));    
        }
    }
}