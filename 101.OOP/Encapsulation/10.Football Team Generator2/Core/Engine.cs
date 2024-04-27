using Football_Team_Generator.Core.Interface;
using Football_Team_Generator.IO;
using Football_Team_Generator.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Core
{
    public class Engine : IEngine
    {
        private IReader _reader;
        private IWriter _writer;
        private IController _controller;

        public Engine()
        {
            _controller = new Controller();
            _reader = new Reader();
            _writer = new Writer();
        }

        public void Run()
        {
            String? input = String.Empty;

            while ((input = _reader.Read()) != "END")
            {
                string[] inputArg = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArg[0];

                try
                {
                    ExecuteCommand(inputArg, command);
                }
                catch (Exception ex)
                {
                    _writer.Write(ex.Message);
                }
            }
        }

        private void ExecuteCommand(string[] inputArg, string command)
        {
            switch (command)
            {
                case "Team":
                    TeamCreation(inputArg);
                    break;

                case "Add":
                    PrayerContract(inputArg);
                    break;

                case "Remove":
                    DelistingPlayer(inputArg);
                    break;

                case "Rating":
                    GenerateRequiredData(inputArg);
                    break;

                default:
                    break;
            }
        }

        private void GenerateRequiredData(string[] inputArg)
        {
            string teamName = inputArg[1];

            _writer.Write(_controller.GenerateStatistics(teamName));
        }

        private void DelistingPlayer(string[] inputArg)
        {
            string teamName = inputArg[1];
            string playerName = inputArg[2];   
            
            _writer.Write(_controller.RemovePlayerOfTeam(teamName, playerName));
        }

        private void PrayerContract(string[] inputArg)
        {
            string teamName = inputArg[1];
            string playerName = inputArg[2];
            int endurance = int.Parse(inputArg[3]);
            int sprint = int.Parse(inputArg[4]);
            int dribble = int.Parse(inputArg[5]);
            int passing = int.Parse(inputArg[6]);
            int shooting = int.Parse(inputArg[7]);

            _writer.Write(_controller
                    .AddPlayerToTeam(teamName, playerName, endurance, sprint, dribble, passing, shooting));
        }

        private void TeamCreation(string[] inputArg)
        {
            string teamName = inputArg[1];

            _writer.Write(_controller
                .AddTeamToRepository(teamName));
        }
    }
}
