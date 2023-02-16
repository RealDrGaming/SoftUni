using System.Data;
using System.Xml.Schema;

namespace DefiningClasses;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = input[0];
            double fuelAmount = double.Parse(input[1]);
            double consumptionPerKilometer = double.Parse(input[2]);

            Car car = new Car()
            {
                Model = model,
                FuelAmount = fuelAmount,
                FuelPerKilometer = consumptionPerKilometer,
                TravelledDistance = 0
            };

            cars.Add(car.Model, car);
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (commandInfo[0] == "Drive")
            {
                string model = commandInfo[1];
                double kilometers = double.Parse(commandInfo[2]);

                Car car = cars[model];

                car.Drive(kilometers);
            }

            command = Console.ReadLine();
        }

        foreach (Car car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}