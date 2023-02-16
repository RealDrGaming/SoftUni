Dictionary<int, int> numbers = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int currNumber = int.Parse(Console.ReadLine());

    if (!numbers.ContainsKey(currNumber))
    {
        numbers.Add(currNumber, 0);
    }

    numbers[currNumber]++;
}

Console.WriteLine(numbers.Single(n => n.Value % 2 == 0).Key);