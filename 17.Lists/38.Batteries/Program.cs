using System;
using System.Collections.Generic;
using System.Linq;

namespace Batteries
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<double> Battarylife = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            List<double> LoadPerHour = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToList();
            int testhours = int.Parse(Console.ReadLine());

            for (int i = 0; i < Battarylife.Count; i++)
            {
                double LoadForTest = LoadPerHour[i] * testhours;

                if (Battarylife[i] >= LoadForTest )
                {
                    double leftLife = Battarylife[i] - LoadForTest;

                    Console.WriteLine($"Battery {i + 1}: {leftLife:F2} mAh ({(leftLife / Battarylife[i]) * 100:F2})%");
                }
                else
                {
                    double hoursSustainLoad = (Math.Ceiling(Battarylife[i] / LoadPerHour[i]));

                    Console.WriteLine($"Battery {i + 1}: dead (lasted {hoursSustainLoad} hours)");
                }
            }
        }
    }
}
