using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CottageScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> materials = new Dictionary<string, List<int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "chop chop")
            {
                string[] inputArg = input.Split(" -> ");

                string tree = inputArg[0];
                int treeLenght = int.Parse(inputArg[1]);

                if (!materials.ContainsKey(tree))
                {
                    materials.Add(tree, new List<int>());
                }

                materials[tree].Add(treeLenght);
            }

            string typeTree = Console.ReadLine();
            int requestedLenght = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> usedLogs = materials.Where(x => x.Key == typeTree).ToDictionary(x => x.Key, y => y.Value);

            usedLogs[typeTree] = usedLogs[typeTree].Where(x => x > requestedLenght).ToList();
            materials[typeTree] = materials[typeTree].Where(x => x < requestedLenght).ToList();

            int AllMeters = 0;
            int MeterWaste = 0;
            int MetersInUse = 0;

            int numberOfLogs = 0;

            foreach (var tree in materials.Keys)
            {
                numberOfLogs += materials[tree].Count;

                foreach (var lenght in materials[tree])
                {
                    MeterWaste += lenght;                    
                }
            }

            numberOfLogs += usedLogs[typeTree].Count;
            
            foreach (var lenght in usedLogs[typeTree])
            {
                MetersInUse += lenght;
            }

            AllMeters = MetersInUse + MeterWaste;

            decimal PricePerMeter = Math.Round ((decimal)AllMeters / numberOfLogs, 2);
            decimal PriceUsedLogs = MetersInUse * PricePerMeter;
            decimal PriceForWaste = (MeterWaste * PricePerMeter) * 0.25m;
            decimal TotalPrice  = PriceUsedLogs + PriceForWaste;

            Console.WriteLine($"Price per meter: ${PricePerMeter:F2}");
            Console.WriteLine($"Used logs price: ${PriceUsedLogs:F2}");
            Console.WriteLine($"Unused logs price: ${PriceForWaste:F2}");
            Console.WriteLine($"CottageScraper subtotal: ${TotalPrice:F2}");

















        }
    }
}
