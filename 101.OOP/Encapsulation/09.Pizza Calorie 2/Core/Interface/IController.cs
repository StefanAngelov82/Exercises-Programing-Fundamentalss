using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Core.Interface
{
    public interface IController
    {
        public Pizza PizzaCreation(string[] inputArg);
        public Topping ToppingCreation(string[] inputArg);
        public Dough DoughCreation(string[] inputArg);
    }
}
