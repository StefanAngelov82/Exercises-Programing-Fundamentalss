using Pizza_Calorie_2.Core.Interface;
using Pizza_Calorie_2.Factories;
using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Core
{
    public class Engine : IEngine
    {
        public readonly IDoughFactory _doughFactory; 
        public readonly IToppingFactory _toppingFactory;
        public readonly IPizzaFactory _pizzaFactory;

        public Engine(IDoughFactory doughFactory, IToppingFactory toppingFactory, IPizzaFactory pizzaFactory)
        {
            _doughFactory = doughFactory;
            _toppingFactory = toppingFactory;
            _pizzaFactory = pizzaFactory;
        }

        public void Run()
        {
            Dough dough;
            Topping currentTopping;
            Pizza pizza = null;

            string? input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string ingredient = inputArg[0];

                try
                {
                    switch (ingredient)
                    {
                        case "Dough":
                            dough = DoughCreation(inputArg);

                            if (pizza == null)
                                throw new ArgumentException("Pizza is not created!");

                            pizza.AddDoughOnPizza(dough);
                            break;

                        case "Topping":
                            currentTopping = ToppingCreation(inputArg);

                            if (pizza == null)
                                throw new ArgumentException("Pizza is not created!");

                            pizza.AddToppingOnPizza(currentTopping);
                            break;

                        case "Pizza":
                            if (pizza != null)
                                throw new ArgumentException("Previous pizza is not done yet");

                            pizza = PizzaCreation(inputArg);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }               
            }

            Console.WriteLine(pizza.ToString());
        }

        private Pizza PizzaCreation(string[] inputArg)
        {
           string name = inputArg[0];

            return _pizzaFactory.PizzaCreator(name);
        }

        private Topping ToppingCreation(string[] inputArg)
        {
            string toppingType = inputArg[1];
            double weight = double.Parse(inputArg[2]);

            return _toppingFactory.ToppingCreator(toppingType, weight);
        }

        private Dough DoughCreation(string[] inputArg)
        {
            string doughType = inputArg[1];
            string doughBakingTechnique = inputArg[2];
            double weight = double.Parse(inputArg[3]);

            return _doughFactory.Creator(doughType, doughBakingTechnique, weight);
        }
    }
}
