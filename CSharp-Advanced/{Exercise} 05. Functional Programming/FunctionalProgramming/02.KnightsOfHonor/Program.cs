var action = (string name) => Console.WriteLine($"Sir {name}");

foreach (var name in Console.ReadLine().Split(" ").ToArray())
{
    action(name);
}