using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> data = new Dictionary<string, int>() { { "shards", 0 },{"fragments", 0 },{ "motes", 0 } };

            string epicElement = String.Empty;

            DataInput(data, ref epicElement);
            Printing(data, epicElement);
        }

        private static void Printing(Dictionary<string, int> data, string epicElement)
        {
            Console.WriteLine($"{epicElement} obtained!");

            data.Take(3).OrderByDescending(x =>x.Value).ThenBy(x =>x.Key).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
            data.Skip(3).OrderBy(X => X.Key).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));           
        }

        private static void DataInput(Dictionary<string, int> data, ref string epicElement)
        {
            bool isReady = true;

            while (isReady)
            {
                string[] input = Console.ReadLine().ToLower().Split(' ');                

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string element = input[i + 1];

                    if (!data.ContainsKey(element))
                    {
                        data[element] = 0;
                    }

                    data[element] += quantity;

                    if (data[element] >= 250 && (element == "shards" || element == "fragments" || element == "motes"))
                    {
                        data[element] -= 250;

                        if (element == "shards") epicElement = "Shadowmourn";
                        else if (element == "fragments") epicElement = "Valanyr";
                        else epicElement = "Dragonwrath";

                        isReady = false;
                        break;
                    }
                }
            }
           
        }
    }
}
