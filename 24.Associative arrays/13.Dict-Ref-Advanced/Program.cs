using System;
using System.Collections.Generic;
using System.Linq;

namespace Dict_Ref_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> peoples = new Dictionary<string, List<int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input.Split(" -> ").ToArray();

                string name = inputArg[0];                

                string[] values = inputArg[1].Split(", ").ToArray();

                int done;

                if (int.TryParse(values[0], out done))
                {
                    AddPeopleAndValues(peoples, name, values);
                }
                else
                {
                    ReplacingValues(peoples, name, values);
                }
            }

            foreach (var kvp in peoples)
            {
                Console.WriteLine($"{kvp.Key} === {string.Join(", ", kvp.Value)}");         
            }
            
        }

        private static void ReplacingValues(Dictionary<string, List<int>> peoples, string name, string[] values)
        {
            if (peoples.ContainsKey(values[0]))
            {
                peoples[name] = new List<int>();

                List<int> newSet = new List<int>();

                foreach (var item in peoples[values[0]])
                {
                    newSet.Add(item);
                }
                
                peoples[name] = newSet;
            }
        }

        private static void AddPeopleAndValues(Dictionary<string, List<int>> peoples, string name, string[] values)
        {
            if (!peoples.ContainsKey(name))
            {
                peoples[name] = new List<int>();
            }

            foreach (var digit in values)
            {
                peoples[name].Add(int.Parse(digit));
            }
        }
    }
}
