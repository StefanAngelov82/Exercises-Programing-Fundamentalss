using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Factories.Interface
{
    public interface IPizzaFactory
    {
        Pizza PizzaCreator(string name);
        
    }
}
