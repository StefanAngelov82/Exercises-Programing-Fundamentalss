using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams = new List<ITeam>();

        public IReadOnlyCollection<ITeam> Models => teams.AsReadOnly();

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return teams.Any(x => x.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            ITeam team =  teams.FirstOrDefault(x => x.Name == name);
            if (team == null)
            {
                return false;
            }
            return teams.Remove(team);

        }
    }
}
