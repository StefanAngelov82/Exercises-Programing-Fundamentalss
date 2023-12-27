using System;
using System.Linq;

namespace Sum_Matrix_Elements
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

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);

            Console.WriteLine(matrix.Sum(x =>x.Sum()));
        }  
    }
}
