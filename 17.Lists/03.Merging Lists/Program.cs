using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> list2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> list3 = new List<int>();

            int list1Lenght = 0;
            int list2Lenght = 0;
            int List3Lenght = list1.Count + list2.Count;

            for (int i = 1; i <= List3Lenght; i++)
            {
                while (list1Lenght < list1.Count && list2Lenght < list2.Count)
                {
                    if (i % 2 != 0)
                    {
                        list3.Add(list1[list1Lenght]);
                        list1Lenght++;
                        i++;
                    }
                    else
                    {
                        list3.Add(list2[list2Lenght]);
                        list2Lenght++;
                        i++;
                    }
                }

                if (list1Lenght == list1.Count)
                {
                    list3.Add(list2[list2Lenght]);
                    list2Lenght++;
                }
                else if (list2Lenght == list2.Count)
                {
                    list3.Add(list1[list1Lenght]);
                    list1Lenght++;
                }
            }
            Console.WriteLine(string.Join(" ", list3));

        }
    }
}
