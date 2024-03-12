using Raiding.Core;
using Raiding.Core.Interface;
using Raiding.Factories;
using Raiding.Factories.Interface;
using Raiding.IO;
using Raiding.IO.Interface;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroesFactory heroesFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroesFactory);
            engine.Run();
        }
    }
}