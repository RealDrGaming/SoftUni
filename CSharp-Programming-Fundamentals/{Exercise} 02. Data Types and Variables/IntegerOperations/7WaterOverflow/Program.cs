using System;

namespace IntegerOperations
{
    class WaterOverflow
    {
        static void Main()
        {
            sbyte n = sbyte.Parse(Console.ReadLine());

            ushort capacityLeft = 255;

            for (int i = 0; i < n; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine());

                if (capacityLeft >= liters)
                {
                    capacityLeft -= liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(255 - capacityLeft);
        }
    }
}