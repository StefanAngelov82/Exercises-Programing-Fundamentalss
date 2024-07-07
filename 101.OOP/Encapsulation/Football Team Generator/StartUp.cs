using Football_Team_Generator.Core;
using Football_Team_Generator.Core.Interface;
using Football_Team_Generator.Models;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //IEngine engine = new Engine();
            //engine.Run();

            Players players = new Players("H", 1, 1, 1, 1, 1);
            Console.WriteLine(players.PlayerStats);
            Console.WriteLine(players.OverallSkill);

           
        }
    }
}