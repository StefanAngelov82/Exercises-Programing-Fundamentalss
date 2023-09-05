using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Shellbound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<int>> shellsDistribution = new Dictionary<string, HashSet<int>>();

            string command = String.Empty;

            while ((command = Console.ReadLine() ) != "Aggregate")
            {
                string[] commandArg = command.Split(' ');

                string town = commandArg[0];
                int shellsNumber = int.Parse(commandArg[1]);

                if (!shellsDistribution.ContainsKey(town))
                {
                    shellsDistribution[town] = new HashSet<int>();
                }

                shellsDistribution[town].Add(shellsNumber);                
            }

            foreach (var towns in shellsDistribution.Keys)
            {
                double giantShell = Math.Round(shellsDistribution[towns].Sum() - shellsDistribution[towns].Average()); ;

                Console.WriteLine($"{towns} -> {string.Join(", ", shellsDistribution[towns])} ({giantShell})");
            }
        }
    }
}
