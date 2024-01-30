using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                AddCloathsAndQuantities(wardrobe, input, color);
            }

            string[] target = Console.ReadLine().Split();

            Printing(wardrobe, target);
        }

        static void Printing(Dictionary<string, Dictionary<string, int>> wardrobe, string[] target)
        {
            foreach (var color in wardrobe.Keys)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var cloaths in wardrobe[color])
                {
                    Console.Write($"* {cloaths.Key} - {cloaths.Value}");

                    if (color == target[0] && cloaths.Key == target[1])
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }

        static void AddCloathsAndQuantities(Dictionary<string, Dictionary<string, int>> wardrobe, string[] input, string color)
        {
            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            for (int j = 1; j < input.Length; j++)
            {
                if (!wardrobe[color].ContainsKey(input[j]))
                {
                    wardrobe[color][input[j]] = 0;
                }

                wardrobe[color][input[j]]++;
            }
        }
    }
}
