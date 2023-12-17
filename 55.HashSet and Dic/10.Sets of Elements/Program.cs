using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondtSet = new HashSet<int>();
           

            for (int i = 0; i < numbers[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numbers[1]; i++)
            {
                secondtSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondtSet);
            
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
