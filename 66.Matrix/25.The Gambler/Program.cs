int N = int.Parse(Console.ReadLine());

char[][] matrix =  new char[N][];

int currentRow = - 1;
int currentCol =  - 1;
int cash = 100;
bool IsWin = false;
bool IsOutOfBoundery = false;


for (int i = 0; i < N; i++)
{
    matrix[i] = Console.ReadLine().Trim().ToCharArray();    
}

InitialGamblerPosition(matrix, ref currentRow, ref currentCol);

string input = string.Empty;

while ( cash > 0 && !IsWin && (input = Console.ReadLine().Trim()) != "end")
{
    matrix[currentRow][currentCol] = '-';

    Direction direction = (Direction)Enum.Parse(typeof(Direction), input);

    switch (direction)
    {
        case Direction.up:
            currentRow--;
            break;

        case Direction.down:
            currentRow++;
            break;

        case Direction.left:
            currentCol--;
            break;

        case Direction.right:
            currentCol++;
            break;
    }

    if (currentRow < 0 || currentRow > matrix.Length ||
        currentCol < 0 || currentCol > matrix[currentRow].Length)
    {
        IsOutOfBoundery = true;
        break;
    }

    switch (matrix[currentRow][currentCol]) 
    { 

        case 'W':
            cash += 100;
            break;

        case 'P':
            cash -= 200;
            break;  

        case 'J':
            cash += 100000;
            IsWin = true;
            break;       
    }

    matrix[currentRow][currentCol] = 'G';    
}

if (IsWin)
{
    Console.WriteLine("You win the Jackpot!");
    Console.WriteLine($"End of the game. Total amount: {cash}$");
}
else if (IsOutOfBoundery || cash <= 0) Console.WriteLine("Game over! You lost everything!");
else Console.WriteLine($"End of the game. Total amount: {cash}$");

if (cash > 0)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        Console.WriteLine(String.Join("", matrix[i]));
    }
}


static void InitialGamblerPosition(char[][] matrix, ref int currentRow, ref int currentCol)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            if (matrix[i][j] == 'G')
            {
                currentRow = i;
                currentCol = j;
                break;
            }
        }
    }
}

enum Direction
{
    up,
    down,
    left,
    right
}