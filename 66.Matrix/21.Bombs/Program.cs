
int N = int.Parse(Console.ReadLine());

int[][] matrix = new int[N][];

for (int i = 0; i < N; i++)
{
    matrix[i] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

int[] coordinates = Console.ReadLine()
    .Split(new string[] { " ", ","}, StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int bombNumber = coordinates.Length;

for (int i = 0; i < bombNumber; i += 2)
{
    int row = coordinates[i];
    int col = coordinates[i + 1];
    int damage = matrix[row][col];

    if (damage > 0)    
        Damage(damage, matrix, row, col);   
}

int sum = 0;
int count = 0;

for (int i = 0; i < matrix.Length; i++)
{
    for (int j = 0; j < matrix[i].Length; j++)
    {
        if (matrix[i][j] > 0)
        {
            sum += matrix[i][j];
            count++;
        }
    }
}

Console.WriteLine($"Alive cells: {count}");
Console.WriteLine($"Sum: {sum}");

for (int i = 0; i < matrix.Length; i++)
{
    Console.WriteLine($"{string.Join(" ", matrix[i])}");
}


static void Damage(int damage, int[][] matrix, int row, int col)
{
    if (col + 1 < matrix[row].Length && (matrix[row][col + 1] > 0))
        matrix[row][col + 1] -= damage;

    if((col -1 >= 0) && (matrix[row][col - 1]) > 0)
        matrix[row][col - 1] -= damage;

    if((row - 1 >= 0) && (matrix[row - 1][col] > 0))
        matrix[row - 1][col] -= damage;

    if ((row + 1 < matrix.Length) && (matrix[row + 1][col] > 0))
        matrix[row + 1][col] -= damage;

    if ((col + 1 < matrix[row].Length) && (row - 1 >= 0) && (matrix[row - 1][col + 1] > 0))
        matrix[row - 1][col + 1] -= damage;

    if ((col + 1 < matrix[row].Length) && (row + 1 < matrix.Length) && (matrix[row + 1][col + 1] > 0))
        matrix[row + 1][col + 1] -= damage;

    if ((col - 1 >= 0) && (row - 1 >= 0) && (matrix[row - 1][col - 1] > 0))
        matrix[row - 1][col - 1] -= damage;

    if ((col - 1 >= 0) && (row + 1 < matrix.Length) && (matrix[row + 1][col - 1] > 0))
        matrix[row + 1][col - 1] -= damage;

    matrix[row][col] = 0;
}       