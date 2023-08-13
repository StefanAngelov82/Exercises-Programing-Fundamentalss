using System;
using System.Collections.Generic;
using System.Linq;

namespace Flip_List_Sides
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 1; i < (list.Count / 2); i++)
            {
                int temp = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = temp;
            }

            Console.WriteLine(string.Join(' ', list));
        }
    }
}
