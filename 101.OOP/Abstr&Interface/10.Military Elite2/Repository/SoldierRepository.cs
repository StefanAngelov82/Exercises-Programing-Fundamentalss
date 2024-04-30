using Military_Elite2.Models.Interface;
using Military_Elite2.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_Elite2.Repository
{
    public class SoldierRepository : IRepository<ISoldier>
    {
        private List<ISoldier> soldiers;

        public SoldierRepository()
        {
            this.soldiers = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> SoldiersData => soldiers.AsReadOnly();

        public void Add(ISoldier soldier)
            =>  soldiers.Add(soldier);        

        public bool Exist(int id)
            =>  soldiers.Any(x => x.Id == id);       

        public ISoldier GetSoldier(int id)
            => soldiers.FirstOrDefault(x => x.Id == id);
    }
}
