using System;
using System.Data;

namespace Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            switch (comand)
            {
                case "add":      Add(x, y);      break;
                case "multiply": Multiply(x, y); break;
                case "subtract": Subtract(x, y); break;
                case "divide":   Divide(x, y);   break;
            }
        }

        static void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }

        static void Multiply(int x, int y)
        {
            Console.WriteLine(x * y);
        }

        static void Subtract(int x, int y)
        {
            Console.WriteLine(x - y);
        }

        static void Divide(int x, int y)
        {
           if (y != 0)  Console.WriteLine(x / y);
           else         Console.WriteLine(y / x);
        }
    }
}
