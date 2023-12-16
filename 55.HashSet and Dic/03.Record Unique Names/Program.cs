using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
