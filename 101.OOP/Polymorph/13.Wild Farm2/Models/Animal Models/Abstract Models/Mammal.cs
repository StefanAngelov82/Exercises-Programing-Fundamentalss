using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm2.Models.Animal_Models.Abstract_Models
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; }
       
    }
}
