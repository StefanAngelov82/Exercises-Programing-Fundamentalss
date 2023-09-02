using System;
using System.Collections.Generic;

namespace Exam_Shopping1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> warehouse = new SortedDictionary<string, int>();

            ShopOpperations(warehouse);

            PrintWarehouseInventory(warehouse);
        }

        static void ShopOpperations(SortedDictionary<string, int> warehouse)
        {
            string input = String.Empty;
            bool isShoppingtime = false;

            while ((input = Console.ReadLine()) != "exam time")
            {
                if (input == "shopping time")
                {
                    isShoppingtime = true;
                }

                switch (InputArg(input, 0))
                {
                    case "stock":
                        AddProductWarehouse(warehouse, input);
                        break;

                    case "buy":
                        if (isShoppingtime)
                        {
                            RemoveProductWarehouse(warehouse, input);
                        }
                        break;
                }
            }
        }

        static void RemoveProductWarehouse(SortedDictionary<string, int> warehouse, string input)
        {
            string product = InputArg(input, 1);
            int quantyty = int.Parse(InputArg(input, 2));

            if (!warehouse.ContainsKey(product))
            {
                Console.WriteLine($"{product} doesn't exist");               
            }
            else if (warehouse[product] <= 0)
            {
                Console.WriteLine($"{product} out of stock");
            }
            else
            {
                warehouse[product] -= quantyty;
            }
        }

        static void AddProductWarehouse(SortedDictionary<string, int> warehouse,string input)
        {
            string product = InputArg(input, 1);
            int quantyty = int.Parse(InputArg(input, 2));

            if (!warehouse.ContainsKey(product))
            {
                warehouse[product] = 0;
            }

            warehouse[product] += quantyty;
        }

        static void PrintWarehouseInventory(SortedDictionary<string, int> warehouse)
        {
            foreach (var item in warehouse)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }                
            }
        }

        static string InputArg(string input, int arg)
        {
            string[] arrOfArg = input.Split();

            if      (arg == 0)  return arrOfArg[0];
            else if (arg == 1)  return arrOfArg[1];
            else                return arrOfArg[2];
        }


    }
}
