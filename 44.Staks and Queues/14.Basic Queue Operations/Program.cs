using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            Queue<int> Data = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < data[1]; i++)
            {
                Data.Dequeue();
            }

            if (Data.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (Data.Contains(data[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(Data.Min());
            }
        }
    }
}
