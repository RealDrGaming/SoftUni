var action = (string name) => Console.WriteLine(name);

foreach (var name in Console.ReadLine().Split(" ").ToArray())
{
    action(name);
}