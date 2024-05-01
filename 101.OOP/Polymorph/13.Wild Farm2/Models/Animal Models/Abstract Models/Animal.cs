using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm2.Models.Animal_Models.Abstract_Models
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }

        public abstract string ProducingSound(); 
    }
}
