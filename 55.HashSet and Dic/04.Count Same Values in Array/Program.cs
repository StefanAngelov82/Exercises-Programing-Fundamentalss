using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> data = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (double number in numbers)
            {
                if (!data.ContainsKey(number))
                {
                    data[number] = 0;
                }

                data[number]++;
            }
            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }

        }
    }
}
