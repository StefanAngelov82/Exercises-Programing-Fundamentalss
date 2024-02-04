
int n = int.Parse(Console.ReadLine());

int[][] matrix = new int[n][];  

for (int i = 0; i < n; i++)
{
    matrix[i] = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
}

int sum1 = 0;
int sum2 = 0;

for (int i = 0;i < matrix.Length; i++)
{
    sum1 += matrix[i][i];
    sum2 += matrix[i][matrix[i].Length - 1 - i];
}

Console.WriteLine(Math.Abs(sum1 - sum2));