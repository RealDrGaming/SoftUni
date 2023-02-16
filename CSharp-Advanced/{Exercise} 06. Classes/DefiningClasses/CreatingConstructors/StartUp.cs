using DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person peter = new Person();

        Person yordan = new Person(18);

        Person galina = new Person("Galina", 19);

        Console.WriteLine($"{peter.Name} is {peter.Age} years old");
        Console.WriteLine($"{yordan.Name} is {yordan.Age} years old");
        Console.WriteLine($"{galina.Name} is {galina.Age} years old");
    }
}