using System;
using System.Linq;
using System.Collections.Generic;

namespace BiscuitFactory 
{
    class BiscuitFactory 
    {
        static void Main() 
        {
            double numOfBiscuitsPerWorkerDaily = double.Parse(Console.ReadLine());
            double numOfWorkers = double.Parse(Console.ReadLine());
            int competingFactoryBiscuits = int.Parse(Console.ReadLine());

            double totalBiscuits = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 != 0)
                {
                    totalBiscuits += numOfBiscuitsPerWorkerDaily * numOfWorkers;
                }
                else
                {
                    totalBiscuits += Math.Floor((numOfBiscuitsPerWorkerDaily * 0.75d) * numOfWorkers);
                }
            }

            Console.WriteLine($"You have produced {(int)totalBiscuits} biscuits for the past month.");

            if (totalBiscuits > competingFactoryBiscuits)
            {
                double difference = totalBiscuits - competingFactoryBiscuits;
                double percent = (difference / competingFactoryBiscuits) * 100;

                Console.WriteLine($"You produce {percent:F2} percent more biscuits.");
            }
            else
            {
                double difference = competingFactoryBiscuits - totalBiscuits;
                double percent = (difference / competingFactoryBiscuits) * 100;

                Console.WriteLine($"You produce {percent:F2} percent less biscuits.");
            }
        }
    }
}