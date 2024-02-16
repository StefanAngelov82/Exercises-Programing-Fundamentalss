using System;
using System.Collections.Generic;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            char[][] aria = new char[N][];


            for (int i = 0; i < aria.Length; i++)
            {
                aria[i] = Console.ReadLine()
                            .Trim()
                            .ToCharArray();
            }

            int currentRow = -1;
            int currentCol = -1;
            int flowers = 0;
            bool IsOutOfAria = false;
            InitialBeeCoordinates(aria, ref currentRow, ref currentCol);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                aria[currentRow][currentCol] = '.';                

                Direction(ref currentRow, ref currentCol, input);

                if (currentRow < 0 || currentRow >= aria.Length ||
                    currentCol < 0 || currentCol >= aria[currentRow].Length)
                {
                    IsOutOfAria = true;
                    break;
                }

                switch (aria[currentRow][currentCol])
                {
                    case 'f':
                        flowers++;
                        break;
                    case 'O':
                        aria[currentRow][currentCol] = '.';

                        Direction(ref currentRow, ref currentCol, input);

                        if (aria[currentRow][currentCol] == 'f')
                        {
                            flowers++;
                        }
                        break;

                }

                aria[currentRow][currentCol] = 'B';
            }

            if(IsOutOfAria) Console.WriteLine("The bee got lost!");
            if(flowers < 5) Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            else Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");

            for (int i = 0; i < aria.Length; i++)
            {
                Console.WriteLine(string.Join("", aria[i]));
            }

        }

        private static void Direction(ref int currentRow, ref int currentCol, string input)
        {
            switch (input)
            {
                case "up":
                    currentRow--;
                    break;

                case "down":
                    currentRow++;
                    break;

                case "left":
                    currentCol--;
                    break;

                case "right":
                    currentCol++;
                    break;
            }
        }

        private static void InitialBeeCoordinates(char[][] aria, ref int currentRow, ref int currentCol)
        {
            for (int i = 0; i < aria.Length; i++)
            {
                for (int j = 0; j < aria[i].Length; j++)
                {
                    if (aria[i][j] == 'B')
                    {
                        currentRow = i;
                        currentCol = j;
                        return;
                    }
                }
            }
        }
    }
}
