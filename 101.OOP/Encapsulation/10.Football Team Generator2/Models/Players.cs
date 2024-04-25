using Football_Team_Generator.Utilities;
using System;
using System.Collections.Generic;

namespace Football_Team_Generator.Models
{
    public class Players
    {
        private string _name;
        private Stats _stats;        

        public Players(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            _stats = new Stats(endurance, sprint, dribble, passing, shooting);
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

        public override bool Equals(object? obj)
        {
            if (obj is Players)
            {
                Players other = (Players)obj;

                return Name == other.Name;
            }

            return false;
        }

    }
}
