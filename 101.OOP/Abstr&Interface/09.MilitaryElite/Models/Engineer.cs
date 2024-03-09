using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> work;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            work = new List<IRepair>();
        }

        public IReadOnlyList<IRepair> Work => work.AsReadOnly();

        public void AddRepairInWork(IRepair repair)
        {
            work.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in Work)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
