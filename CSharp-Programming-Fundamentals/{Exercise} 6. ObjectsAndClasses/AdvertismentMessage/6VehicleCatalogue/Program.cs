using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertismentMessage
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            AddVehicles(vehicles);

            PrintVehicles(vehicles);

            PrintAverageHP(vehicles);
        }

        static void AddVehicles(List<Vehicle> vehicles)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] vehicleArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vehicleType = vehicleArgs[0];

                if (vehicleType == "car")
                {
                    vehicleType = "Car";
                }
                else if (vehicleType == "truck")
                {
                    vehicleType = "Truck";
                }

                string vehicleModel = vehicleArgs[1];
                string vehicleColor = vehicleArgs[2];
                int vehicleHP = int.Parse(vehicleArgs[3]);

                Vehicle currVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHP);

                vehicles.Add(currVehicle);
            }
        }

        static void PrintVehicles(List<Vehicle> vehicles)
        {
            string input;

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Vehicle currentVehicle in vehicles)
                {
                    if (ExistsInList(currentVehicle, input))
                    {
                        Console.WriteLine(currentVehicle.ToString());
                        break;
                    }
                }
            }
        }

        static bool ExistsInList(Vehicle vehicle, string model)
        {
            if (vehicle.Model == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void PrintAverageHP(List<Vehicle> vehicles)
        {
            List<Vehicle> cars = vehicles.Where(x => x.Type == "Car").ToList();

            List<Vehicle> trucks = vehicles.Where(x => x.Type == "Truck").ToList();

            double totalCarsHP = 0;

            foreach (Vehicle car in cars)
            {
                totalCarsHP += car.HorsePower;
            }

            double totalTrucksHP = 0;

            foreach (Vehicle truck in trucks)
            {
                totalTrucksHP += truck.HorsePower;
            }

            double averageCarsHP = totalCarsHP / cars.Count;
            double averageTrucksHP = totalTrucksHP / trucks.Count;

            if (cars.Count == 0)
            {
                averageCarsHP = 0.00;
            }
            if (trucks.Count == 0)
            {
                averageTrucksHP = 0.00;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarsHP:f2}.");

            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHP:f2}.");
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Type: {Type}");
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Horsepower: {HorsePower}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}