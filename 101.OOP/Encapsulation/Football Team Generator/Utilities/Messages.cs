using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Utilities
{
    public static class Messages
    {

        public const string RemovingPlayerFromTeamSuccesses = "Player was removed from team";
        public const string RemovingPlayerFromTeamFail = "$Player with name {0} is not present in this team";

        public const string AddingPlayerInTeam = "Player {0} is add to the team!";
    }
}
