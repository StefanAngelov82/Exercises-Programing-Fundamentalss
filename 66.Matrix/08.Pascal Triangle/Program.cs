using System;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int row = int.Parse(Console.ReadLine());

            long[][] matrix = new long[row][];                             

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new long[i + 1];
                matrix[i][0] = 1;

                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }

                matrix[i][i] =  1;
            }

            foreach (var array in matrix)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
