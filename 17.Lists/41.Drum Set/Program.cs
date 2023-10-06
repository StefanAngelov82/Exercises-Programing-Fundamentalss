using System;
using System.Collections.Generic;
using System.Linq;

namespace Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> initialQualityDrums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> currentQualityDrums = new List<int>(initialQualityDrums); 

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < currentQualityDrums.Count ; i++)
                {
                    currentQualityDrums[i] -= hitPower;

                    if (currentQualityDrums[i] <= 0)
                    {
                        DrrumOperation(initialQualityDrums, currentQualityDrums,  ref savings, ref i);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", currentQualityDrums));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }

        private static void DrrumOperation(List<int> initialQualityDrums, List<int> currentQualityDrums,  ref double savings,  ref int index)
        {
            double newDrumprice = initialQualityDrums[index] * 3;

            if (savings >= newDrumprice )
            {
                savings -= newDrumprice;

                currentQualityDrums[index] = initialQualityDrums[index];
            }
            else
            {
                initialQualityDrums.RemoveAt(index);
                currentQualityDrums.RemoveAt(index);
                index--;
            }
        }
    }
}
