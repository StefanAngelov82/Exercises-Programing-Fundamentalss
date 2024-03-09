using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> team;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            team = new List<IPrivate>();
        }

        public IReadOnlyList<IPrivate> Team 
        {
            get { return team.AsReadOnly(); }            
        }
       
        public void AddInTeam(IPrivate current)
        {
            team.Add(current);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var soldier in Team)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return  sb.ToString().Trim();
        }



    }    
}
