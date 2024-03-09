using MilitaryElite.Core;
using MilitaryElite.Core.Interface;
using MilitaryElite.Models;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interface;

namespace MilitaryElite
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