using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            Weight += food.Quantity * GlobalConstants.GlobalConstants.HenWightAdditive;
            FoodEaten += food.Quantity;
        }

        public override string Sound()
            => "Cluck";
    }
}
