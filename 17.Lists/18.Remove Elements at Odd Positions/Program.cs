using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Elements_at_Odd_Positions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> wards = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> newWards = new List<string>();

            for (int i = 0; i < wards.Count; i++)
            {
                if ((i % 2) != 0)
                {
                    newWards.Add(wards[i]);
                }
            }

            Console.WriteLine(string.Join("", newWards));
        }
    }
}
