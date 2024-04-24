using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Factories
{
    public class ToppingFactory : IToppingFactory
    {
        public Topping ToppingCreator(string toppingType, double weight)
        {
            return new Topping(toppingType, weight);
        }
    }
}
