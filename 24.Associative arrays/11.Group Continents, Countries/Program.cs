using System;
using System.Collections.Generic;

namespace Group_Continents__Countries_and_Cities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> statistic = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            int caunt = int.Parse(Console.ReadLine());

            for (int i = 0; i < caunt; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                string continent = inputArg[0];
                string country = inputArg[1];
                string city = inputArg[2];

                if (!statistic.ContainsKey(continent))
                {
                    statistic[continent] = new SortedDictionary<string, SortedSet<string>>();
                }

                if (!statistic[continent].ContainsKey(country))
                {
                    statistic[continent][country] = new SortedSet<string>();
                }

                statistic[continent][country].Add(city);
            }

            foreach (var continent in statistic.Keys)
            {
                Console.WriteLine($"{continent}:");

                foreach (var countrycity in statistic[continent])
                {
                    Console.WriteLine($"  {countrycity.Key} -> {string.Join(", ", countrycity.Value)}");
                }
            }
        }
    }
}
