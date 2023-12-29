using System;
using System.Linq;
using System.Text;

namespace Matrix_of_Palindromes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] rowCol = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[][] matrix = new string[rowCol[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[rowCol[1]];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                   char firsSymbol = (char)(97 + i);
                   char lastSymbol = (char)(97 + i);
                   char middleSymbol = (char)(97 + i + j);                

                    matrix[i][j] = "" + firsSymbol + middleSymbol + lastSymbol;
                }                
            }

            foreach (var array in matrix)
            {
                Console.WriteLine(string.Join(" ",array));
            }
        }
    }
}
