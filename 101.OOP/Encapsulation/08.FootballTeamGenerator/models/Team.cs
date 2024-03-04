using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.models
{
    public class Team
    {
        private const string ExceptionMassage = "A name should not be empty.";
        private const string ExceptionMassage1 = "Player {0} is not in {1} team.";

        private string name;
        private List<Player> team;

        public Team(string name)
        {
            this.name = name;
            this.team = new List<Player>();
        }

        public string Name	
		{
			get { return name; }

			private set 
			{
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMassage);
                }

                name = value;
			}
		}        
        public double Rating 
        {
            get
            {  
               if (team.Count > 0) 
                    return  Math.Round(team.Average(x => x.SkillLevel));

               return 0;
            } 
        }

        public void AddPlayer(Player player)
        {
            this.team.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player? current = team.FirstOrDefault(x => x.Name == playerName);

            if (current == null)
            {
                throw new ArgumentException(string.Format(ExceptionMassage1, playerName, this.Name));
            }

            team.Remove(current);
        }

    }
}
