using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Forum_Topics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> tagColection = new Dictionary<string, HashSet<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine() ) != "filter")
            {
                string[] inputArg = input.Split( new char[] {' ','-','>',','}, StringSplitOptions.RemoveEmptyEntries);

                string name  = inputArg[0];

                if (!tagColection.ContainsKey(name))
                {
                    tagColection[name] = new HashSet<string>();
                }

                for (int i = 1; i < inputArg.Length; i++)
                {
                    tagColection[name].Add(inputArg[i]);
                }
            }

            string[] filtes = Console.ReadLine().Split(", ");

            foreach (string names in tagColection.Keys)
            {
                int counter = 0;

                foreach (var filter  in filtes)
                {
                    if (tagColection[names].Contains(filter))
                    {
                        counter++;
                    }
                }

                if (counter == filtes.Length)
                {            
                   Console.WriteLine($"{names} | {string.Join(", ", tagColection[names].Select(p => "#" + p))}");                    
                }
            }

            
        }
    }
}
