using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs_Aggregator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> data = new SortedDictionary<string, SortedDictionary<string, int>>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split(" ");

                string name = inputArg[1];
                string IP = inputArg[0];
                int time = int.Parse(inputArg[2]);

                if (!data.ContainsKey(name))
                {
                    data[name] = new SortedDictionary<string, int>();
                }

                if (!data[name].ContainsKey(IP))
                {
                    data[name][IP] = 0;
                }

                data[name][IP] += time;
            }

            foreach (var person in data)
            {
                Console.Write($"{person.Key}: ");

                int totalTime = person.Value.Values.Sum();

                Console.WriteLine($"{totalTime} [{string.Join(", ", person.Value.Keys)}]");
            }
        }
    }
}
