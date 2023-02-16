using DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person peter = new()
        {
            Name = "Peter",
            Age = 20
        };

        Person yordan = new()
        {
            Name = "Yordan",
            Age = 18
        };

        Console.WriteLine($"{peter.Name} is {peter.Age} years old");
        Console.WriteLine($"{yordan.Name} is {yordan.Age} years old");
    }
}