using System;
using System.Collections.Generic;
using System.Linq;

namespace Camel_s_Back
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int camelNumber = int.Parse(Console.ReadLine());

            int decrementor = (houses.Count - camelNumber) / 2;
            
            for (int i = 1; i <= decrementor ; i++)
            {
                houses.RemoveAt(0);               
                houses.RemoveAt(houses.Count - 1);
            }

            if (decrementor == 0)
            {
                Console.Write("already stable: ");
                Console.WriteLine(string.Join(" ", houses));
            }
            else
            {
                Console.WriteLine($"{decrementor} rounds");
                Console.WriteLine(string.Join(" ", houses));
            }

            
        }
    }
}
