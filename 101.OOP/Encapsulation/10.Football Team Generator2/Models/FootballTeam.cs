using Football_Team_Generator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Models
{
    public class FootballTeam
    {
		private string _name;
        private List<Players> _players;

        public FootballTeam(string name)
        {
            Name = name;
            _players = new List<Players>();
        }

		public string Name
        {
            get => _name;
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.WrongEnteredName);

                _name = value; 
            }
        }

        public int Rating => (int)_players.Average(x => x.OverallSkill);

        public string AddPlayer(Players player)
        {
            _players.Add(player);

            return string.Format(Messages.AddingPlayerInTeam, player.Name);
        }
              

        public string RemovePlayer(Players player)
        {
            if (_players.Remove(player))
                return Messages.RemovingPlayerFromTeamSuccesses;

            return string.Format(Messages.RemovingPlayerFromTeamFail, player.Name);                
        }           
        
    }
}
