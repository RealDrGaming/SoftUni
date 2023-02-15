Stack<int> stack = new Stack<int>();

int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n = inputs[0];
int s = inputs[1];
int x = inputs[2];

int[] stackInputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

for (int i = 0; i < n; i++)
{
    stack.Push(stackInputs[i]);
}

for (int i = 0; i < s; i++)
{
    stack.Pop();
}

if (stack.Contains(x))
{
    Console.WriteLine(stack.Contains(x).ToString().ToLower());
}
else if(stack.Count > 0)
{
    Console.WriteLine(stack.Min());
}
else if (stack.Count == 0)
{
    Console.WriteLine('0');
}