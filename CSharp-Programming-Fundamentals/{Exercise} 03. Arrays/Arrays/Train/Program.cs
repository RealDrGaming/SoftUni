using System;

namespace Arrays 
{
    class Train 
    {
        static void Main() 
        {
            int numOfWagons = int.Parse(Console.ReadLine());

            int[] wagons = new int[numOfWagons];

            int sumOfPassengers = 0;

            for (int i = 0; i <= wagons.Length - 1; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i <= wagons.Length - 1; i++)
            {
                sumOfPassengers += wagons[i];

                Console.Write($"{wagons[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(sumOfPassengers);
        }
    }
}