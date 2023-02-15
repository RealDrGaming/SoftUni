Func<int[], int> minFunc = (numbers) =>
{
    int smallestNum = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < smallestNum)
        {
            smallestNum = number;
        }
    }

    return smallestNum;
};

int[] input = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(minFunc(input));