using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string liveRegion, string breed) 
            : base(name, weight, liveRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * GlobalConstants.GlobalConstants.TigerAdditive;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string Sound()
            => "ROAR!!!";
    }
}
