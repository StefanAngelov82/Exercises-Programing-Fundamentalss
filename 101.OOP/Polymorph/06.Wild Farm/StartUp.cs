using Wild_Farm.Core;
using Wild_Farm.Factories;
using Wild_Farm.Factories.Interface;
using Wild_Farm.IO;
using Wild_Farm.IO.Interface;

namespace Wild_Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();
            

            Engine engine = new Engine(reader, writer, animalFactory, foodFactory);
            engine.Run();
        }
    }
}