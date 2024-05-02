using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.GlobalConst;
using Wild_Farm2.Models.Animal_Models.Abstract_Models;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Models.Animal_Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood? food)
        {
            Weight += GlobalConstants.Hen_Multiplier * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ProducingSound()
            => "Cluck";
    }
}
