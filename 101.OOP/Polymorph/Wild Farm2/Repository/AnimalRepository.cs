using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Animal_Models;
using Wild_Farm2.Repository.Interface;

namespace Wild_Farm2.Repository
{
    public class AnimalRepository : IRepository<IAnimal>
    {
        private List<IAnimal> animals;

        public AnimalRepository()
        {
            this.animals = new List<IAnimal>();;
        }

        public IReadOnlyCollection<IAnimal> Animals => animals.AsReadOnly();

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }
    }
}
