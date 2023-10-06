using System;
using System.Collections.Generic;
using System.Linq;

namespace Integer_Insertion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                
                int index = (int)input[0] - 48;
                int number = int.Parse(input);

                numbers.Insert(index, number);
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
