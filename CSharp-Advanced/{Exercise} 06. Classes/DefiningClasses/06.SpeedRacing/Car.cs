namespace DefiningClasses;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double travelledDistance;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public double FuelPerKilometer
    {
        get { return fuelConsumptionPerKilometer; }
        set { fuelConsumptionPerKilometer = value; }
    }

    public double TravelledDistance { get { return travelledDistance; } set { travelledDistance = value; } }

    public void Drive(double distance)
    {
        if (distance * FuelPerKilometer > fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelAmount -= distance * FuelPerKilometer;
            TravelledDistance += distance;
        }
    }
}