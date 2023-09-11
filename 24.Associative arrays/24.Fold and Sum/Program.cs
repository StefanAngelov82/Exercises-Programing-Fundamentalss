using System;
using System.Linq;
using System.Xml;

namespace Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers =Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int counter = numbers.Length / 4;

            int[] first = (numbers.Take(counter).Reverse()).Concat(numbers.Reverse().Take(counter)).ToArray();
            int[] second = numbers.Skip(counter).Take(2 * counter).ToArray();

            for (int i = 0; i < first.Length; i++)
            {
                Console.Write($"{first[i] + second[i]} ");
            }

            //Console.WriteLine(String.Join(" ", first ));
            //Console.WriteLine(String.Join(" ", second ));
        }
    }
}
