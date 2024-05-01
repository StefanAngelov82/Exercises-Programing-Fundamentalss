using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm2.Models.Animal_Models.Abstract_Models
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, int foodEaten, string livingRegion, string bread)
            : base(name, weight, foodEaten, livingRegion)
        {
           Breed = bread;
        }
        public string Breed { get; }
    }
}
