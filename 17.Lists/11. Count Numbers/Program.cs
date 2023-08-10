using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Count_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            numbers.Sort();

            List<int> index = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int count = 0;
                
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }                    
                }
                index.Add(count);
            }

            Console.WriteLine($"{numbers[0]} -> {index[0]}");
            int k = 0;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[k] != numbers[i])
                {
                    Console.WriteLine($"{numbers[i]} -> {index[i]}");
                    k = i;
                }
            }

            //Console.WriteLine(string.Join(",", numbers));
            //Console.WriteLine(string.Join(",", index));
        }
    }
}
