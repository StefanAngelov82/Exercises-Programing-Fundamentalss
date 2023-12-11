using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Calculate_Sequence_with_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal N = decimal.Parse(Console.ReadLine());

            Queue<decimal> data = new Queue<decimal>();

            data.Enqueue(N);

            for (int i = 1; i < 18; i++)
            {
                data.Enqueue(N + 1);
                data.Enqueue(2 * N + 1);
                data.Enqueue(N + 2);

                N = data.ElementAtOrDefault(i);
            }

            Console.WriteLine(String.Join(" ",data.Take(50)));
        }
    }
}
