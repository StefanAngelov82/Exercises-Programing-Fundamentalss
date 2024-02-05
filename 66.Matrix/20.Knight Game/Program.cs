
using System.Data;

int N = int.Parse(Console.ReadLine());

char[][] matrix = new char[N][];

for (int i = 0; i < N; i++)
{
    string input = Console.ReadLine().Trim();

    matrix[i] = new char[input.Length];

    for (int j = 0; j < input.Length ; j++)
    {
        matrix[i][j] = input[j];
    }
}

int removedNights = 0;

while (true)   
{
    int currentHit = 0;
    int maxHit = 0;
    int targetCol = 0;
    int targetRow = 0;

    for (int row = 0; row < matrix.Length; row++)
    {
        for (int col = 0; col < matrix[row].Length; col++)
        {
            if (matrix[row][col] == 'K')
            {
                currentHit = CalculateCurrentHit(matrix, row, col);

                 if (currentHit > maxHit)
                 {
                     maxHit = currentHit;
                     targetCol = col;
                     targetRow = row;
                 }
            }
           
        }
    }

    if (maxHit == 0)
    {
        break;
    }
    else
    {
        matrix[targetRow][targetCol] = 'O';
        removedNights++;
    }
}

Console.WriteLine(removedNights);

static int CalculateCurrentHit(char[][] matrix, int row, int col)
{
    return RightUpUpHit(matrix, row, col) + RightUpLowHit(matrix, row, col) +
          RightLowUpHit(matrix, row, col) + RightLowLowHit(matrix, row, col) +
          LeftUpUpHit(matrix, row, col) + LeftUpLowHit(matrix, row, col) +
          LeftLowUpHit(matrix, row, col) + LeftLowLowHit(matrix, row, col);
}


static int RightUpUpHit(char[][] matrix, int row, int col)
{
    if (row - 2 >= 0 && col + 1 < matrix[row].Length 
        && matrix[row - 2][col + 1 ] == 'K')
    {
        return 1;
    }

    return 0;
}

static int RightUpLowHit(char[][] matrix, int row, int col)
{
    if (row - 1 >= 0 && col + 2 < matrix[row].Length
        && matrix[row - 1][col + 2] == 'K')
    {
        return 1;
    }

    return 0;
}

static int RightLowUpHit(char[][] matrix, int row, int col)
{
    if (row + 2 < matrix.Length && col + 1 < matrix[row].Length
        && matrix[row + 2][col + 1] == 'K')
    {
        return 1;
    }

    return 0;
}
static int RightLowLowHit(char[][] matrix, int row, int col)
{
    if (row + 1 < matrix.Length && col + 2 < matrix[row].Length
        && matrix[row + 1][col + 2] == 'K')
    {
        return 1;
    }

    return 0;
}

static int LeftUpUpHit(char[][] matrix, int row, int col)
{
    if (row - 2 >= 0 && col - 1 >= 0 
        && matrix[row - 2][col - 1] == 'K')
    {
        return 1;
    }

    return 0;
}
static int LeftUpLowHit(char[][] matrix, int row, int col)
{
    if (row - 1 >= 0 && col - 2 >= 0
        && matrix[row - 1][col - 2] == 'K')
    {
        return 1;
    }

    return 0;
}

static int LeftLowUpHit(char[][] matrix, int row, int col)
{
    if (row + 2 < matrix.Length && col - 1 >= 0
        && matrix[row + 2][col - 1] == 'K')
    {
        return 1;
    }

    return 0;
}

static int LeftLowLowHit(char[][] matrix, int row, int col)
{
    if (row + 1 < matrix.Length && col - 2 >= 0
        && matrix[row + 1][col - 2] == 'K')
    {
        return 1;
    }

    return 0;
}