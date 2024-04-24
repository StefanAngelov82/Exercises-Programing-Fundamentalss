using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Factories
{
    public class PizzaFactory : IPizzaFactory
    {
        public Pizza PizzaCreator(string name)
        {
           return new Pizza(name);
        }
    }
}
