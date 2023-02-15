Stack<int> stack = new Stack<int>();

int queryNum = int.Parse(Console.ReadLine());

for (int i = 0; i < queryNum; i++)
{
    int[] queries = Console.ReadLine().Split().Select(int.Parse).ToArray();

	if (queries[0] == 1)
	{
		stack.Push(queries[1]);
	}
	else if (queries[0] == 2)
	{
		stack.Pop();
	}
	else if (queries[0] == 3 && stack.Count > 0)
	{
		Console.WriteLine(stack.Max());
	}
    else if (queries[0] == 4 && stack.Count > 0)
    {
        Console.WriteLine(stack.Min());
    }
}

Console.WriteLine(string.Join(", ", stack));