using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string liveRegion) 
            : base(name, weight)
        {
            LivingRegion = liveRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
