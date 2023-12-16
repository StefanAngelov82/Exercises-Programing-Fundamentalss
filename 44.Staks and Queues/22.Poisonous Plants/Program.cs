using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); 
            
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Reverse(data);

            Queue<int> queue = new Queue<int>(data);

            bool isDead = false;
            int days = 0;

            while (!isDead)
            {
                int counter = queue.Count;
                days++;
                isDead = true;

                for (int i = 0; i < counter - 1 & counter > 1; i++)
                {
                    int current = queue.Dequeue();

                    if (current <= queue.Peek())
                    {
                        queue.Enqueue(current);
                    }
                    else
                    {
                        isDead = false;
                    }
                }

                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(days - 1);
        }
    } //6 5 8 4 7 10 9 2 3 11 6 9 8 7 5 4 13 10 8 9 6 15 4 3 8
}
