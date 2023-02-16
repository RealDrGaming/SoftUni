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

/* 
 * 
 * Print matrix 
 * 
 */

void PrintMatrix(int[,] matrix)
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

/* 
 * 
 * Jagged array - initialization
 * ___ ___ ___
 * |1| |2| |3|
 * ___ ___
 * |4| |5|
 * 
 */

int[][] jaggedArray = new int[2][];

jaggedArray[0] = new int[3];
jaggedArray[1] = new int[2];

jaggedArray[0][0] = 1;
jaggedArray[0][1] = 2;
jaggedArray[0][2] = 3;

jaggedArray[1][0] = 4;
jaggedArray[1][1] = 5;

/*
 * 
 * Read jagged array
 * 
 */

void ReadJaggedArray(int[][] jaggedArray, string separator)
{
    for (int row = 0; row < jaggedArray.Length; row++)
    {
        jaggedArray[row] = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
}

/*
 * 
 * Print jagged array
 * 
 */

void PrintJaggedArray(int[][] jaggedArray)
{
    foreach (int[] row in jaggedArray)
    {
        Console.WriteLine(string.Join(" ", row));
    }
}