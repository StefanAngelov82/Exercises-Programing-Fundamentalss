
int[] rowCol = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[][] stairs = new char[rowCol[0]][];

for (int i = 0; i < stairs.Length; i++)
    stairs[i] = new char[rowCol[1]];

Queue<char> snake1 = new Queue<char>(Console.ReadLine());

for (int i = 0; i < stairs.Length; i++)
{
    if (i % 2 == 0)   
        for (int j = 0; j < stairs[i].Length; j++)      
            SnakeMove(stairs, snake1, i, j);      
   
    else    
        for (int j = stairs[i].Length - 1; j >= 0; j--)        
            SnakeMove(stairs, snake1, i, j);
}


for (int i = 0; i < stairs.Length; i++)
{
    for (int j = 0; j < stairs[i].Length; j++)   
        Console.Write($"{stairs[i][j]}");
    
    Console.WriteLine();
}
static void SnakeMove(char[][] stairs, Queue<char> snake1, int i, int j)
{
    stairs[i][j] = snake1.Peek();
    snake1.Enqueue(snake1.Dequeue());
}