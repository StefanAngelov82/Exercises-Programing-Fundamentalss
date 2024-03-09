using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> tasks;
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            tasks = new List<IMission>();
        }

        public IReadOnlyList<IMission> Tasks => tasks.AsReadOnly();

        public void AddMissionInTasks(IMission mission)
        {
            tasks.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var task in Tasks)
            {
                sb.AppendLine($"  {task.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
