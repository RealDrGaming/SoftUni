using System.Text;

int n = int.Parse(Console.ReadLine());

string text = string.Empty;

Stack<string> lastChanges = new();

for (int i = 0; i < n; i++)
{
    string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

	if (commandInfo[0] == "1")
	{
        lastChanges.Push(text);

        text += commandInfo[1];
    }
	else if (commandInfo[0] == "2")
	{
        lastChanges.Push(text);

        int count = int.Parse(commandInfo[1]);

        text = text.Remove(text.Length - count);
	}
    else if (commandInfo[0] == "3")
    {
        int index = int.Parse(commandInfo[1]) - 1;

        Console.WriteLine(text[index]);
    }
    else if (commandInfo[0] == "4")
    {
        text = lastChanges.Pop();
    }
}