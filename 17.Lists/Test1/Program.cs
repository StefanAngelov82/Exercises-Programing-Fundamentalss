using System;
using System.Collections.Generic;

namespace test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < number; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(string.Join(", ", list));

        }
    }
}
