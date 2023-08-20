using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string sentanse = Console.ReadLine();

            List<string> list = new List<string>();            

            int sum;
            int count;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum = 0;
                
                while (numbers[i] > 0)
                {
                    int cuttenDigit = numbers[i] % 10;
                    sum += cuttenDigit;
                    numbers[i] = numbers[i] / 10;
                }

                if (sum <= sentanse.Length)
                {
                    count = sum;
                }
                else
                {
                    count = sum % sentanse.Length;
                }

                list.Add(sentanse[count].ToString()); 
                sentanse = sentanse.Remove(count,1);
            }
            Console.WriteLine(string.Join("",list));

        }
    }
}
