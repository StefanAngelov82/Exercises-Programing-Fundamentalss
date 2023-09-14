using System;
using System.Collections.Generic;
using System.Linq;

namespace Flatten_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Dictionary<string, Dictionary<string,string>> data = new Dictionary<string, Dictionary<string,string>>();
            Dictionary<string, List<string>> flattenData = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input.Split();

                if (inputArg[0] != "flatten")
                {
                    string key = inputArg[0];
                    string innerKey = inputArg[1];
                    string innerValue = inputArg[2];

                    if (!data.ContainsKey(key))
                    {
                        data[key] = new Dictionary<string, string>();
                    }
                    
                    data[key][innerKey] = innerValue;
                }
                else
                {
                    string flatenKey = inputArg[1];                    

                    foreach (var kvp in data[flatenKey])
                    {
                        if (!flattenData.ContainsKey(flatenKey))
                        {
                            flattenData[flatenKey] = new List<string>();
                        }

                        flattenData[flatenKey].Add(kvp.Key + kvp.Value);                        
                    }

                    data.Remove(flatenKey);
                }
            }           

            foreach (var key in data.Keys.OrderByDescending(x => x.Length))
            {
                int counter = 0;

                Console.WriteLine(key);

                foreach (var innerKey in data[key].Keys.OrderBy(x => x.Length))
                {
                    counter++;

                    Console.WriteLine($"{counter}. {innerKey} - {data[key][innerKey]}");
                }

                if (flattenData.ContainsKey(key))
                {
                    foreach (var flattenValue in flattenData[key])
                    {
                        counter++;

                        Console.WriteLine($"{counter}. {flattenValue}");
                    }
                }  
            }
        }
    }
}
