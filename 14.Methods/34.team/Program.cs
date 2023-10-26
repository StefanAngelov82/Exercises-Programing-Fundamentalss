namespace team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> teams = new Dictionary<string, Dictionary<string, int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Result")
            {
                Players player = Players.TeamParse(input);

                if (!teams.ContainsKey(player.TeamName))
                {
                    teams[player.TeamName] = new Dictionary<string, int>();
                }

                teams[player.TeamName].Add(player.Player, player.Points);
            }

            foreach (var team in teams.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{team.Key} ->{team.Value.Values.Sum()}");

                int maxScore = team.Value.Values.Max();

                foreach (var pl in team.Value)
                {
                    if (pl.Value == maxScore)
                    {
                        Console.WriteLine($"Most points scored by {pl.Key}");
                    }
                }
            }
        }
        class Players
        {
            public string TeamName { get; set; }
            public string Player { get; set; }
            public int Points { get; set; }

            public Players(string name, string player, int points)
            {
                this.TeamName = name;
                this.Player = player;
                this.Points = points;
            }

            public static Players TeamParse(string input)
            {
                string[] inputArg = input.Split('|');

                string teamName = "";
                string playerName = "";
                int points = int.Parse(inputArg[2]);

                if (inputArg[0].ToUpper() == inputArg[0])
                {
                    teamName = inputArg[0];
                    playerName = inputArg[1];
                }
                else
                {
                    teamName = inputArg[1];
                    playerName = inputArg[0];
                }

                teamName = teamName.Replace("@", "*");
                teamName = teamName.Replace("$", "*");
                teamName = teamName.Replace("%", "*");

                playerName = playerName.Replace("@", "*");
                playerName = playerName.Replace("$", "*");
                playerName = playerName.Replace("%", "*");

                int index = teamName.IndexOf("*");

                while (index != -1)
                {
                    teamName = teamName.Remove(index, 1);
                    index = teamName.IndexOf("*", index);
                }

                index = playerName.IndexOf("*");

                while (index != -1)
                {
                    playerName = playerName.Remove(index, 1);
                    index = playerName.IndexOf("*", index);
                }


                return new Players(teamName, playerName, points);
            }
        }
    }
}