int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

/* Read a matrix from the console in the format:
 * 
 * 1 2 3 4
 * 4 3 2 1
 * 1 2 3 4
 * 4 3 2 1
 * 
 */

void ReadMatrix(int[,] matrix, string separator)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        int[] rowData = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col];
        }
    }
}

//Print matrix

void PrintMatrix<T>(T[,] matrix)
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