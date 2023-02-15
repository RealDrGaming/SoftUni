int n = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[n][];

ReadJaggedArray(jaggedArray);

for (int i = 0; i < n; i++)
{
    if (i != jaggedArray.Length - 1)
    {
        if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] *= 2;
                jaggedArray[i + 1][j] *= 2;
            }
        }
        else
        {
            for (int f = 0; f < jaggedArray[i].Length; f++)
            {
                jaggedArray[i][f] /= 2;
            }
            for (int r = 0; r < jaggedArray[i + 1].Length; r++)
            {
                jaggedArray[i + 1][r] /= 2;
            }
        }
    }
}

string command = Console.ReadLine();

while (command != "End")
{
    string[] commandInfo = command.Split();
    string commandName = commandInfo[0];

    if (commandName == "Add")
    {
        int row = int.Parse(commandInfo[1]);
        int col = int.Parse(commandInfo[2]);
        int value = int.Parse(commandInfo[3]);

        if (row >= 0 && row < jaggedArray.Length)
        {
            if (col >= 0 && col < jaggedArray[row].Length)
            {
                jaggedArray[row][col] += value;
            }
        }
    }
    else if (commandName == "Subtract")
    {
        int row = int.Parse(commandInfo[1]);
        int col = int.Parse(commandInfo[2]);
        int value = int.Parse(commandInfo[3]);

        if (row >= 0 && row < jaggedArray.Length)
        {
            if (col >= 0 && col < jaggedArray[row].Length)
            {
                jaggedArray[row][col] -= value;
            }
        }
    }

    command = Console.ReadLine();
}

PrintJaggedArray(jaggedArray);

void PrintJaggedArray(int[][] jaggedArray)
{
    foreach (int[] row in jaggedArray)
    {
        Console.WriteLine(string.Join(" ", row));
    }
}

void ReadJaggedArray(int[][] jaggedArray)
{
    for (int row = 0; row < jaggedArray.Length; row++)
    {
        jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
    }
}