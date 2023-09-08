using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Key_Value_Value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordsData = new Dictionary<string, List<string>>();

            string codKey = Console.ReadLine();
            string codValue = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            AddData(wordsData, count);

            ConformIsContainsInitialConditions(wordsData, codKey, codValue);
        }

        private static void ConformIsContainsInitialConditions(Dictionary<string, List<string>> wordsData, string codKey, string codValue)
        {
            foreach (var key in wordsData.Keys)
            {
                bool isCorrect = false;

                List<string> foundValues = new List<string>();

                if (key.Contains(codKey))
                {
                    foreach (var values in wordsData[key])
                    {
                        if (values.Contains(codValue))
                        {
                            foundValues.Add(values);
                            isCorrect = true;
                        }
                    }
                }

                Print(key, isCorrect, foundValues);
            }
        }

        private static void Print(string key, bool isCorrect, List<string> foundValues)
        {
            if (isCorrect)
            {
                Console.WriteLine($"{key}:");
                Console.WriteLine(string.Join(Environment.NewLine, foundValues.Select((x => "-" + x))));
            }
        }

        private static void AddData(Dictionary<string, List<string>> wordsData, int count)
        {
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" => ").ToArray();

                string key = input[0];
                string[] values = input[1].Split(';');

                if (!wordsData.ContainsKey(key))
                {
                    wordsData.Add(key, new List<string>());
                }

                wordsData[key].AddRange(values);
            }
        }
    }
}
