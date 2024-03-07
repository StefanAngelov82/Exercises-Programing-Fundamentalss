using BorderControl.Core;
using BorderControl.Core.Interface;
using System.Net.Http.Headers;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IEngine engine = new Engine();
            IEngine engine = new Engine2();
            engine.Run();
        }
    }
}