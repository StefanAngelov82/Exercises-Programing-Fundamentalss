using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Сръбско_Unleashed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Singer> names = new List<Singer>();
            Dictionary<string, HashSet<string>> data = new Dictionary<string, HashSet<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string pattern = @"(?<name>[\w\s]+) @(?<location>[\w+\s]+) (?<price>\d+) (?<ticket>\d+)";

                Regex regex = new Regex(pattern);

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string location = match.Groups["location"].Value;
                    string name = match.Groups["name"].Value;
                    decimal income = decimal.Parse(match.Groups["price"].Value) * decimal.Parse(match.Groups["ticket"].Value);

                    Singer current = new Singer(name);

                    current.Income.Push(income);

                    if (!names.Contains(current))
                    {
                        names.Add(current);
                    }
                    else
                    {
                        Singer found = names.FirstOrDefault(x => x.Name == name);

                        found.Income.Push(income);
                    }

                    if (!data.ContainsKey(location))
                    {
                        data[location] = new HashSet<string>();
                    }

                    data[location].Add(name);
                }
            }

            foreach (var location in data)
            {
                Console.WriteLine(location.Key);

                List<Singer> lookFor = new List<Singer>();

                foreach (var SingerName in location.Value)
                {
                    Singer target = names.Find(x => x.Name == SingerName);
                    lookFor.Add(target);
                }

                foreach (var target in lookFor.OrderByDescending(x =>x.Revenue))
                {
                    Console.WriteLine($"#  {target.Name} -> {target.Revenue}");
                }                
            }
        }
    }
    class Singer
    {
        public string Name { get; set; }
        public Stack<decimal> Income { get; set; }

        public decimal Revenue
        {
            get
            {
                return Income.Sum();
            }
        }

        public Singer(string name)
        {
            this.Name = name;
            this.Income = new Stack<decimal>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Singer)
            {
                Singer other = (Singer)obj;

                return this.Name == other.Name;
            }

            return false;
        }

    }
}
