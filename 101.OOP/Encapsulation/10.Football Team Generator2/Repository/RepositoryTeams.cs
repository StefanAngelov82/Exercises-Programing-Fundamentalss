using Football_Team_Generator.Models;
using Football_Team_Generator.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Repository
{
    public class RepositoryTeams : IRepository<FootballTeam>
    {
        private List<FootballTeam> _teams;

        public RepositoryTeams()
        {
            _teams = new List<FootballTeam>();
        }

        public IReadOnlyCollection<FootballTeam> TeamCollection => _teams.AsReadOnly();

        public void AddToRepository(FootballTeam team) 
            => _teams.Add(team);

        public FootballTeam? GetFromRepository(string name)
            => _teams.FirstOrDefault(X =>X.Name == name);
    }
}
