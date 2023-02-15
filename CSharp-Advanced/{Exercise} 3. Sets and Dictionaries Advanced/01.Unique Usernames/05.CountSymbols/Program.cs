SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

string line = Console.ReadLine();

foreach (char symbol in line)
{
	if (!symbols.ContainsKey(symbol))
	{
		symbols.Add(symbol, 0);
	}

	symbols[symbol]++;
}

foreach (var (symbol, times) in symbols)
{
	Console.WriteLine($"{symbol}: {times} time/s");
}