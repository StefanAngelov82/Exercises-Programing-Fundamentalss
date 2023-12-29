using System;
using System.Linq;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            long[][] matrix = new long[row][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            long positiveSum = 0;
            long negativeSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                positiveSum += matrix[i][i];                
                negativeSum += matrix[i][matrix[i].Length - 1 - i];
            }

            Console.WriteLine(Math.Abs(positiveSum - negativeSum));
        }
    }
}
