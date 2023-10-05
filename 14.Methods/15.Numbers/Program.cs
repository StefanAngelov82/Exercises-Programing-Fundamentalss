using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse).OrderByDescending(x => x)
               .ToList();

            double average = numbers.Average();

            int count = 0;

            foreach (int number in numbers)
            {
                if (number == average)
                {
                    Console.WriteLine("No");
                    return;
                }

                if (number > average && count < 5)
                {
                    Console.Write($"{number} ");
                    count++;
                }
            }
    }
}
