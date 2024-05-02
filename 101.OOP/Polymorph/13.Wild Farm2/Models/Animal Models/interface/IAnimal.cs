using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Models.Animal_Models
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public abstract string ProducingSound();
        public abstract void Eat(IFood? food);
    }
}
