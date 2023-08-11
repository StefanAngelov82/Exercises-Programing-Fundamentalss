using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());

            string input =String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if(InputRecognition(input,0) == "Add")
                {
                    wagons.Add(int.Parse(InputRecognition(input,1)));
                }
                else
                {
                    PassengersLoad(wagons, capacity, input);
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void PassengersLoad(List<int> wagons, int capacity, string input)
        {
            int addPassengers = int.Parse(InputRecognition(input, 0));

            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + addPassengers <= capacity)
                {
                    wagons[i] += addPassengers;
                    break;
                }
            }
        }

        static string InputRecognition(string input, int inputPart)
        {
            string[] command = input.Split(' ');

            if (inputPart == 0) return command[0];
            else                return command[1]; 
        }
    }
}
