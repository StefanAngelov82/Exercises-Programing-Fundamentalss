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

        public const string AddingTeamInRepository = "Team {0} was successfully added in {1}";
        public const string UnsuccessfulAddingTeamInRepository = "Team with name {0}, already exist in {1}";        
        
        public const string TeamDoNotExist = "Team with name {0} not exist in {1}";
        public const string PlayerIsInTeam = "This player is already part of the team";
        public const string PlayerSignContract = "Player {0} successfully sing contract with team - {1}";
        public const string PlayerIsNotInTeam = "This player is not part of the team";
    }
}
