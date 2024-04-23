using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Factories
{
    public class DoughFactory : IDoughFactory
    {
        public Dough Creator(string doughType, string doughBakingTechnique, double weight)
        {
            return new Dough(doughType, doughBakingTechnique, weight);
        }
    }
}
