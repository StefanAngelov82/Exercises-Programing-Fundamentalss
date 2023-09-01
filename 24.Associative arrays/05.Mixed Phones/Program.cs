using System;
using System.Collections.Generic;

namespace Mixed_Phones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, long> phoneBook = new SortedDictionary<string, long>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Over")
            {
                string[] tokens = input.Split(" : ");

                long result;

                if (!long.TryParse(tokens[0], out result))
                {
                    phoneBook[tokens[0]] = long.Parse(tokens[1]);
                }
                else
                {
                    phoneBook[tokens[1]] = result;
                }
            }

            foreach (var item in phoneBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
