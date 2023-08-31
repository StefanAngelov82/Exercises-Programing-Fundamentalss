using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> result = new Dictionary<string, int>();

           foreach (string word in words)
           {
                if (!result.ContainsKey(word))
                {
                    result[word] = 0;
                }

                result[word]++;
           }

           List<string> oddWards = new List<string>();

           foreach (var word in result)
           {
                if (word.Value % 2 != 0)
                {
                    oddWards.Add(word.Key);
                }               
           }

            Console.WriteLine(string.Join(", ", oddWards));
        }
    }
}
