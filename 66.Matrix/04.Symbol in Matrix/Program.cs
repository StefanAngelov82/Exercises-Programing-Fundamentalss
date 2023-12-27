using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            char[][] matrix = new char[N][];

            for (int i = 0; i < matrix.Length; i++)
            {                
                matrix[i] = Console.ReadLine().ToCharArray();               
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
