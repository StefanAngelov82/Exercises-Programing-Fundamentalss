using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            SortedSet<string> data = new SortedSet<string>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (string s in input)
                {
                    data.Add(s);
                }
            }

            Console.WriteLine(string.Join(" ", data));
        }
    }
}
