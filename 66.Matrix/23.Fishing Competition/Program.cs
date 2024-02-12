
using System;
using System.ComponentModel.Design;

char[][] field = CreateMatrix();

string command = String.Empty;
int currentRow = 0;
int currentCol = 0;
bool IsSink = false;
int totalCach = 0;

StartIndexDefinition(field, ref currentRow, ref currentCol);

while ((command = Console.ReadLine()) != "collect the nets" && !IsSink)
{
    field[currentRow][currentCol] = '-';

    Direction direction = (Direction)Enum.Parse(typeof(Direction), command);

    switch (direction)
    {
        case Direction.up:
            Up(field, ref currentRow, ref currentCol);
            break;
        case Direction.down:
            Down(field, ref currentRow, ref currentCol);
            break;
        case Direction.left:
            Left(field, ref currentRow, ref currentCol);
            break;
        case Direction.right:
            Right(field, ref currentRow, ref currentCol);
            break;
            default: break;
    }
    //switch (command)
    //{
    //    case "up":
    //        Up(field, ref currentRow, ref currentCol);
    //        break;

    //    case "down":
    //        Down(field, ref currentRow, ref currentCol);
    //        break;

    //    case "left":
    //        Left(field, ref currentRow, ref currentCol);
    //        break;

    //    case "right":
    //        Right(field, ref currentRow, ref currentCol);
    //        break;
    //}


    switch (field[currentRow][currentCol])
    {
        case 'W':
            IsSink = true;
            break;

        case '-':
            break;

        default:

            int currentCatch = (int)field[currentRow][currentCol] - 48;
            totalCach += currentCatch;

            field[currentRow][currentCol] = '-';
            break;

    }
}

field[currentRow][currentCol] = 'S';

if (IsSink)
{
    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
    return;
}

else if (totalCach >= 20)
    Console.WriteLine("Success! You managed to reach the quota!");

else
    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - totalCach} tons of fish more.");


if (totalCach > 0)
    Console.WriteLine($"Amount of fish caught: {totalCach} tons.");

Printing(field);










void Right(char[][] field, ref int currentRow, ref int currentCol)
{
    if ((currentCol + 1) < field[currentRow].Length)
        currentCol++;

    else
        currentCol = 0;
}
void Left(char[][] field, ref int currentRow, ref int currentCol)
{
    if ((currentCol - 1) >= 0)
        currentCol--;

    else
        currentCol = field[currentRow].Length - 1;
}

void Down(char[][] field, ref int currentRow, ref int currentCol)
{
    if ((currentRow + 1) < field.Length)
        currentRow++;

    else
        currentRow = 0;
}

void Up(char[][] field, ref int currentRow, ref int currentCol)
{
    if ((currentRow - 1) >= 0)
        currentRow--;

    else
        currentRow = field.Length - 1;
}

static void StartIndexDefinition(char[][] field, ref int currentRow, ref int currentCol)
{
    for (int i = 0; i < field.Length; i++)
    {
        for (int j = 0; j < field[i].Length; j++)
        {
            if (field[i][j] == 'S')
            {
                currentRow = i;
                currentCol = j;
                return;
            }
        }
    }
}

static void Printing<T>(T[][] field)
{
    for (int i = 0; i < field.Length; i++)
        Console.WriteLine($"{string.Join("", field[i])}");
}

static char[][] CreateMatrix()
{
    int fieldSize = int.Parse(Console.ReadLine());

    char[][] field = new char[fieldSize][];

    for (int i = 0; i < field.Length; i++)
    {
        string input = Console.ReadLine().Trim();

        field[i] = new char[input.Length];

        for (int j = 0; j < input.Length; j++)
        {
            field[i][j] = input[j];
        }
    }

    return field;
}


enum Direction
{
    up,
    down,
    left,
    right
}