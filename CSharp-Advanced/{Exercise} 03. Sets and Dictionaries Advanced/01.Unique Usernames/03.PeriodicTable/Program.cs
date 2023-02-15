int n = int.Parse(Console.ReadLine());

HashSet<string> elements = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    for (int j = 0; j < line.Length; j++)
    {
        elements.Add(line[j]);
    }
}

elements = elements.OrderBy(x => x).ToHashSet();

Console.Write(string.Join(" ", elements));