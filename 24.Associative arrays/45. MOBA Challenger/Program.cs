namespace _3._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> pool = new List<Player>();

            string input = String.Empty;

           while ((input = Console.ReadLine())  is not "Season end")
           {
                DataProseced(pool, input);
           }


           foreach (Player player in pool.OrderByDescending(x => x.Skills.Values.Sum()).ThenBy(x => x.PlayerName))
           {
                int totalSkill = player.Skills.Values.Sum();
                string playerName = player.PlayerName;

                Console.WriteLine($"{playerName}: {totalSkill} skill");

                foreach (var kvp in player.Skills.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($" - {kvp.Key} <::> {kvp.Value}");
                }
           }
        }

        static void DataProseced(List<Player> pool, string input)
        {
            string[] inputArg = input.Split(new string[] { " ", "->" }, StringSplitOptions.RemoveEmptyEntries);            

            if (inputArg[1] != "vs")
            {
                PlayerUpdate(pool, inputArg);
            }
            else
            {
                PlayerDuell(pool, inputArg);
            }
        }

        static void PlayerDuell(List<Player> pool, string[] inputArg)
        {
            string Player1Name = inputArg[0];
            string Player2Name = inputArg[2];

            Player FirstPlayer = pool.FirstOrDefault(x => x.PlayerName == Player1Name);
            Player SecondPlayer = pool.FirstOrDefault(x => x.PlayerName == Player2Name);

            if (FirstPlayer is not null && SecondPlayer is not null)
            {
                string[] CommonPositions = FirstPlayer.Skills.Keys.Intersect(SecondPlayer.Skills.Keys).ToArray();

                if (CommonPositions.Length > 0)
                {
                    if (FirstPlayer.Skills.Values.Sum() > SecondPlayer.Skills.Values.Sum())
                    {
                        pool.Remove(SecondPlayer);
                    }
                    else if (FirstPlayer.Skills.Values.Sum() < SecondPlayer.Skills.Values.Sum())
                    {
                        pool.Remove(FirstPlayer);
                    }
                }
            }
        }

        private static void PlayerUpdate(List<Player> pool, string[] inputArg)
        {
            string playerName = inputArg[0];
            string position = inputArg[1];
            int skill = int.Parse(inputArg[2]);

            Player current = new Player(playerName);

            current.Skills.Add(position, skill);

            if (!pool.Contains(current))
            {
                pool.Add(current);
            }
            else
            {
                Player existing = pool.FirstOrDefault(x => x.PlayerName == current.PlayerName);

                if (!existing.Skills.ContainsKey(position))
                {
                    existing.Skills.Add(position, skill);
                }
                else
                {
                    if (existing.Skills[position] < skill)
                        existing.Skills[position] = skill;
                }
            }
        }
    }

    class Player
    {
        public string PlayerName { get; set; }
        public Dictionary<string, int> Skills{ get; set; }


        public Player(string playerName)
        {
            PlayerName = playerName;
            Skills = new Dictionary<string, int>();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Player)
            {
                Player other = (Player)obj;

                return other.PlayerName == this.PlayerName;
            }
            return false;
        }
    }
}