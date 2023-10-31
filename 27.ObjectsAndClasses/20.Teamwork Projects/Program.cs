using System.Net.WebSockets;

namespace Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamNumber = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            AddTeams(teamNumber, teams);

            AddMembers(teams);

            Printing(teams);
        }

        static void Printing(List<Team> teams)
        {
            foreach (var team in teams
                .Where(x => x.TeamMembers.Count > 1)
                .OrderByDescending(x => x.TeamMembers.Count)
                .ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");

                string leadername = team.TeamMembers[0].UserName;

                Console.WriteLine($"- {leadername}");

                foreach (var user in team.TeamMembers.OrderBy(x => x.UserName))
                {
                    if (user.UserName == leadername)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"-- {user.UserName}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team1 in teams
                .Where(x => x.TeamMembers.Count == 1)
                .OrderBy(x => x.TeamName))
            {
                Console.WriteLine($"{team1.TeamName}");
            }
        }

        static void AddMembers(List<Team> teams)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] InputArg = input.Split("->");

                string userName = InputArg[0];
                string teamName = InputArg[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.TeamMembers.Any(x => x.UserName == userName)))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    continue;
                }

                Users newUser = new Users(userName);

                foreach (Team team in teams)
                {
                    if (team.TeamName == teamName)
                    {
                        team.TeamMembers.Add(newUser);
                        break;
                    }
                }
            }
        }

        static void AddTeams(int teamNumber, List<Team> teams)
        {
            for (int i = 0; i < teamNumber; i++)
            {
                string[] InputArg = Console.ReadLine().Split('-');

                string userName = InputArg[0];
                string teamName = InputArg[1];

                bool isErrorPresent = false;

                foreach (var team in teams)
                {
                    if (team.TeamName == teamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        isErrorPresent = true;                        
                        break;
                    }

                    if (team.TeamMembers.Any(x => x.UserName == userName))
                    {
                        Console.WriteLine($"{userName} cannot create another team!");
                        isErrorPresent = true;                       
                        break;
                    }
                }

                if (isErrorPresent)
                {                   
                    continue; 
                }

                Team newteam = new Team(teamName);
                Users newUser = new Users(userName);

                newteam.TeamMembers.Add(newUser);

                teams.Add(newteam);

                Console.WriteLine($"Team {teamName} has been created by {userName}!");
            }
        }

        class Users
        {
            public string UserName { get; set; }

            public Users(string userName)
            {
                this.UserName = userName;
            }
        }
        class Team
        {
            public string TeamName { get; set; }

            public List<Users> TeamMembers { get; set; }

            public Team(string teamName)
            {
                this.TeamName = teamName;
                this.TeamMembers = new List<Users>();
            }           

        }
    }
}