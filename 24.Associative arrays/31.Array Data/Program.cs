using System;
using System.Linq;

namespace Array_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();             

            string command = Console.ReadLine();

            switch (command)
            {
                case "Min":

                    Console.WriteLine(string.Join(" ", numbers.Where(x => x > numbers.Average()).Min()));

                    break;
                case "Max":

                    Console.WriteLine(string.Join(" ", numbers.Where(x => x > numbers.Average()).Max()));

                    break;
                case "All":

                    Console.WriteLine(string.Join(" ", numbers.Where(x => x > numbers.Average()).OrderBy(x => x)));

                    break;
            }
        }
    }
}
