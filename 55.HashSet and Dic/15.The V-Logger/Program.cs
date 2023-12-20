using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> data = new Dictionary<string, Vlogger>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArg = input.Split();

                if (inputArg[1] == "joined")
                {
                    string name = inputArg[0];

                    if (!data.ContainsKey(name))
                    {
                        Vlogger current = new Vlogger(name);

                        data.Add(name, current);
                    }
                }
                else if (inputArg[1] == "followed")
                {
                    string name1 = inputArg[0];
                    string name2 = inputArg[2];

                    if (data.ContainsKey(name1) && data.ContainsKey(name2) && name1 != name2)
                    {
                        if (!data[name2].Followed.Contains(name1))
                        {
                            data[name2].Followed.Add(name1);
                            data[name1].Following.Add(name2);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {data.Count} vloggers in its logs.");

            bool isFirst = true;
            int counter = 1;

            foreach (var kvp in data.OrderByDescending(x => x.Value.Followed.Count).ThenBy(x => x.Value.Following.Count))
            {
                if (isFirst)
                {
                    Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Followed.Count} followers, {kvp.Value.Following.Count} following");

                    foreach (var follower in kvp.Value.Followed.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }

                    isFirst = false;
                }
                else
                {
                    Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Followed.Count} followers, {kvp.Value.Following.Count} following");
                }

                counter++;
            }

        }
    }
    class Vlogger
    {
        public string Name { get; set; }

        public List<string> Following { get; set; }

        public List<string> Followed { get; private set; }

        public Vlogger(string name)
        {
            this.Name = name;
            this.Following = new List<string>();
            this.Followed = new List<string>();
        }
    }
}
