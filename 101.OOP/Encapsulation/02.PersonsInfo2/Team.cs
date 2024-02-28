using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
		private string name;
        private List<Person> firsTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
			this.firsTeam = new List<Person>(); 
            this.reserveTeam = new List<Person>(); 
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}		

		public IReadOnlyCollection<Person> FirstTeam
		{
			get { return firsTeam.AsReadOnly(); }			
		}		

		public IReadOnlyCollection<Person> ReserveTeam
        {
			get { return reserveTeam.AsReadOnly(); }			
		}

		public void AddPlayer(Person person)
		{
            if (person.Age < 40)
            {
                firsTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"First team has {firsTeam.Count} players.");
            sb.AppendLine($"Reserve team has {reserveTeam.Count} players.");

            return sb.ToString().Trim();
        }

    }
}
