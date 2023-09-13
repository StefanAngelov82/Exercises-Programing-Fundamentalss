using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni_Beer_Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , Dictionary<string, int>> teamsData = new Dictionary<string , Dictionary<string, int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "stop the game")
            {
                string[] inputArg = input.Split('|');
                string teamName = inputArg[1];
                string playerName = inputArg[0];
                int playerScore = int.Parse(inputArg[2]);

                if (!teamsData.ContainsKey(teamName)) 
                {
                    teamsData[teamName] = new Dictionary<string, int>();
                }

                if (teamsData[teamName].Count < 3)
                {
                    teamsData[teamName].Add(playerName, playerScore);
                }
            }

            Dictionary<string, int> Scoredata = new Dictionary<string, int>();

            foreach (var team in teamsData.Keys)
            {
                if (teamsData[team].Count < 3) continue;

                int totalScore = teamsData[team].Values.Sum();

                Scoredata.Add(team, totalScore);
            }

            Scoredata = Scoredata.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            

            int counter = 1;

            foreach (var team in Scoredata.Keys)
            {                
                Console.WriteLine($" {counter}. {team}; Players:");

                foreach (var kvp in teamsData[team].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{kvp.Key}: {kvp.Value}");
                }
               
                counter++;
            }
            


        }
    }
}
