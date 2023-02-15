using System;
using System.Linq;

namespace Arrays
{
    class CommonElements
    {
        static void Main()
        {
            string[] array1 = Console.ReadLine().Split().ToArray();
            string[] array2 = Console.ReadLine().Split().ToArray();

            string commonElements = "";

            for (int k = 0; k <= array2.Length - 1; k++)
            {
                for (int l = 0; l <= array1.Length - 1; l++)
                {
                    if (array1[l] == array2[k])
                    {
                        commonElements += array1[l] + ' ';
                    }
                }
            }

            Console.WriteLine(commonElements.Remove(commonElements.Length - 1));
        }
    }
}