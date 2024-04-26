using Football_Team_Generator.Core.Interface;
using Football_Team_Generator.Models;
using Football_Team_Generator.Repository;
using Football_Team_Generator.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Core
{
    public class Controller : IController
    {
        private IRepository<FootballTeam> _teamsRepository;

        public Controller()
        {
            _teamsRepository = new RepositoryTeams();
        }
    }   
}
