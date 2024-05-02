using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.GlobalConst;
using Wild_Farm2.Models.Animal_Models.Abstract_Models;
using Wild_Farm2.Models.Food_Models;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Models.Animal_Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string bread) 
            : base(name, weight, livingRegion, bread)
        {
        }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                Weight = GlobalConstants.Cat_Multiplier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        public override string ProducingSound()
            => "Meow";
    }
}
