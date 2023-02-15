Predicate<int> isEven = (number) => number % 2 == 0;

int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string needEvenOrOdd = Console.ReadLine();

if (needEvenOrOdd == "even")
{
    for (int i = input[0]; i <= input[1]; i++)
    {
        if (isEven(i))
        {
            Console.Write($"{i} ");
        }
    }
}
else if (needEvenOrOdd == "odd")
{
    for (int i = input[0]; i <= input[1]; i++)
    {
        if (isEven(i) == false)
        {
            Console.Write($"{i} ");
        }
    }
}