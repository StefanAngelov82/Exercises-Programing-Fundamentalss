using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int a = (int) Math.Ceiling(numbers.Count / 2.0);

            int[] arr = new int[a]; 
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                result.Add(numbers[i] + numbers[numbers.Count - i - 1]);
                arr[i] = numbers[i] + numbers[numbers.Count - i - 1];
            }

            if (numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count / 2]);
                arr[numbers.Count / 2] = numbers[numbers.Count / 2];
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(string.Join(" ", result));



        }
    }
}
