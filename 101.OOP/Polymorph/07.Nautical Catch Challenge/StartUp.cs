namespace NauticalCatchChallenge
{
    using NauticalCatchChallenge.Core;
    using NauticalCatchChallenge.Core.Contracts;
    using NauticalCatchChallenge.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();            
        }
    }
}