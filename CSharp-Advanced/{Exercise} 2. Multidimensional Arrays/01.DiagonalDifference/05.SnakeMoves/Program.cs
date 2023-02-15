int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

string word = Console.ReadLine();

int rows = n[0];
int cols = n[1];

char[,] matrix = new char[rows, cols];

int currIndex = 0;

for (int row = 0; row < rows; row++)
{
	if (row % 2 == 0)
	{
		for (int col = 0; col < cols; col++)
		{
			if (currIndex == word.Length)
			{
				currIndex = 0;
			}

			matrix[row, col] = word[currIndex];

			currIndex++;
		}
	}
	else
	{
		for (int col = cols - 1; col >= 0; col--)
		{
            if (currIndex == word.Length)
            {
                currIndex = 0;
            }

            matrix[row, col] = word[currIndex];

            currIndex++;
        }
	}
}

PrintMatrix(matrix);

void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]}");
        }

        Console.WriteLine();
    }
}