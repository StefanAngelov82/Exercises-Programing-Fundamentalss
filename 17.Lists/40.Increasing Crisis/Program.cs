using System;
using System.Collections.Generic;
using System.Linq;

namespace Increasing_Crisis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<int> numbers= Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();           

            for (int i = 1; i <= count - 1; i++)
            {
                List<int> newNumbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToList();

                int index = numbers.Count;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] > newNumbers[0] )
                    {
                        index = j;
                        break;
                    }
                }

                numbers.InsertRange(index, newNumbers);

                bool isTrim = false;

                for (int j = index; j < Math.Min ((index + (newNumbers.Count)),numbers.Count - 1); j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        index = j + 1;
                        isTrim = true;
                        break;
                    }
                }

                if (isTrim)
                {
                    numbers.RemoveRange(index, (numbers.Count - index));
                }
            }         

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
