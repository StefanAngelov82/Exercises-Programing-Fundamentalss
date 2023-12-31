using System;
using System.Linq;

namespace Lego_Blocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[][] matrixA = new  int[N][];
            int[][] matrixB = new int[N][];

            for (int i = 0; i < matrixA.Length; i++)
            {
                matrixA[i] = Console.ReadLine()
                    .Trim()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray(); 
            }

            for (int i = 0; i < matrixB.Length; i++)
            {
                matrixB[i] = Console.ReadLine()
                    .Trim()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int[][] united = new int[N][];

            for (int i = 0; i < united.Length; i++)
            {
                Array.Reverse(matrixB[i]);

                united[i] = matrixA[i].Concat(matrixB[i]).ToArray();                
            }

            bool isLengthCorrect = true;
            int counter = 0;

            for (int i = 0; i < united.Length; i++)
            {
                if (united[0].Length != united[i].Length)
                {
                    isLengthCorrect = false;
                }

                counter += united[i].Length;
            }

            if (isLengthCorrect)
            {
                foreach (var array in united)
                {
                    Console.WriteLine($"[{string.Join(", ", array)}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {counter}");                
            }
        }
    }
}
