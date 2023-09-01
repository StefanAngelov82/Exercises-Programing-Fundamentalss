using System;
using System.Collections.Generic;

namespace Dict_Ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, int> result = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end")
            {
                int value;

                if (int.TryParse(ComandArg(input, 1), out value))
                {
                    AddElementsNewValue(input, result);
                }
                else if (result.ContainsKey(ComandArg(input, 1)))
                {
                    AddElementCopyValue(input, result);
                }
            }

            Print(result);
        }

        static void AddElementCopyValue(string input, Dictionary<string, int> result)
        {
            if (!result.ContainsKey(ComandArg(input, 0)))
            {
                result[ComandArg(input, 0)] = 0;
            }
            result[ComandArg(input, 0)] = result[ComandArg(input, 1)];
        }

        static void Print(Dictionary<string, int> result)
        {
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} === {kvp.Value}");
            }
        }

        static void AddElementsNewValue(string input, Dictionary<string, int> result)
        {
            if (!result.ContainsKey(ComandArg(input, 0)))
            {
                result[ComandArg(input, 0)] = 0;
            }

            result[ComandArg(input, 0)] = int.Parse(ComandArg(input, 1));
        }

        static string ComandArg(string input, int arg)
        {
            string[] arr = input.Split(" = ");

            if (arg == 0) return arr[0];
            else return arr[1];
        }
    }
    }
}
