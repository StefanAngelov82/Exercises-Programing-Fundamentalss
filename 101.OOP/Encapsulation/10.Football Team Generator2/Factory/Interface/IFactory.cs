using Football_Team_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Factory.Interface
{
    public interface IFactory
    {
        public FootballTeam TeamCreator(string name);       

        public Players PlayerCreator(string name, int endurance, int sprint, int dribble, int passing, int shooting);
    }
}
