using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string name = Console.ReadLine();

                set.Add(name);
            }

            foreach (string name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
