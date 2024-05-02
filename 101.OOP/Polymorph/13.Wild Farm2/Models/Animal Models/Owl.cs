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
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override void Eat(IFood? food)
        {
            if (food is Meat)
            {
                Weight += GlobalConstants.Owl_Multiplier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }


        public override string ProducingSound()
            => "Hoot Hoot";

    }
}
