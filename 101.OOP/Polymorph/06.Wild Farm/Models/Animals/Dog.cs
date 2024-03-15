using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string liveRegion)
            : base(name, weight, liveRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * GlobalConstants.GlobalConstants.DogWhtAdditive;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string Sound()
            => "Woof!";
    }
}
