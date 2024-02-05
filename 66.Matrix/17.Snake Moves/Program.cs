
int[] rowCol = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[][] stairs = new char[rowCol[0]][];

for (int i = 0; i < stairs.Length; i++)
{
    stairs[i] = new char[rowCol[1]];
}

string snake = Console.ReadLine();

int snakeIndex = 0;

for (int i = 0; i < stairs.Length; i++)
{
    for (int j = 0; j < stairs[i].Length; j++)
    {
        if (i % 2 == 0)
        {
            if (snakeIndex == snake.Length)           
                snakeIndex = 0;
            

            stairs[i][j] = snake[snakeIndex];
            snakeIndex++;
        }
        else
        {
            if (snakeIndex == snake.Length)            
                snakeIndex = 0;
            

            stairs[i][stairs[i].Length - 1 - j] = snake[snakeIndex];
            snakeIndex++;
        }
    }
}


for (int i = 0; i < stairs.Length; i++)
{
    for (int j = 0; j < stairs[i].Length; j++)
    {
        Console.Write($"{stairs[i][j]}");
    }

    Console.WriteLine();
}