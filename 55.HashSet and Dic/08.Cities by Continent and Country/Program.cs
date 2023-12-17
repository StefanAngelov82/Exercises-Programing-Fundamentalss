using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();

            int N = int.Parse(Console.ReadLine());
                
            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split(' ');

                string continent = inputArg[0];
                string country = inputArg[1];
                string city = inputArg[2];

                if (!data.ContainsKey(continent))
                {
                    data[continent] = new Dictionary<string, List<string>>();
                }

                if (!data[continent].ContainsKey(country))
                {
                    data[continent][country] = new List<string>();
                }

                data[continent][country].Add(city);
            }

            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"{kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                }
            }
        }
    }
}
