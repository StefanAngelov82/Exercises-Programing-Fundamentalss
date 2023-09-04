using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string, Dictionary<string, List<string>>> cities = new Dictionary<string, Dictionary<string, List<string>>>();

            int count =int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                string continent = inputArg[0];
                string country = inputArg[1];
                string city = inputArg[2];

                if (!cities.ContainsKey(continent))
                {
                    cities[continent] =  new Dictionary<string, List<string>>();                   
                }
                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent][country] = new List<string>();
                }

                cities[continent][country].Add(city);   
            }

            foreach (var continent in cities.Keys)
            {
                Console.WriteLine($"{continent}:");

                foreach (var countries in cities[continent])
                {
                    Console.WriteLine($"   {countries.Key} -> {string.Join(", ",countries.Value)}");
                }
            }


        }
    }
}
