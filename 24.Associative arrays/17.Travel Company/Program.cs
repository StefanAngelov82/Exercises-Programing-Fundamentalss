using System;
using System.Collections.Generic;
using System.Linq;

namespace Travel_Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transportData = new Dictionary<string, Dictionary<string, int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "ready")
            {
                string[] inputArg = input.Split(':');

                string city = inputArg[0];

                string[] vehicles = inputArg[1]
                    .Split( new string[] {",","-"}, StringSplitOptions.RemoveEmptyEntries)
                    .Where((x,i) => i % 2 == 0)
                    .ToArray();                

                int[] capacity = inputArg[1]
                    .Split( new string[] {",","-"}, StringSplitOptions.RemoveEmptyEntries)
                    .Where((x, i) => i % 2 != 0)
                    .Select(int.Parse)                    
                    .ToArray();

                if (!transportData.ContainsKey(city))
                {
                    transportData[city] = new Dictionary<string, int>();
                }                

                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (!transportData[city].ContainsKey(vehicles[i]))
                    {
                        transportData[city].Add(vehicles[i], capacity[i]);
                    }

                    transportData[city][vehicles[i]] = capacity[i];
                }
            }

            Dictionary<string,int> LoadDestination = new Dictionary<string,int>();

            while ((input = Console.ReadLine()) != "travel time!")
            {
                string[] destinationLoad = input.Split().ToArray(); 

                string destination = destinationLoad[0];
                int pasengerCount = int.Parse(destinationLoad[1]);              
               
                LoadDestination[destination] = pasengerCount;
            }

            int pasengersForTrip = 0;
            int capacityForTrip = 0;

            foreach (var city in LoadDestination.Keys)
            {
                pasengersForTrip = LoadDestination[city];
                capacityForTrip = 0;

                foreach (var vehicles in transportData[city])
                {
                    capacityForTrip += vehicles.Value;
                }

                if (pasengersForTrip <= capacityForTrip)
                {
                    Console.WriteLine($"{city} -> all {pasengersForTrip} accommodated");
                }
                else
                {
                    Console.WriteLine($"{city} -> all except {pasengersForTrip - capacityForTrip} accommodated");
                }
            }
            

        }
    }
}
