Stack<char> openingParenthesis = new Stack<char>();
string inputLine = Console.ReadLine();

foreach (char symbol in inputLine)
{
	if (symbol == '(' || symbol == '[' || symbol == '{')
	{
		openingParenthesis.Push(symbol);
	}
	else if (symbol == ')')
	{
		if (openingParenthesis.Count == 0 || openingParenthesis.Pop() != '(')
		{
			Console.WriteLine("NO");
            return;
        }
    }
    else if (symbol == ']')
    {
        if (openingParenthesis.Count == 0 || openingParenthesis.Pop() != '[')
        {
            Console.WriteLine("NO");
            return;
        }
    }
    else if (symbol == '}')
    {
        if (openingParenthesis.Count == 0 || openingParenthesis.Pop() != '{')
        {
            Console.WriteLine("NO");
            return;
        }
    }
}

Console.WriteLine("YES");