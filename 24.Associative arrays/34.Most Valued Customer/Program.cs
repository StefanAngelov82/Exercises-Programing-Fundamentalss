using System.Diagnostics.Metrics;
using System.Net.WebSockets;

namespace Most_Valued_Customer
{
    internal class Program
    {
        static Dictionary<string, double> productsData = new Dictionary<string, double>();
        static Dictionary<string, Dictionary<string, int>> peopelsPurchases = new Dictionary<string, Dictionary<string, int>>();
        static void Main(string[] args)
        {
            

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Shop is open")
            {
                string[] inputArg = input.Split(' ').ToArray();

                string product = inputArg[0];
                double price = double.Parse(inputArg[1]);

                productsData[product] = price;
            }

            while ((input = Console.ReadLine()) != "Print")
            {
                if (input == "Discount")
                {
                    int couter = 0;

                    foreach (var item in productsData.OrderByDescending(x => x.Value))
                    {
                        couter++;

                        if (couter > 3) break;

                        productsData[item.Key] *= 0.9;
                    }
                }
                else
                {
                    string[] inputArg = input.Split(new char[] { ' ', ':', ','}, StringSplitOptions.RemoveEmptyEntries);

                    string buyername = inputArg[0];

                    for (int i = 1; i < inputArg.Length; i++)
                    {
                        if (!productsData.ContainsKey(inputArg[i])) continue;
                        

                        if (!peopelsPurchases.ContainsKey(buyername))
                        {
                            peopelsPurchases[buyername] = new Dictionary<string, int>();
                        }

                        if (!peopelsPurchases[buyername].ContainsKey(inputArg[i]))
                        {
                            peopelsPurchases[buyername][inputArg[i]] = 0;
                        }

                        peopelsPurchases[buyername][inputArg[i]]++;
                    }
                }
            }
             var purchasPower = new Dictionary<string, Dictionary<string, double>>();

            foreach (var name in peopelsPurchases.Keys)
            {
                if (!purchasPower.ContainsKey(name))
                {
                    purchasPower[name] = new Dictionary<string, double>();
                }
                foreach (var kvp in peopelsPurchases[name])

                purchasPower[name][kvp.Key] = kvp.Value * productsData[kvp.Key]; 
            }

            purchasPower = purchasPower.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, y => y.Value);
            productsData = productsData.OrderByDescending(x =>x.Value).ToDictionary(x => x.Key, y => y.Value);

            foreach (var name in purchasPower.Keys)
            {
                Console.WriteLine($"Biggest spender:{name}");
                Console.WriteLine("^Products bought:");

                foreach (var kvp in productsData)
                {
                    if (purchasPower[name].ContainsKey(kvp.Key))
                    {
                        Console.WriteLine($"^^^{kvp.Key} : {kvp.Value:F2}");
                    }
                }
                double total = purchasPower[name].Values.Sum();
                Console.WriteLine($"Total: {total:F2}");

                break;
            }

        }
    }
}