using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.GlobalConstants;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {        
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }  

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * GlobalConstants.GlobalConstants.OwlWightAdditive;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }                     

        public override string Sound()
            => "Hoot Hoot";
        
    }
}
