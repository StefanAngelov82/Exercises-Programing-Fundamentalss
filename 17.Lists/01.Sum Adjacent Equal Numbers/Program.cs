using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<decimal> numbers1 = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();

            for (int i = 0; i < numbers1.Count - 1; i++)
            {
                if (numbers1[i] == numbers1[i + 1])
                {
                    numbers1[i] = numbers1[i] + numbers1[i + 1];
                    numbers1.RemoveAt(i + 1);
                    i = - 1;
                }
            }

            foreach (var digit in numbers1)
            {
                Console.Write(digit + " ");
            }
        }
    }
}
