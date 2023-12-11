using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Queue<int> data = new Queue<int>();

            for (int i = 0; i < N; i++)
            {
                int[] inputAtg = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                data.Enqueue(inputAtg[0] - inputAtg[1]);
            }

            int globalCounter = 0; 
            int sum = 0;
            int counter = 0;
            int indexCounter = 0;
            int TargetIndex = 0;

            while (counter < data.Count)
            {
                sum += data.Peek();

                if (sum >= 0)
                {
                    counter++;
                    indexCounter++;
                }
                else
                {
                    counter = 0;
                    indexCounter++;
                    TargetIndex += indexCounter;
                    indexCounter = 0;
                    sum = 0;
                }

                data.Enqueue (data.Dequeue());
                globalCounter++;
            }

            Console.WriteLine(TargetIndex);
                      
        }
    }
}
