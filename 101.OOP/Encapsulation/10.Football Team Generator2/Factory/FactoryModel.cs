using Football_Team_Generator.Factory.Interface;
using Football_Team_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Factory
{
    public class FactoryModel : IFactory
    {
        public Players PlayerCreator(string name, int endurance, int sprint, int dribble, int passing, int shooting)
            => new Players(name, endurance, sprint, dribble, passing, shooting);

        public FootballTeam TeamCreator(string name)
            => new FootballTeam(name);
    }
}
