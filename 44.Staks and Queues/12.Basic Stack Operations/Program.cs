using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int min = stack.Count();

            for (int i = 0; i < Math.Min(min, data[1]); i++)
            {
                stack.Pop();
            }

            if (stack.Contains(data[2]))
            {
                Console.WriteLine($"true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
