using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Models.Animal_Models.Abstract_Models
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set}

        public abstract string ProducingSound(); 

        public abstract void Eat(IFood food);

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
