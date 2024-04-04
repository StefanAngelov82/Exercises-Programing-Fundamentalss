using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {

        private string name;
        private int pointsEarned = 0;
        private List<IPlayer> players;

        public Team(string name)
        {
            this.name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value; 
            }
        }       

        public int PointsEarned
        {
            get { return  pointsEarned; }
            private set 
            { 
                pointsEarned = value;
            }
        }        

        public double OverallRating
        {
            get 
            {
                if (Players.Count == 0)
                    return 0;

                else                   
                    return  Math.Round((Players.Average(x => x.Rating)), 2);
            }           
        }        

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer player = players.FirstOrDefault(x =>x is Goalkeeper);
            player.IncreaseRating();           
        }

        public void Lose()
        {
            foreach (var item in players)
            {
                item.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
           players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;

            foreach (var item in players)
            {
                item.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");

            if (players.Count == 0)
            {
                sb.AppendLine("--Players: none");
            }
            else
            {
                string[] names = players.Select(x => x.Name).ToArray();
                sb.AppendLine($"--Players:  {string.Join(", ", names)}");
            }          

            return sb.ToString().Trim();
        }
    }
}
