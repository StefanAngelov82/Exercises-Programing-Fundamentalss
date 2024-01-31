using Microsoft.VisualBasic;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> data = new Dictionary<string, Vlogger> ();

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
                    string firsName = inputArg[0];
                    string secondName = inputArg[2];

                    if (data.ContainsKey(firsName) && data.ContainsKey(secondName) && firsName != secondName)
                    {
                        if (!data[secondName].Followers.Contains(firsName))
                        {
                            data[secondName].Followers.Add(firsName);
                            data[firsName].Following.Add(secondName);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {data.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var person in data.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x =>x.Value.Following.Count))
            {
                Console.WriteLine($"{counter}. {person.Key} : {person.Value.Followers.Count} followers, {person.Value.Following.Count} following");

                if (counter == 1)
                {
                    foreach (var follower in person.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }               

                counter++;
            }
        }
    }
    class Vlogger
    {
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }
    }
    
}