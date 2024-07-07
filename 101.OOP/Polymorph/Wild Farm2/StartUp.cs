using Wild_Farm2.Core;

namespace Wild_Farm2
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