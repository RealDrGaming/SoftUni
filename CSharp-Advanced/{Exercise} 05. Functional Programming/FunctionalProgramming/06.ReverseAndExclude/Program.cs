Func<int, List<int>, List<int>> devideBy = (n, numbers) =>
{
    List<int> result = new();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        if (numbers[i] % n != 0)
        {
            result.Add(numbers[i]);
        }
    }

    return result;
};

List<int> numbers = new List<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList());

int devider = int.Parse(Console.ReadLine());

Console.WriteLine(String.Join(" ", devideBy(devider, numbers)));