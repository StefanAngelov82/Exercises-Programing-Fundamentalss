
using System.Security.Cryptography.X509Certificates;

int N = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray()[0];

int[][] matrix = new int[N][];

for (int i = 0; i < matrix.Length; i++)
{
    matrix[i] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

string input = String.Empty;

while ((input =Console.ReadLine()) != "END")
{
    string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputArg[0] != "swap" || inputArg.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    int row1 = int.Parse(inputArg[1]);
    int col1 = int.Parse(inputArg[2]);
    int row2 = int.Parse(inputArg[3]);
    int col2 = int.Parse(inputArg[4]);

    if (row1 < 0 || row1 > matrix.Length - 1 ||
        row2 < 0 || row2 > matrix.Length -1 ||
        col1 < 0 || col1 > matrix[0].Length - 1||
        col2 < 0 || col2 > matrix[0].Length - 1)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    
    (matrix[row1][col1], matrix[row2][col2]) = (matrix[row2][col2], matrix[row1][col1]);

    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            Console.Write($"{matrix[i][j]} ");
        }

        Console.WriteLine();
    }
}
