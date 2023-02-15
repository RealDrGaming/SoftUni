namespace DefiningClasses;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person()
            {
                Name = tokens[0],
                Age = int.Parse(tokens[1])
            };

            if (person.Age > 30)
            {
                people.Add(person);
            }
        }

        foreach (var person in people.OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}