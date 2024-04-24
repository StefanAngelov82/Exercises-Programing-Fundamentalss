﻿using Pizza_Calorie_2.Core.Interface;
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
        private IController _controller;

        public Engine()
        {
            _controller = new Controller();
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
                            dough = _controller.DoughCreation(inputArg);

                            if (pizza == null)
                                throw new ArgumentException("Pizza is not created!");

                            pizza.AddDoughOnPizza(dough);
                            break;

                        case "Topping":
                            currentTopping = _controller.ToppingCreation(inputArg);

                            if (pizza == null)
                                throw new ArgumentException("Pizza is not created!");

                            pizza.AddToppingOnPizza(currentTopping);
                            break;

                        case "Pizza":
                            if (pizza != null)
                                throw new ArgumentException("Previous pizza is not done yet");

                            pizza = _controller.PizzaCreation(inputArg);
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
    }
}
