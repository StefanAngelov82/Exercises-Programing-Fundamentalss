using System;
using System.Collections.Generic;

namespace Letter_Repetition
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                string text = Console.ReadLine();

                char[] chars = text.ToCharArray();

                Dictionary<char, int> result = new Dictionary<char, int>();

                foreach (char symbol in chars)
                {
                    if (!result.ContainsKey(symbol))
                    {
                        result[symbol] = 0;
                    }

                    result[symbol]++;
                }

                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }

            }
       
    }
}
