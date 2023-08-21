using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();

            int finishRound = times.Count / 2;
            double FirstRaicerTime = 0;
            double SecondRaicerTime = 0;

            for (int i = 0; i < finishRound; i++)
            {
                FirstRaicerTime += times[i];
                if (times[i] == 0)
                {
                    FirstRaicerTime *= 0.8;
                }

                SecondRaicerTime += times[times.Count - 1 - i];
                if (times[times.Count - 1 - i] == 0)
                {
                    SecondRaicerTime *= 0.8;
                }
            }
            if (FirstRaicerTime < SecondRaicerTime)
            {
                Console.WriteLine($"The winner is left with total time: {FirstRaicerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {SecondRaicerTime}");
            }

        }
    }
}
