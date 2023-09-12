using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _3._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> shopingbag = new Dictionary<string, decimal>();

             decimal budget = decimal.Parse(Console.ReadLine());

            string input = String.Empty;    

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input.Split(' ');

                string product = inputArg[0];
                decimal price = decimal.Parse(inputArg[1]);

                if (!shopingbag.ContainsKey(product))
                {
                    shopingbag[product] = price;
                }
                else if (shopingbag[product] > price)
                {
                    shopingbag[product] = price;
                }
            }

            decimal sumPrice = shopingbag.Values.Sum();            

            if (sumPrice > budget)
            {
                Console.WriteLine("Need more money… Just buy banichka");
                return;
            }

            shopingbag
               .OrderByDescending(x => x.Value)
               .ThenBy(x => x.Key.Length)
               .Select(x => x.Key + " cost " + x.Value)
               .ToList()
               .ForEach(Console.WriteLine);
                

            //foreach (var kvp in result)
            //{
            //    Console.WriteLine($"{kvp.Key} cost {kvp.Value:F2}");
            //}


        }
    }
}
