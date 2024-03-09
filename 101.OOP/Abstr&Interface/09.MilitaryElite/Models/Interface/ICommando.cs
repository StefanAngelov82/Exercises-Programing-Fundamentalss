using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interface
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyList<IMission> Tasks { get; }

        public void AddMissionInTasks(IMission mission);
    }
}
