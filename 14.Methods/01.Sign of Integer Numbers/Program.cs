using System;
using System.Reflection;

namespace Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            ChekNumcer(number);
        }
        static void ChekNumcer(int number)
        {
            if (number == 0)     Console.WriteLine($"The number {number} is zero.");
            else if (number < 0) Console.WriteLine($"The number {number} is negative.");
            else                 Console.WriteLine($"The number {number} is positive.");
        }
    }
}
