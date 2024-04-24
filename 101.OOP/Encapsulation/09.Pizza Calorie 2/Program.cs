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
            
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}