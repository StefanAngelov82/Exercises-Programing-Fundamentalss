using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum__Min__Max__Average
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count =int.Parse(Console.ReadLine());

            int[] arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] =int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum = {arr.Sum()}");
            Console.WriteLine($"Min = {arr.Min()}");
            Console.WriteLine($"Max = {arr.Max()}");
            Console.WriteLine($"Average = {arr.Average()}");
        }
    }
}
