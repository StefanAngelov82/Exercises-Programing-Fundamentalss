using Football_Team_Generator.Utilities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Football_Team_Generator.Models
{
    public class Players
    {
        private string _name;
        private Stats _stats;        

        public Players(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            _stats = Stats.CreateStats(endurance, sprint, dribble, passing, shooting);            
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.WrongEnteredName);

                _name = value;
            }
        }
        public double OverallSkill => _stats.OverallStats(); 
        
        public string PlayerStats => $"Player {Name} has following Stats: {_stats}";

        public override bool Equals(object? obj)
        {
            if (obj is Players)
            {
                Players other = (Players)obj;

                return Name == other.Name;
            }

            return false;
        }
        private class Stats
        {
            private int _endurance;
            private int _sprint;
            private int _dribble;
            private int _passing;
            private int _shooting;

            private Stats(int endurance, int sprint, int dribble, int passing, int shooting)
            {
                Endurance = endurance;
                Sprint = sprint;
                Dribble = dribble;
                Passing = passing;
                Shooting = shooting;
            }

            public int Endurance
            {
                get => _endurance;
                private set
                {
                    if (CheckValue(value))
                        throw new ArgumentOutOfRangeException(string.Format(
                            ExceptionMessages.WrongStatsValues, nameof(Endurance)));

                    _endurance = value;
                }
            }

            public int Sprint
            {
                get => _sprint;
                private set
                {
                    if (CheckValue(value))
                        throw new ArgumentOutOfRangeException(string.Format(
                            ExceptionMessages.WrongStatsValues, nameof(Sprint)));

                    _sprint = value;
                }
            }
            public int Dribble
            {
                get => _dribble;
                private set
                {
                    if (CheckValue(value))
                        throw new ArgumentOutOfRangeException(string.Format(
                            ExceptionMessages.WrongStatsValues, nameof(Dribble)));

                    _dribble = value;
                }
            }

            public int Passing
            {
                get => _passing;
                private set
                {
                    if (CheckValue(value))
                        throw new ArgumentOutOfRangeException(string.Format(
                            ExceptionMessages.WrongStatsValues, nameof(Passing)));

                    _passing = value;
                }
            }

            public int Shooting
            {
                get => _shooting;
                private set
                {
                    if (CheckValue(value))
                        throw new ArgumentOutOfRangeException(string.Format(
                            ExceptionMessages.WrongStatsValues, nameof(Shooting)));

                    _shooting = value;
                }
            }

            private bool CheckValue(int value)
                => value < 0 || value > 100;

            public double OverallStats()
                => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.00;

            public override string ToString()            
                => $"(Endurance - {Endurance}, Sprint {Sprint}, Dribble {Dribble}, Passing {Passing}, Shooting {Shooting})";

            public static Stats CreateStats(int endurance, int sprint, int dribble, int passing, int shooting)
            {
                return new Stats(endurance, sprint, dribble, passing, shooting);
            }
        }

    }
}
