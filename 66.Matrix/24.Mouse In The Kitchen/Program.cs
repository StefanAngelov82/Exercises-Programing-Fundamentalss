
using System.Data;

int[] rowCol = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int initialRow = rowCol[0];
int initialCol = rowCol[1];
bool IsOutOfField = false;
bool IsTrapped = false;
bool IsCheesFinished = false;
int cheesCount = 0;

char[][] matrix = new char[initialRow][];

for (int i = 0; i < matrix.Length; i++)
{    
    matrix[i] = Console.ReadLine().Trim().ToCharArray();
}

InitialMousePosition(ref cheesCount, ref initialRow, ref initialCol, matrix);

string input = String.Empty;

while ((input =Console.ReadLine()) != "danger"  && !IsOutOfField && !IsTrapped && !IsCheesFinished)
{
    matrix[initialRow][initialCol] = '*';

    int tempRow = initialRow;
    int tempCow  = initialCol;

    Direction? direction = (Direction)Enum.Parse(typeof(Direction), input);

    switch (direction)
    {
        case Direction.up:
            Up(ref initialRow, ref initialCol, matrix, ref IsOutOfField);
            break;

        case Direction.down:
            Down(ref initialRow, ref initialCol, ref IsOutOfField, matrix);
            break;

        case Direction.left:
            Left(ref initialRow, ref initialCol, ref IsOutOfField, matrix);
            break;

        case Direction.right:
            Right(ref initialRow, ref initialCol, ref IsOutOfField, matrix);
            break;
    }

    switch (matrix[initialRow][initialCol])
    {
        case 'C':
            cheesCount--;

            if (cheesCount == 0)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                IsCheesFinished = true;
            }            
                
            break;

        case 'T':
                Console.WriteLine("Mouse is trapped!");
                IsTrapped = true;
            break;

        case '@':
            initialRow = tempRow;
            initialCol = tempCow;
            break;

    }

    matrix[initialRow][initialCol] = 'M';
}

if (IsOutOfField) Console.WriteLine("No more cheese for tonight!");
else if (!IsTrapped && !IsCheesFinished) Console.WriteLine("Mouse will come back later!");

for (int i = 0; i < matrix.Length; i++)
{
    Console.WriteLine(string.Join("", matrix[i]));
}

static void InitialMousePosition(ref int cheesCount, ref int initialRow, ref int initialCol, char[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            if (matrix[i][j] == 'M')
            {
                initialRow = i;
                initialCol = j;
            }
            else if (matrix[i][j] == 'C')
            {
                cheesCount++;
            }
        }
    }
}

static void Up(ref int initialRow, ref int initialCol, char[][] matrix, ref bool IsOutOfField)
{
    if (initialRow - 1 >= 0) initialRow--;
    else                     IsOutOfField = true;    
}

static void Down(ref int initialRow, ref int initialCol, ref bool IsOutOfField, char[][] matrix)
{
    if (initialRow + 1 < matrix.Length) initialRow++;
    else                                IsOutOfField = true;
}

static void Left(ref int initialRow, ref int initialCol, ref bool IsOutOfField, char[][] matrix)
{
    if (initialCol - 1 >= 0) initialCol--;
    else                     IsOutOfField = true;
}

static void Right(ref int initialRow, ref int initialCol, ref bool IsOutOfField, char[][] matrix)
{
    if (initialCol + 1 < matrix[initialRow].Length) initialCol++;
    else                                            IsOutOfField = true;
}

enum Direction
{
    up,
    down,
    left,
    right
}

