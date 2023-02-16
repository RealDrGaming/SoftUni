int size = int.Parse(Console.ReadLine());

if (size < 3)
{
    Console.WriteLine(0);
    return;
}

char[,] matrix = new char[size, size];

ReadMatrix(matrix);

int changedKnights = 0;

while (true)
{
    int countMostAttacking = 0;
    int rowMostAttacking = 0;
    int colMostAttacking = 0;

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            if (matrix[row, col] == 'K')
            {
                int attackedKnights = CountAttackedKnights(row, col);

                if (countMostAttacking < attackedKnights)
                {
                    countMostAttacking = attackedKnights;
                    rowMostAttacking = row;
                    colMostAttacking = col;
                }
            }
        }
    }

    if (countMostAttacking == 0)
    {
        break;
    }
    else
    {
        matrix[rowMostAttacking, colMostAttacking] = '0';
        changedKnights++;
    }
}

Console.WriteLine(changedKnights);

int CountAttackedKnights(int row, int col)
{
    int attackedKnights = 0;

    //horizontal left-up
    if (IsCellValid(row - 1, col - 2))
    {
        if (matrix[row - 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    //horizontal left-down
    if (IsCellValid(row + 1, col - 2))
    {
        if (matrix[row + 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    //horizontal right-up
    if (IsCellValid(row - 1, col + 2))
    {
        if (matrix[row - 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    //horizontal right-down
    if (IsCellValid(row + 1, col + 2))
    {
        if (matrix[row + 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    //vertical up-left
    if (IsCellValid(row - 2, col - 1))
    {
        if (matrix[row - 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    //vertical up-right
    if (IsCellValid(row - 2, col + 1))
    {
        if (matrix[row - 2, col + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    //vertical down-left
    if (IsCellValid(row + 2, col - 1))
    {
        if (matrix[row + 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    //vertical down-right
    if (IsCellValid(row + 2, col + 1))
    {
        if (matrix[row + 2, col + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    return attackedKnights;
}

bool IsCellValid(int row, int col)
{
    return
        row >= 0
        && row < size
        && col >= 0
        && col < size;
}

void ReadMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        string rowData = Console.ReadLine();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = rowData[col];
        }
    }
}