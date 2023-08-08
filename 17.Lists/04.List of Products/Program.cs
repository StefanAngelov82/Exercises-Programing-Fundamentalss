using System;
using System.Collections.Generic;

namespace List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();
            int p = n;

            while (p > 0)
            {
                products.Add(Console.ReadLine());
                p--;
            }

            products.Sort();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
            
        }
    }
}
