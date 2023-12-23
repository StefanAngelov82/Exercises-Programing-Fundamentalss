using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Population_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "report")
            {
                string[] inputARG = input.Split('|');

                string country = inputARG[1];
                string city = inputARG[0];
                long population = long.Parse(inputARG[2]);

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, long>(); 
                }

                if (!data[country].ContainsKey(city))
                {
                    data[country][city] = 0;
                }

                data[country][city] = population;
            }

            foreach (var kvp in data.OrderByDescending(x =>x.Value.Values.Sum()))
            {
                string country = kvp.Key;
                long population = kvp.Value.Values.Sum();

                Console.WriteLine($"{country} (total population: {population})");

                foreach (var kvp1 in kvp.Value.OrderByDescending(x =>x.Value))
                {
                    string city = kvp1.Key;
                    long cityPoputation = kvp1.Value;

                    Console.WriteLine($"=>{city}: {cityPoputation}");
                }
            }
        }
    }
}
