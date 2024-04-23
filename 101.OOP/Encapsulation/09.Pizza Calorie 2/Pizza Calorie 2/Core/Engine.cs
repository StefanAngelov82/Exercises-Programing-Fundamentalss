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
        public readonly IDoughFactory _factory;

        private Dough dough;

        public Engine(IDoughFactory factory)
        {
            _factory = factory;
        }

        public void Run()
        {
            string input = String.Empty;

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
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }                
            }
        }

        private Dough DoughCreation(string[] inputArg)
        {
            string doughType = inputArg[1];
            string doughBakingTechnique = inputArg[2];
            double weight = double.Parse(inputArg[3]);

            return _factory.Creator(doughType, doughBakingTechnique, weight);
        }
    }
}
