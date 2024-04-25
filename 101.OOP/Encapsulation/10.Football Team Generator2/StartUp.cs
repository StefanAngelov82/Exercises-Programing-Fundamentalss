using Football_Team_Generator.Core;
using Football_Team_Generator.Core.Interface;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}