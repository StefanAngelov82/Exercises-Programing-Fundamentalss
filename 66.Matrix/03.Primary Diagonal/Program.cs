using System;
using System.Linq;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row =int.Parse(Console.ReadLine());

            int[][] matrix = new int[row][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            int sum = 0;

            for (int i = 0; i < row; i++)
            {          
                sum += matrix[i][i];                
            }

            Console.WriteLine(sum);
        }
    }
}
