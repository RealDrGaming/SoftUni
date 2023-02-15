int[] counts = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

HashSet<int> set1 = new HashSet<int>();
HashSet<int> set2 = new HashSet<int>();

for (int i = 0; i < counts[0]; i++)
{
    set1.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < counts[1]; i++)
{
    set2.Add(int.Parse(Console.ReadLine()));
}

set1.IntersectWith(set2);

Console.WriteLine(string.Join(" ", set1));