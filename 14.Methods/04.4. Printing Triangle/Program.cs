using System;

namespace Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowNumber = int.Parse(Console.ReadLine());
            PrintTriangel(7, '0');
            PrintTriangel(7, '&');
            PrintTriangel(7, '$');

        }

        static void PrintTriangel(int rowNumber, char symbol)
        {
            UpperTriangel(rowNumber, symbol);
            LowerTriangel(rowNumber - 1, symbol);
        }

        static void UpperTriangel(int rowNumber, char symbol)
        {
            for (int i = 1; i <= rowNumber; i++)
            {
                PrintRow(i, symbol);
            }
        }

        static void PrintRow(int i, char symbol)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }

        static void LowerTriangel(int rowNumber, char symbol)
        {
            for (int i = rowNumber; i >= 1; i--)
            {
                PrintRow(i, symbol);
            }
        }
    }
}
