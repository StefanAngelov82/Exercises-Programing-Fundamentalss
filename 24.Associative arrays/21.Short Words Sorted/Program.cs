using System;
using System.Collections.Generic;
using System.Linq;

namespace Short_Words_Sorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .ToLower()
                .Split(new char[] {' ','.',',',';',':','(',')','[',']','\"','\'','\\', '/','!','?'}, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
