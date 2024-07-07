using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Animal_Models;

namespace Wild_Farm2.Repository.Interface
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Animals { get; }

        public void AddAnimal(IAnimal animal);
    }
}
