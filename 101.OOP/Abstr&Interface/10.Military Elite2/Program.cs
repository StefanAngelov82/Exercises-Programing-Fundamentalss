using Military_Elite2.Core;
using Military_Elite2.Core.Interface;
using System;

namespace Military_Elite2
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
