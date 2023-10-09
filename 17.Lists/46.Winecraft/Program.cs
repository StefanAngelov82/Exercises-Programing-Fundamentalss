using System;
using System.Collections.Generic;
using System.Linq;

namespace Winecraft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> grape = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int growthDays = int.Parse(Console.ReadLine());

            int limit = grape.Count;

            while (growthDays <= limit)
            {
                for (int i = 1; i <= growthDays; i++)
                {
                    GrapeGrowth(ref grape);
                    GrapeCompetition(ref grape);
                }

                GrapeElimination(ref grape, growthDays);

                limit = grape.Count(x => x > 0);
            }

            Console.WriteLine(String.Join(" ", grape.Where(x => x > 0)));
        }

        private static void GrapeElimination(ref List<int> grape, int growthDays)
        {
            for (int i = 0; i < grape.Count; i++)
            {
                if (grape[i] <= growthDays)
                {
                    grape[i] = 0;
                }
            }
        }

        static void GrapeGrowth(ref List<int> grape)
        {
            for (int j = 0; j < grape.Count; j++)
            {
                grape[j]++;
            }
        }

        static void GrapeCompetition(ref List<int> grape)
        {
            for (int k = 1; k < grape.Count - 1; k++)
            {
                if (grape[k] > grape[k - 1] && grape[k] > grape[k + 1])
                {
                    grape[k - 1] = grape[k - 1] - 2;
                    grape[k + 1] = grape[k + 1] - 2;

                    if (grape[k - 1] >= 0)
                    {
                        grape[k]++;
                    }

                    if (grape[k + 1] >= 0)
                    {
                        grape[k]++;
                    }
                }
            }
        }
    }
}
