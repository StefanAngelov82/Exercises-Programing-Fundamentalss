using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[rowCol[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }            

            for (int i = 0; i < matrix[0].Length; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.Length; j++)
                {
                    sum += matrix[j][i];
                }

                Console.WriteLine(sum);               
            }
        }
    }
}
