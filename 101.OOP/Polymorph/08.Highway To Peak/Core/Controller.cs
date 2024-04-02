using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)            
                return String.Format(OutputMessages.PeakAlreadyAdded, name);


            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
                return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            
            peaks.Add(new Peak(name, elevation, difficultyLevel));

            return String.Format(OutputMessages.PeakIsAllowed, name , nameof(PeakRepository));
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);
            IPeak peak = peaks.Get(peakName);

            if (climber == null)
                return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);

            if (peak == null)
                return String.Format(OutputMessages.PeakIsNotAllowed, peakName);

            if (!baseCamp.Residents.Contains(climberName))
                return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
                return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);

            return "";
        }

        public string BaseCampReport()
        {
            throw new NotImplementedException();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            throw new NotImplementedException();
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
                return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));

            IClimber climber;

            if (isOxygenUsed)
                climber = new OxygenClimber(name);

            else
                climber = new NaturalClimber(name);

            baseCamp.ArriveAtCamp(name);
            climbers.Add(climber);

            return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
