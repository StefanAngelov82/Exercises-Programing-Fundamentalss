using System;
using System.Linq;

namespace Square_with_Maximum_Sum
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
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
            }

            int maxSum = int.MinValue;
            int[] numbers = new int[4];

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    int currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i + 1][j] + matrix[i + 1][j + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        numbers[0] = matrix[i][j];
                        numbers[1] = matrix[i][j + 1];
                        numbers[2] = matrix[i + 1][j];
                        numbers[3] = matrix[i + 1][j + 1];
                    }
                }
            }

            Console.WriteLine($"{numbers[0]} {numbers[1]}");
            Console.WriteLine($"{numbers[2]} {numbers[3]}");

            Console.WriteLine(maxSum);
        }
    }
}
