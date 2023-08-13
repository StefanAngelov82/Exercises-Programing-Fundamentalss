using System;
using System.Collections.Generic;
using System.Linq;

namespace Equal_Sum_After_Extraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            List<int> numbersTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbersOne.Length; i++)
            {
                if (numbersTwo.Contains(numbersOne[i]))
                {
                    numbersTwo.Remove(numbersOne[i]);
                    i--;
                }
            }

            int sumOne = numbersOne.Sum();
            int sumTwo = numbersTwo.Sum();

            if (sumOne == sumTwo)
            {
                Console.WriteLine($"Yes. Sum: {sumOne}");
            }
            else
            {
                Console.WriteLine($"No. Diff: {Math.Abs(sumOne - sumTwo)}");
            }
        }
    }
}
