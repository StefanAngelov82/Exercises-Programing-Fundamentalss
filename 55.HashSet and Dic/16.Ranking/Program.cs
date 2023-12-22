using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> examPass = new Dictionary<string, string>();
            Dictionary<string, User> data = new Dictionary<string, User>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                ContestData(examPass, input);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                DataEntering(examPass, data, input);
            }

            Printing(data);
        }

        static void Printing(Dictionary<string, User> data)
        {
            KeyValuePair<string, User> bestUser = data.OrderByDescending(X => X.Value.Contests.Sum(y => y.Value)).First();

            string name = bestUser.Key;
            decimal points = bestUser.Value.Contests.Sum(x => x.Value);

            Console.WriteLine($"Best candidate is {name} with total {points} points.");
            Console.WriteLine("Ranking:");

            foreach (var names in data.OrderBy(x => x.Key))
            {
                Console.WriteLine(names.Key);

                foreach (var kvp in names.Value.Contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }

        private static void DataEntering(Dictionary<string, string> examPass, Dictionary<string, User> data, string input)
        {
            string[] inputArg = input.Split("=>");

            string contest = inputArg[0];
            string password = inputArg[1];
            string userName = inputArg[2];
            decimal points = decimal.Parse(inputArg[3]);

            if (examPass.ContainsKey(contest) && examPass[contest] == password)
            {
                User current = new User(userName);

                if (!data.ContainsKey(userName))
                {
                    data[userName] = current;
                }

                if (!data[userName].Contests.ContainsKey(contest))
                {
                    data[userName].Contests[contest] = 0;
                }

                if (data[userName].Contests[contest] < points)
                {
                    data[userName].Contests[contest] = points;
                }
            }
        }


        static void ContestData(Dictionary<string, string> examPass, string input)
        {
            string[] inputArg = input.Split(':');

            string contest = inputArg[0];
            string contestPass = inputArg[1];

            if (!examPass.ContainsKey(contest))
            {
                examPass[contest] = contestPass;
            }
        }

        class User
        {
            public string Name { get; set; }
            public Dictionary<string, decimal> Contests{ get; set; }

            public User(string name)
            {
                this.Name = name;
                this.Contests = new Dictionary<string, decimal>();
            }
        }

    }
}
