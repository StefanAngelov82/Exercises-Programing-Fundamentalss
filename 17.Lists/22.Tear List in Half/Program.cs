using System;
using System.Collections.Generic;
using System.Linq;

namespace Tear_List_in_Half
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialNumbers = Console.ReadLine().Split(' ');

            int middle = initialNumbers.Length / 2;

            string[] partOne = initialNumbers[0..middle];
            string[] partTwo = initialNumbers[middle..];

            List<string> result = new List<string>();

            for (int i = 0; i < partOne.Length; i++)
            {
                string firstElement = partTwo[i].First().ToString();
                string secondElement = partTwo[i].Last().ToString();

                result.Add(firstElement);
                result.Add(partOne[i]);
                result.Add(secondElement);
            }

            Console.WriteLine(string.Join(" ", result));
            
        }
    }
}
