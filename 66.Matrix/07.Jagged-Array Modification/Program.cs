using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int[][] matrix = new int[row][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split(" ");
                int row1, col, value;

                switch (inputArg[0])
                {
                    case "Add":
                         row1 = int.Parse(inputArg[1]);
                         col = int.Parse(inputArg[2]);
                         value = int.Parse(inputArg[3]);

                        if (row1 >= matrix.Length || row1 < 0 || col < 0 || col >= matrix[row1].Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            matrix[row1][col] += value;
                        }                      

                        break;

                    case "Subtract":
                         row1 = int.Parse(inputArg[1]);
                         col = int.Parse(inputArg[2]);
                         value = int.Parse(inputArg[3]);

                        if (row1 >= matrix.Length || row1 < 0 || col < 0 ||col >= matrix[row1].Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                            matrix[row1][col] -= value;
                        } 
                        
                        break;
                }
            }

            foreach (var array in matrix)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            
        }
    }
}
