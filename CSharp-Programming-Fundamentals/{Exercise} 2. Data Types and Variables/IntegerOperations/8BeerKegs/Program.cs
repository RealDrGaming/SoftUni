using System;

namespace IntegerOperations
{
    class BeerKegs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            decimal biggestKegVolume = decimal.MinValue;

            string biggestKegModel = "";

            for (int i = 1; i <= n; i++)
            {
                string kegModel = Console.ReadLine();
                decimal kegRadius = decimal.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                decimal kegVolume = (decimal)(Math.PI * kegHeight) * kegRadius * kegRadius;

                if (kegVolume > biggestKegVolume)
                {
                    biggestKegVolume = kegVolume;
                    biggestKegModel = kegModel;
                }
            }

            Console.WriteLine(biggestKegModel);
        }
    }
}