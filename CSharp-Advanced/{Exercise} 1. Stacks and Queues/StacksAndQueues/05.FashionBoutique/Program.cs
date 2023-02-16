Stack<int> clothes = new (Console.ReadLine().Split().Select(int.Parse));

int originalCapacity = int.Parse(Console.ReadLine());
int rackCapacity = originalCapacity;

int rackNumber = 1;

while(clothes.Count != 0)
{
    rackCapacity -= clothes.Peek();

	if (rackCapacity < 0)
	{
		rackCapacity = originalCapacity;
		rackNumber++;

		continue;
	}
    clothes.Pop();
}

Console.WriteLine(rackNumber);