namespace Football_Team_Generator.Models
{
    using Utilities;
    public class Stats
    {
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
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
    }
}
