using System.Net.Cache;

namespace DefiningClasses;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person()
            {
                Name = tokens[0],
                Age = int.Parse(tokens[1])
            };

            family.AddMember(person);
        }

        Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
    }
}