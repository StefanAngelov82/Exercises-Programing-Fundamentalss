using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ", list.OrderByDescending(x => x).Take(3)));
            
        }
    }
}
