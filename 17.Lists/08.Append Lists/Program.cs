using System;
using System.Linq;
using System.Collections.Generic;


namespace Append_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("|").Reverse().ToList();

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Trim();
            }         
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
