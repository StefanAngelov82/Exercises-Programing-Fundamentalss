using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> realnumbers = new SortedDictionary<double, int>();
            
            foreach (double number in numbers)
            {
                if (!realnumbers.ContainsKey(number))
                {
                    realnumbers[number] = 0;
                }

                realnumbers[number]++;
            }

            foreach (var item in realnumbers)
            {
                double number = item.Key;
                int count = item.Value;

                Console.WriteLine($"{number} -> {count}");
            }
        }
    }
}
