using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int N  = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine()
                    .Split(new string[] {","," -> "},StringSplitOptions.RemoveEmptyEntries);

                string color = inputArg[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 1; j < inputArg.Length; j++)
                {
                    string cloth = inputArg[j];

                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] target = Console.ReadLine().Split();

            string targetColor = target[0];
            string targetCloth = target[1];


            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == targetColor && cloth.Key == targetCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
