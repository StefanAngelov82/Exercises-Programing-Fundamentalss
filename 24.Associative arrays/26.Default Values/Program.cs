using System;
using System.Collections.Generic;
using System.Linq;

namespace Default_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input.Split(" -> ");

                string keyWord = inputArg[0];
                string value = inputArg[1];

                data[keyWord] = value;
            }

            input = Console.ReadLine();

            Dictionary<string, string> unchanged = data
                .Where(x => x.Value != "null")
                .ToDictionary(key => key.Key, value => value.Value);


            Dictionary<string, string> changed  =data
                .Where(x => x.Value == "null")
                .ToDictionary(key => key.Key, value => input);

            

            foreach (var kvp in unchanged.OrderByDescending(x => x.Value.Length))
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }

            Console.WriteLine(new string('-', 50));

            foreach (var kvp in changed)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }









        }
    }
}
