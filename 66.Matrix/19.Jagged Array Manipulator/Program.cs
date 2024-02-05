
int N = int.Parse(Console.ReadLine());

double[][] matrix = new double[N][];  

for (int i = 0; i < N; i++)
    matrix[i] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse)
        .ToArray();

MatrixCal(matrix);

string input = String.Empty;

while ((input = Console.ReadLine()) != "End")
{
    int[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Skip(1)
        .Select(int.Parse)
        .ToArray();

    int row = inputArg[0];
    int col = inputArg[1];
    int value = inputArg[2];

    if (row < 0 || row > matrix.Length - 1 ||
        col < 0 || col > matrix[row].Length - 1)
    {
        continue;
    }

    if (input.StartsWith("Add"))    
        matrix[row][col] += value;
   
    else
        matrix[row][col] -= value;
}


for (int i = 0; i < matrix.Length; i++)
{
    for (int j = 0; j < matrix[i].Length; j++)
    {
        Console.Write($"{matrix[i][j]} ");
    }

    Console.WriteLine();
}


static void MatrixCal(double[][] matrix)
{
    for (int i = 0; i < matrix.Length - 1; i++)
    {
        if (matrix[i].Length == matrix[i + 1].Length)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] *= 2;
                matrix[i + 1][j] *= 2;
            }
        }
        else
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] /= 2;
            }

            for (int j = 0; j < matrix[i + 1].Length; j++)
            {
                matrix[i + 1][j] /= 2;
            }
        }
    }

}