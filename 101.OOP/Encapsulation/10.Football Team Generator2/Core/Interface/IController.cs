using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Core.Interface
{
    public interface IController
    {
        string AddTeamToRepository(string teamName);

        string AddPlayerToTeam( 
            string teamName, string playerName, int endurance, 
            int sprint, int dribble, int passing, int shooting);

        string RemovePlayerOfTeam(string teamName, string playerName);

        string GenerateStatistics(string teamName);
    }
}
