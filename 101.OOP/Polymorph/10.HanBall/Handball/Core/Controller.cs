using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    internal class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***League Standings***");

            foreach (var player in teams.Models.OrderByDescending(x =>x.PointsEarned).ThenByDescending(x => x.OverallRating).ThenBy(x=>x.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return String.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!teams.ExistsModel(teamName))
            {
                return String.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = players.GetModel(playerName);

            if (player.Team != null)
            {
                return String.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            
            ITeam team = teams.GetModel(teamName);
            team.SignContract(player);

            return String.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam team1 = teams.GetModel(firstTeamName);
            ITeam team2 = teams.GetModel(secondTeamName);

            if (team1.OverallRating > team2.OverallRating)
            {
                team1.Win();
                team2.Lose();

                return String.Format(OutputMessages.GameHasWinner, team1.Name, team2.Name);
            }
            else if (team1.OverallRating < team2.OverallRating)
            {
                team2.Win();
                team1.Lose();

                return String.Format(OutputMessages.GameHasWinner, team2.Name, team1.Name);
            }
            else
            {
                team1.Draw();
                team2.Draw();

                return String.Format(OutputMessages.GameIsDraw, team1.Name, team2.Name);
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(CenterBack) && typeName != nameof(ForwardWing) && typeName != nameof(Goalkeeper))
            {
                return String.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            IPlayer player = players.Models.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                return String.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), player.GetType().Name);
            }

            IPlayer currentPlayer;

            if (typeName == nameof(CenterBack))
            {
                currentPlayer = new CenterBack(name);
            }
            else if (typeName == nameof(ForwardWing))
            {
                currentPlayer = new ForwardWing(name);
            }
            else
            {
                currentPlayer = new Goalkeeper(name);
            }

            players.AddModel(currentPlayer);

            return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            ITeam team = teams.GetModel(name);

            if (team != null)
            {
                return String.Format(OutputMessages.TeamAlreadyExists, name , nameof(TeamRepository));
            }

            ITeam newTeam = new Team(name);
            teams.AddModel(newTeam);

            return String.Format(OutputMessages.TeamSuccessfullyAdded, name ,nameof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***"); 
            
            ITeam currentTeam = teams.GetModel(teamName);

            foreach (var player in currentTeam.Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                sb.AppendLine(player.ToString());
            }
            
            return sb.ToString().Trim();           

        }
    }
}
