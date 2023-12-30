using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Rubik_s_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[rowCol[0]][];            

            int counter = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[rowCol[1]];                

                for (int j = 0; j < matrix[i].Length; j++)                
                    matrix[i][j] = counter++;                
            }

            int N = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < N; i++)
            {
                string input = Console.ReadLine();

                string[] inputArg = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArg[1];
                int RorC = int.Parse(inputArg[0]);
                int times = int.Parse(inputArg[2]);

                if (command == "down")
                {
                    Down(matrix, RorC, times);                    
                }
                else if (command == "up")
                {
                    Up(matrix, RorC, times);
                    
                }
                else if (command == "right")
                {
                    Right(matrix, RorC, times);                    
                }
                else if (command == "left")
                {
                    Left(matrix, RorC, times);                    
                }
            }            

            int position = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == position)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        Rearranging(matrix, position, row, col);
                    }

                    position++;
                }
            }           
        }

        private static void Rearranging(int[][] matrix, int position, int row, int col)
        {
            int newRow = row;
            int newCol = col;

            for (int row1 = newRow; row1 < matrix.Length; row1++)
            {
                for (int col1 = newCol; col1 < matrix[row1].Length; col1++)
                {
                    if (matrix[row1][col1] == position)
                    {
                        int temp = matrix[row][col];
                        matrix[row][col] = matrix[row1][col1];
                        matrix[row1][col1] = temp;

                        Console.WriteLine($"Swap ({row}, {col}) with ({row1}, {col1})");                       
                        return;
                    }                    
                }

                newCol = 0;
            }
        }

        private static void Left(int[][] matrix, int RorC, int times)
        {
            for (int k = 0; k < times % matrix[RorC].Length; k++)
            {
                int temp = matrix[RorC][0];

                for (int j = 0; j < matrix[RorC].Length - 1; j++)
                {
                    matrix[RorC][j] = matrix[RorC][j + 1];
                }

                matrix[RorC][matrix[RorC].Length - 1] = temp;
            }
        }

        private static void Right(int[][] matrix, int RorC, int times)
        {
            for (int k = 0; k < times % matrix[RorC].Length; k++)
            {
                int temp = matrix[RorC][matrix[RorC].Length - 1];

                for (int j = matrix[RorC].Length - 1; j >= 1; j--)
                {
                    matrix[RorC][j] = matrix[RorC][j - 1];
                }

                matrix[RorC][0] = temp;
            }
        }

        private static void Up(int[][] matrix, int RorC, int times)
        {
            for (int k = 0; k < times % matrix.Length; k++)
            {
                int temp = matrix[0][RorC];

                for (int j = 1; j < matrix.Length; j++)
                {
                    matrix[j - 1][RorC] = matrix[j][RorC];
                }

                matrix[matrix.Length - 1][RorC] = temp;
            }
        }

        private static void Down(int[][] matrix, int RorC, int times)
        {
            for (int k = 0; k < times % matrix.Length; k++)
            {
                int temp = matrix[matrix.Length - 1][RorC];

                for (int j = matrix.Length - 1; j >= 1; j--)
                {
                    matrix[j][RorC] = matrix[j - 1][RorC];
                }

                matrix[0][RorC] = temp;
            }
        }

    }
}
