using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();

            string input = String.Empty;
            
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArg = input.Split(", ");

                string shop = inputArg[0];
                string product = inputArg[1];
                double price = double.Parse(inputArg[2]);

                if (!data.ContainsKey(shop))
                {
                    data[shop] = new Dictionary<string, double>();
                }

                if (!data[shop].ContainsKey(product))
                {
                    data[shop][product] = 0;
                }

                data[shop][product] = price;
            }

            foreach (var kvp in data.OrderBy(x =>x.Key))
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var kvp1 in kvp.Value)
                {
                    Console.WriteLine($"Product: {kvp1.Key}, Price: {kvp1.Value}");
                }
            }
        }
    }
}
