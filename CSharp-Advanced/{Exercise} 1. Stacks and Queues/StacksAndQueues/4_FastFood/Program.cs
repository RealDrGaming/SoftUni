Queue<int> queue = new Queue<int>();

int dayQuantity = int.Parse(Console.ReadLine());

int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

foreach (int order in orders)
{
    queue.Enqueue(order);
}

Console.WriteLine(queue.Max());

while (queue.Count != 0)
{
	if (dayQuantity >= queue.Peek())
	{
		dayQuantity -= queue.Dequeue();
	}
	else
	{
		break;
	}
}

if (queue.Count == 0)
{
	Console.WriteLine("Orders complete");
}
else
{
	Console.WriteLine("Orders left: " + string.Join(" ", queue));
}