int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

string[,] matrix = new string[n[0], n[1]];

ReadMatrix(matrix);

string command = Console.ReadLine();

while (command != "END")
{
    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string commandName = commandInfo[0];

    string temp = string.Empty;

    if (commandName == "swap" && commandInfo.Length == 5)
    {
        int row1 = int.Parse(commandInfo[1]);
        int col1 = int.Parse(commandInfo[2]);
        int row2 = int.Parse(commandInfo[3]);
        int col2 = int.Parse(commandInfo[4]);
        

        if (row1 >= 0 && row1 < matrix.GetLength(0) && row2 >= 0 && row2 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1) && col2 >= 0 && col2 < matrix.GetLength(1))
        {
            temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;

            PrintMatrix(matrix);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }

    command = Console.ReadLine();
}

void ReadMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        string[] rowData = Console.ReadLine().Split().ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col];
        }
    }
}

void PrintMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }

        Console.WriteLine();
    }
}