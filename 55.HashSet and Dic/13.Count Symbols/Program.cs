using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> data = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char c in text)
            {
                if (!data.ContainsKey(c))
                {
                    data[c] = 0;
                }

                data[c]++;
            }

            foreach (var cj in data)
            {
                Console.WriteLine($"{cj.Key}: {cj.Value} time/s");
            }
        }
    }
}
