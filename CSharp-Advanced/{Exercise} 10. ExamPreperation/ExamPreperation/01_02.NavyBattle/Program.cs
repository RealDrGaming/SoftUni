using System.Data;

int size = int.Parse(Console.ReadLine());

string[,] battlefieldMatrix = new string[size, size];

int submarineRow = 0;
int submarineCol = 0;

int subHP = 3;
int cruisersAlive = 3;

ReadMatrix(battlefieldMatrix);

while (subHP > 0 && cruisersAlive > 0)
{
    string command = Console.ReadLine().ToLower();

    battlefieldMatrix[submarineRow, submarineCol] = "-";

    if (command == "up")
    {
        submarineRow--;
    }
    else if (command == "down")
    {
        submarineRow++;
    }
    else if (command == "right")
    {
        submarineCol++;
    }
    else if (command == "left")
    {
        submarineCol--;
    }

    if (battlefieldMatrix[submarineRow, submarineCol] == "*")
    {
        battlefieldMatrix[submarineRow, submarineCol] = "-";
        subHP--;
    }
    else if (battlefieldMatrix[submarineRow, submarineCol] == "C")
    {
        battlefieldMatrix[submarineRow, submarineCol] = "-";
        cruisersAlive--;
    }
}

if (subHP > 0)
{
    if (cruisersAlive == 0)
    {
        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
    }
}
else
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
}

battlefieldMatrix[submarineRow, submarineCol] = "S";
PrintMatrix<string>(battlefieldMatrix);

void ReadMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        string rowData = Console.ReadLine();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col].ToString();

            if (rowData[col].ToString() == "S")
            {
                submarineRow = row;
                submarineCol = col;
            }
        }
    }
}

void PrintMatrix<T>(T[,] matrix)
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