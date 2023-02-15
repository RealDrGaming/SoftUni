using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    class NeedForSpeedIII
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split("|");

                Car car = new Car();
                car.Mileage = int.Parse(args[1]);
                car.Fuel = int.Parse(args[2]);

                cars.Add(args[0], car);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commandInfo = command.Split(" : ");
                string commandName = commandInfo[0];
                string carName = commandInfo[1];

                if (commandName == "Drive")
                {
                    int distance = int.Parse(commandInfo[2]);
                    int fuel = int.Parse(commandInfo[3]);

                    if (cars[carName].Fuel >= fuel)
                    {
                        cars[carName].Fuel -= fuel;
                        cars[carName].Mileage += distance;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (cars[carName].Mileage >= 100000)
                    {
                        cars.Remove(carName);

                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }
                else if (commandName == "Refuel")
                {
                    int fuel = int.Parse(commandInfo[2]);

                    int actualFuel = Math.Min(fuel, 75 - cars[carName].Fuel);
                    
                    Console.WriteLine($"{carName} refueled with {actualFuel} liters");

                    cars[carName].Fuel += actualFuel;

                }
                else if (commandName == "Revert")
                {
                    int kilometers = int.Parse(commandInfo[2]);

                    if (cars[carName].Mileage - kilometers >= 10000)
                    {
                        cars[carName].Mileage -= kilometers;
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                    else
                    {
                        cars[carName].Mileage = 10000;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var (carName, car) in cars)
            {
                Console.WriteLine($"{carName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}