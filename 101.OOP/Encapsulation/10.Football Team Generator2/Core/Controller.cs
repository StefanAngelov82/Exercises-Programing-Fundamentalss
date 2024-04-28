using Football_Team_Generator.Core.Interface;
using Football_Team_Generator.Factory;
using Football_Team_Generator.Factory.Interface;
using Football_Team_Generator.Models;
using Football_Team_Generator.Repository;
using Football_Team_Generator.Repository.Interface;
using Football_Team_Generator.Utilities;

namespace Football_Team_Generator.Core
{
    public class Controller : IController
    {
        private IRepository<FootballTeam> _teamsRepository;
        private IFactory _factory;

        public Controller()
        {
            _teamsRepository = new RepositoryTeams();
            _factory = new FactoryModel();
        }

        public string AddPlayerToTeam( string teamName, string playerName,
            int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Players player = _factory.PlayerCreator(playerName, endurance, sprint, dribble, passing, shooting);

            FootballTeam team = _teamsRepository.GetFromRepository(teamName);

            if (team == null)
                return String.Format(Messages.TeamDoNotExist, teamName, nameof(RepositoryTeams));           

            if (team.TeamPlayers.Contains(player))
                return String.Format(Messages.PlayerIsInTeam);

            team.AddPlayer(player);

            return String.Format(Messages.PlayerSignContract, playerName, teamName);
        }

        public string AddTeamToRepository(string teamName)
        {   
            FootballTeam team = _factory.TeamCreator(teamName);

            FootballTeam existingTeam = _teamsRepository.GetFromRepository(teamName);            

            if (existingTeam == null)
            {
                _teamsRepository.AddToRepository(team);
                return String.Format(Messages.AddingTeamInRepository, teamName, nameof(RepositoryTeams)); ;
            }

            return String.Format(Messages.UnsuccessfulAddingTeamInRepository, teamName, nameof(RepositoryTeams));
        }

        public string GenerateStatistics(string teamName)
        {
            FootballTeam team = _teamsRepository.GetFromRepository(teamName);

            if (team == null)
                return String.Format(Messages.TeamDoNotExist, teamName, nameof(RepositoryTeams));

            return $"{team.Name} - {team.Rating}";
        }

        public string RemovePlayerOfTeam(string teamName, string playerName)
        {
            FootballTeam team = _teamsRepository.GetFromRepository(teamName);

            if (team == null)
                return String.Format(Messages.TeamDoNotExist, teamName, nameof(RepositoryTeams));            

            if (!team.TeamPlayers.Any(x =>x.Name == playerName))
                return String.Format(Messages.PlayerIsNotInTeam);

            Players player = team.TeamPlayers.FirstOrDefault(x =>x.Name == playerName);

            return team.RemovePlayer(player);
        }

        
    }   
}
