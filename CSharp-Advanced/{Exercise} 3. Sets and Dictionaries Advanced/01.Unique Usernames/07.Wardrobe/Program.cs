int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(new string[] { " -> ", ","}, StringSplitOptions.RemoveEmptyEntries).ToArray();

    string color = input[0];

    if (!clothes.ContainsKey(color))
    {
        clothes.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < input.Length; j++)
    {
        string currentClothing = input[j];

        if (!clothes[color].ContainsKey(currentClothing))
        {
            clothes[color].Add(currentClothing, 0);
        }

        clothes[color][currentClothing]++;
    }
}

string[] findInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var color in clothes)
{
    Console.WriteLine($"{color.Key} clothes:");

    foreach (var cloth in color.Value)
    {
        string printItem = $"* {cloth.Key} - {cloth.Value}";

        if (color.Key == findInput[0] && cloth.Key == findInput[1])
        {
            printItem += " (found!)";
        }

        Console.WriteLine(printItem);
    }
}