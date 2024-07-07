using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Repository.Interface
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> TeamCollection { get; }

        public void AddToRepository(T team);
        public T GetFromRepository(string name);
    }
}
