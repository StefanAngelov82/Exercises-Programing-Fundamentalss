using Pizza_Calorie_2.Core.Interface;
using Pizza_Calorie_2.Factories;
using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Core
{
    public class Controller : IController
    {
        public readonly IDoughFactory _doughFactory;
        public readonly IToppingFactory _toppingFactory;
        public readonly IPizzaFactory _pizzaFactory;

        public Controller()
        {
            _doughFactory = new DoughFactory();
            _toppingFactory = new ToppingFactory();
            _pizzaFactory = new PizzaFactory();
        }


        public Dough DoughCreation(string[] inputArg)
        {
            string doughType = inputArg[1];
            string doughBakingTechnique = inputArg[2];
            double weight = double.Parse(inputArg[3]);

            return _doughFactory.Creator(doughType, doughBakingTechnique, weight);
        }

        public Pizza PizzaCreation(string[] inputArg)
        {
            string name = inputArg[1];

            return _pizzaFactory.PizzaCreator(name);
        }

        public Topping ToppingCreation(string[] inputArg)
        {

            string toppingType = inputArg[1];
            double weight = double.Parse(inputArg[2]);

            return _toppingFactory.ToppingCreator(toppingType, weight);
        }

    }
}
