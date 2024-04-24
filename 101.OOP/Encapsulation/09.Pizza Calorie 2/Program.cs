using Pizza_Calorie_2.Core;
using Pizza_Calorie_2.Core.Interface;
using Pizza_Calorie_2.Factories;
using Pizza_Calorie_2.Factories.Interface;
using Pizza_Calorie_2.Models;

namespace Pizza_Calorie_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDoughFactory doughFactory = new DoughFactory();
            IToppingFactory toppingFactory = new ToppingFactory();
            IPizzaFactory pizzaFactory = new PizzaFactory();
            IEngine engine = new Engine(doughFactory, toppingFactory, pizzaFactory);

            engine.Run();
        }
    }
}