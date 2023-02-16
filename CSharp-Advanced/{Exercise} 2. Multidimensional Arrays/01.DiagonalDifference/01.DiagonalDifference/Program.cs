int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];

ReadMatrix(matrix);

int leftDiagonal = 0;
int rightDiagonal = 0;

for (int i = 0; i < n; i++)
{
    leftDiagonal += matrix[i, i];
}

for (int i = 0; i < n; i++)
{
    rightDiagonal += matrix[i, n - i - 1];
}

Console.WriteLine(Math.Abs(leftDiagonal - rightDiagonal));

void ReadMatrix(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col];
        }
    }
}