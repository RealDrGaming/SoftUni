Queue<int> queue = new Queue<int>();

int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n = inputs[0];
int s = inputs[1];
int x = inputs[2];

int[] stackInputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

for (int i = 0; i < n; i++)
{
    queue.Enqueue(stackInputs[i]);
}

for (int i = 0; i < s; i++)
{
    queue.Dequeue();
}

if (queue.Contains(x))
{
    Console.WriteLine(queue.Contains(x).ToString().ToLower());
}
else if (queue.Count > 0)
{
    Console.WriteLine(queue.Min());
}
else if (queue.Count == 0)
{
    Console.WriteLine('0');
}