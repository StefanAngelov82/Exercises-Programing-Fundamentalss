using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> mixed = new List<int>();

            int endCount = Math.Min(list1.Count, list2.Count);

            for (int i = 0; i < endCount; i++)
            {
                mixed.Add(list1[i]);
                mixed.Add(list2[list2.Count - 1 - i]);
            }

            int reper1, reper2;

            if (list1.Count > list2.Count)
            {
                reper1 = list1[list1.Count - 2];
                reper2 = list1[list1.Count - 1];
            }
            else
            {
                reper1 = list2[0];
                reper2 = list2[1];
            }

            int maxreper = Math.Max(reper1, reper2);
            int minreper = Math.Min(reper1, reper2);

            mixed.Sort();

            foreach (var number in mixed)
            {
                if (number > minreper && number < maxreper)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
