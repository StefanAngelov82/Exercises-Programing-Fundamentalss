using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.models
{
    public class Player
    {
		private const string ExceptionMassage2 = "A name should not be empty.";
        private const string ExceptionMassage = "{0} should be between 0 and 100.";
        private const int MaxValue = 100;
        private const int MinValue = 0;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
		{
			get { return name; }

			private set 
			{ 
				if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMassage2);
				}

				name = value; 
			}
		}

        public int Endurance
        {
            get { return endurance; }

            private set
            {
                if (CheckStatValueInRange(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMassage, nameof(Endurance)));
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }

            private set
            {
                if (CheckStatValueInRange(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMassage, nameof(Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }

            private set
            {
                if (CheckStatValueInRange(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMassage, nameof(Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }

            private set
            {
                if (CheckStatValueInRange(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMassage, nameof(Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }

            private set
            {
                if (CheckStatValueInRange(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMassage, nameof(Shooting)));
                }

                shooting = value;
            }
        }

        public double SkillLevel
        {
            get => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        }


        private bool CheckStatValueInRange(int value)
        {

            return value < MinValue || value > MaxValue;
        }

    }
}
