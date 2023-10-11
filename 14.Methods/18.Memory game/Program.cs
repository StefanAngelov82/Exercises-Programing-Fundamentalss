using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Memory_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split()
                .ToList();

            string input = String.Empty;
            int move = 0;
            


            while ((input = Console.ReadLine()) != "end")
            {
                int[] inputArg = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                if (data.Count == 0)
                {                
                   Console.WriteLine($"You have won in {move} turns!");
                   return;            
                }

                int index1 = inputArg[0];
                int index2 = inputArg[1];
                move++;

                if (!(index1 >= 0 && index1 < data.Count) ||
                    !(index2 >= 0 && index2 < data.Count) ||
                      index1 == index2)
                {
                    Panalty(data, move);
                }
                else if (data[index1] == data[index2])
                {
                    RemovingElements(data, index1, index2);
                }
                else if (data[index1] != data[index2])
                {
                    Console.WriteLine("Try again!");
                }
                
            }

           
           
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", data));
           
            
        }

        private static void RemovingElements(List<string> data, int index1, int index2)
        {
            Console.WriteLine($"Congrats! You have found matching elements - {data[index1]}!");

            if (index1 < index2)
            {
                data.RemoveAt(index2);
                data.RemoveAt(index1);
            }
            else
            {
                data.RemoveAt(index1);
                data.RemoveAt(index2);
            }
        }

        private static void Panalty(List<string> data, int move)
        {
            string add = "-" + move + "a";
            string[] adds = { add, add };

            data.InsertRange(data.Count / 2, adds);

            Console.WriteLine("Invalid input! Adding additional elements to the board");
        }
    
    }
}
