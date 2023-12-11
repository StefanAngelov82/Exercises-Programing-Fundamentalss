using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Calculate_Sequence_with_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal N = decimal.Parse(Console.ReadLine());

            Queue<decimal> data = new Queue<decimal>();

            int counter = 49;

            Console.Write($"{N} ");

            while (counter > 0)
            {
                Console.Write($"{N + 1} ");
                data.Enqueue(N + 1); 
                counter--;

                if(counter == 0) break;

                Console.Write($"{2 * N + 1} ");
                data.Enqueue(2 * N + 1);
                counter--;

                if (counter == 0) break;
               

                Console.Write($"{N + 2} ");
                data.Enqueue(N + 2);
                counter--;               

                N = data.Dequeue();                
            }                     
        }
    }
}
