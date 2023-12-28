﻿using System;
using System.Linq;

namespace Square_with_Maximum_Sum_2
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

            Console.WriteLine($"Enter rows:");

            int row = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter cols");

            int col = int.Parse(Console.ReadLine());

            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i <= matrix.Length - row; i++)
            {
                for (int j = 0; j <= matrix[i].Length - col; j++)
                {
                    int sum = 0;

                    for (int k = i; k < i + row; k++)
                    {
                        for (int i1 = j; i1 < j + col; i1++)
                        {
                            sum += matrix[k][i1];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            for (int i = startRow; i < startRow + row; i++)
            {
                for (int j = startCol; j < startCol + col; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

        }
    }
}
