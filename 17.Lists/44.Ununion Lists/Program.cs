using System;
using System.Collections.Generic;
using System.Linq;

namespace Ununion_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    bool isNotExist = true;

                    for (int k = 0; k < numbersData.Count; k++)
                    {
                        if (input[j] == numbersData[k])
                        {
                            numbersData.Remove(numbersData[k]);
                            k--;

                            isNotExist = false;
                        }                         
                    }

                    if (isNotExist) numbersData.Add(input[j]);                    
                }
            }

            numbersData.Sort();

            Console.WriteLine(string.Join(" ", numbersData));
        }
    }
}
