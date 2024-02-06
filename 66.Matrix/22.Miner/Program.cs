
int N = int.Parse(Console.ReadLine());

char[][] field = new char[N][];

string[] moves = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < N; i++)
{
    field[i] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();
}

int row = 0;
int col = 0;
int TotalCoalCount = 0;
int currentCoal = 0;
bool IsDone = false;

for (int i = 0; i < field.Length; i++)
{
    for (int j = 0; j < field[i].Length; j++)
    {
        if (field[i][j] == 's')
        {
            row = i;
            col = j;
        }
        else if (field[i][j] == 'c')
        {
            TotalCoalCount ++;
        }
    }
}

for (int i = 0; i < moves.Length; i++)
{
    string move = moves[i];

    switch (move)
    {
        case "left":
            if (MoveLeft(col))            
                col--;            
            break;

        case "right":
            if (MoveRight(field, row, col))            
                col++;           
            break;

        case "up":
            if (MoveUp(row))            
                row--;            
            break;

        case "down":
            if(MoveDown(field, row))            
                row++;            
            break;
    }

    IsDone = FieldHarvesting(field, row, col, TotalCoalCount, ref currentCoal);

    if (IsDone) break;   
}

if (!IsDone)
    Console.WriteLine($"{TotalCoalCount - currentCoal} coals left. ({row}, {col})");

static bool FieldHarvesting(char[][] field, int row, int col,int TotalCoalCount, ref int currentCoal)
{
    if (field[row][col] == '*')
        return false;

    else if (field[row][col] == 'e')
    {
        Console.WriteLine($"Game over! ({row}, {col})");
        return true;
    }
    else
    {
        field[row][col] = '*';
        currentCoal++;

        if (currentCoal == TotalCoalCount)
        {
            Console.WriteLine($"You collected all coals! ({row}, {col})");
            return true;
        }

        return false;
    }
}

static bool MoveLeft(int col)
{
    return (col - 1) >= 0;
}

static bool MoveUp(int row)
{
    return (row - 1) >= 0;
}

static bool MoveRight(char[][] field, int row, int col)
{
    return (col + 1) < field[row].Length; 
}

static bool MoveDown(char[][] field, int row )
{
    return (row + 1) < field.Length;
}