using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Decryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] filters = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
           List<int> word = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x > 59 && x < 91)
                .ToList();

            int[] result = word.Skip(filters[0]).Take(filters[1]).ToArray();

            string print = String.Empty;

            foreach (var letter in result)
            {
                print +=(char)letter;
            }
            Console.WriteLine(print);








        }
    }
}
