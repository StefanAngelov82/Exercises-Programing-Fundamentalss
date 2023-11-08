namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            Dictionary<string, User> data = new Dictionary<string, User>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                AddDataInTest(test, input);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {          
                User current =  UserValidation(input, test);
                
                if (current != null)
                {
                    AddingUser(data, current);
                }
            }

            KeyValuePair<string, User> target = data.OrderByDescending(x => x.Value.Contest.Sum(x => x.Points)).First();

            string name = target.Key;
            int totalpoints = target.Value.Contest.Sum(x => x.Points);

            Console.WriteLine($"Best candidate is {name} with total {totalpoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var person in data.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{person.Key}");

                foreach (var contest in person.Value.Contest.OrderByDescending(x => x.Points))
                {
                    string contestname = contest.ContestName;
                    int contestpoints = contest.Points;

                    Console.WriteLine($"#  {contestname} -> {contestpoints}");
                }
            }

        }

        private static void AddingUser(Dictionary<string, User> data, User current)
        {
            if (!data.ContainsKey(current.Name))
            {
                data.Add(current.Name, current);
            }
            else
            {
                if (!data[current.Name].Contest.Contains(current.Contest[0]))
                {
                    data[current.Name].Contest.Add(current.Contest[0]);
                }
                else
                {
                    int index = data[current.Name].Contest.IndexOf(current.Contest[0]);

                    if (data[current.Name].Contest[index].Points < current.Contest[0].Points)
                    {
                        data[current.Name].Contest[index].Points = current.Contest[0].Points;
                    }
                }
            }
        }

        private static User UserValidation(string input, Dictionary<string, string> test)
        {
            string[] inputArg = input.Split("=>");

            string contest = inputArg[0];
            string password = inputArg[1];
            string name = inputArg[2];
            int points = int.Parse(inputArg[3]);

            if (test.ContainsKey(contest) && test[contest] == password)
            {
                Contest currenContest = new Contest(points,contest, password);

                User currentUser = new User(name);

                currentUser.Contest.Add(currenContest);

                return currentUser;
            }

            return null;
            
        }

        static void AddDataInTest(Dictionary<string, string> test, string input)
        {
            string[] inputArg = input.Split(":");

            string contest = inputArg[0];
            string password = inputArg[1];

            if (!test.ContainsKey(contest))
            {
                test.Add(contest, password);
            }
        }
    }
    class User
    {
        public string Name { get; set; }

        public List<Contest> Contest { get; set; }


        public User(string name)
        {
            Name = name;
            Contest = new List<Contest>();
        }    
               
    }
    class Contest
    {
        public string ContestName { get; set; }
        public int Points { get; set; }
        public string Password { get; set; }

        public Contest(int points, string contestName, string password)
        {
            Points = points;
            ContestName = contestName;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            if(obj is Contest)
            {
                Contest other = (Contest)obj;

                return this.ContestName == other.ContestName;
            }
            return false;
        }
    }
}