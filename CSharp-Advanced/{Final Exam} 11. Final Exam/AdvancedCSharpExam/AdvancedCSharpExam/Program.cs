Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> meds = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Dictionary<string, int> itemsCreated = new Dictionary<string, int>()
{
    { "Patch", 0 },
    { "Bandage", 0 },
    { "MedKit", 0 },
};

int lastMed = 0;

while (textiles.Count > 0 && meds.Count > 0)
{
    int firstTextile = textiles.Dequeue();

    lastMed = meds.Pop();

    if (firstTextile + lastMed == 30)
    {
        itemsCreated["Patch"]++;
    }
    else if (firstTextile + lastMed == 40)
    {
        itemsCreated["Bandage"]++;
    }
    else if (firstTextile + lastMed == 100)
    {
        itemsCreated["MedKit"]++;
    }
    else if (firstTextile + lastMed > 100)
    {
        itemsCreated["MedKit"]++;

        int unusedResources = firstTextile + lastMed - 100;

        lastMed = meds.Pop();
        meds.Push(lastMed + unusedResources);
    }
    else
    {
        meds.Push(lastMed + 10);
    }
}

if (textiles.Count == 0 && meds.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (textiles.Count == 0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (meds.Count == 0)
{
    Console.WriteLine("Medicaments are empty.");
}

itemsCreated = itemsCreated.OrderByDescending(d => d.Value).ThenBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);

foreach (var (itemName, created) in itemsCreated)
{
    if (created > 0)
    {
        Console.WriteLine($"{itemName} - {created}");
    }
}

if (meds.Count > 0)
{
    Console.WriteLine("Medicaments left: " + string.Join(", ", meds));
}

if (textiles.Count > 0)
{
    Console.WriteLine("Textiles left: " + string.Join(", ", textiles));
}