using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int counter = list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                    counter--;
                    i--;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                list.Reverse();
                Console.WriteLine(string.Join(' ', list));
            }
        }
    }
}
