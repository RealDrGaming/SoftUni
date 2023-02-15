using System;

namespace BackInThirtyMinutes
{
    class Program
    {
        static void Main()
        {
            int hourRn = int.Parse(Console.ReadLine());
            int minRn = int.Parse(Console.ReadLine());

            int minAfter = minRn + 30;
            int hourAfter = hourRn;

            if (minAfter >= 60)
            {
                minAfter -= 60;
                hourAfter++;
            }

            if (hourAfter >= 24) hourAfter = 0;

            Console.WriteLine($"{hourAfter}:{minAfter:D2}");
        }
    }
}