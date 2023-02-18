int[] rowsNCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

string[,] playingField = new string[rowsNCols[0], rowsNCols[1]];

int playerRow = 0;
int playerCol = 0;

ReadMatrix(playingField);

int movesTotal = 0;
int targetsTouched = 0;

string command = Console.ReadLine();

while (command != "Finish" && targetsTouched < 3)
{
    if (command == "up" && playerRow - 1 >= 0 && playerRow - 1 < playingField.GetLength(0) && playingField[playerRow - 1, playerCol] != "O")
    {
        playerRow--;
        movesTotal++;
    }
    else if (command == "down" && playerRow + 1 >= 0 && playerRow + 1 < playingField.GetLength(0) && playingField[playerRow + 1, playerCol] != "O")
    {
        playerRow++;
        movesTotal++;
    }
    else if (command == "left" && playerCol - 1 >= 0 && playerCol - 1 < playingField.GetLength(1) && playingField[playerRow, playerCol - 1] != "O")
    {
        playerCol--;
        movesTotal++;
    }
    else if (command == "right" && playerCol + 1 >= 0 && playerCol + 1 < playingField.GetLength(1) && playingField[playerRow, playerCol + 1] != "O")
    {
        playerCol++;
        movesTotal++;
    }

    if (playingField[playerRow, playerCol] == "P")
    {
        targetsTouched++;
        playingField[playerRow, playerCol] = "-";
    }

    command = Console.ReadLine();
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {targetsTouched} Moves made: {movesTotal}");

void ReadMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col];

            if (matrix[row, col] == "B")
            {
                playerRow = row;
                playerCol = col;
            }
        }
    }
}