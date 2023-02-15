int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

string[,] matrix = new string[n[0], n[1]];

int squaresFound = 0;

ReadMatrix(matrix);

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (row >= matrix.GetLength(0) - 1 || col >= matrix.GetLength(1) - 1)
        {
            continue;
        }
        if (matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col + 1])
        {
            squaresFound++;
        }
    }
}

Console.WriteLine(squaresFound);

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