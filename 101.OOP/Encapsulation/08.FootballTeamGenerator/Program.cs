using FootballTeamGenerator.models;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split(";");

                string ketWord = inputArg[0];


                try
                {
                    switch (ketWord)
                    {
                        case "Team":
                            string name = inputArg[1];

                            teams[name] = new Team(name);

                            break;

                        case "Add":
                            string nameTeam = inputArg[1];

                            if (!teams.ContainsKey(nameTeam))
                            {
                                Console.WriteLine($"Team {nameTeam} does not exist.");
                            }
                            else
                            {
                                string namePlayer = inputArg[2];
                                int endurance = int.Parse(inputArg[3]);
                                int sprint = int.Parse(inputArg[4]);
                                int dribble = int.Parse(inputArg[5]);
                                int passing = int.Parse(inputArg[6]);
                                int shooting = int.Parse(inputArg[7]);


                                teams[nameTeam].AddPlayer(new Player(namePlayer, endurance, sprint, dribble, passing, shooting));
                            }

                            break;

                        case "Remove":
                            string removedTeamName = inputArg[1];

                            if (!teams.ContainsKey(removedTeamName))
                            {
                                Console.WriteLine($"Team {removedTeamName} does not exist.");
                            }
                            else
                            {
                                string removedPlayerName = inputArg[2];

                                teams[removedTeamName].RemovePlayer(removedPlayerName);
                            }
                            break;

                        case "Rating":
                            string teamNameStats = inputArg[1];

                            if (!teams.ContainsKey(teamNameStats))
                            {
                                Console.WriteLine($"Team {teamNameStats} does not exist.");
                            }
                            Console.WriteLine($"{teamNameStats} - {teams[teamNameStats].Rating}");

                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}