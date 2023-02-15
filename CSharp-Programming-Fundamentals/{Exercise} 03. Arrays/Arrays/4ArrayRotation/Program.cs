using System;
using System.Linq;

namespace Arrays
{
    class ArrayRotation
    {
        static void Main()
        {

            string[] arrayString = Console.ReadLine().Split().ToArray();

            int[] array = Array.ConvertAll(arrayString, item => int.Parse(item));

            int rotations = int.Parse(Console.ReadLine());

            int firstNumber = array[0];

            for (int j = 1; j <= rotations; j++)
            {
                firstNumber = array[0];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == array.Last())
                    {
                        array[i] = firstNumber;
                    }
                    else
                    {
                        array[i] = array[i + 1];
                    }
                }
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}