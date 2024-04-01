using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;
        private string[] diversTypes = new string[] { typeof(ScubaDiver).Name, typeof(FreeDiver).Name };
        private string[] fishesTypes = new string[] { nameof(DeepSeaFish), nameof(PredatoryFish), nameof(ReefFish) };

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);

            if (fish.GetModel(fishName) == null)
                return string.Format(OutputMessages.FishNotAllowed, fishName);

            IDiver currentDiver = divers.GetModel(diverName);

            if (currentDiver.HasHealthIssues == true)
                return string.Format(OutputMessages.DiverHealthCheck, diverName);

            IFish currentFish = fish.GetModel(fishName);

            if ((currentDiver.OxygenLevel < currentFish.TimeToCatch) || (currentDiver.OxygenLevel == currentFish.TimeToCatch && !isLucky))
            {
                currentDiver.Miss(currentFish.TimeToCatch);              

                return string.Format(OutputMessages.DiverMisses,diverName, fishName);
            }            
            else
            {
                currentDiver.Hit(currentFish);              

                return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }            
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            List<IDiver> reportDivers = divers.Models.Where(x => !x.HasHealthIssues).ToList();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver diver in reportDivers.OrderByDescending(x =>x.CompetitionPoints).ThenByDescending(x =>x.Catch.Count).ThenBy(x =>x.Name))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
       

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diversTypes.Contains(diverType))
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);

            if (divers.GetModel(diverName) != null)           
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);

            if (diverType == typeof(FreeDiver).Name)                         
                divers.AddModel(new FreeDiver(diverName));
           
            else                         
                divers.AddModel(new ScubaDiver(diverName));

            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            IDiver diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var currentFish in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(currentFish).ToString());
            }

            return sb.ToString().Trim();
        }
        

        public string HealthRecovery()
        {
            int count = 0;

            foreach (var diver in divers.Models)
            {
                if (diver.HasHealthIssues == true)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    count++;
                }
            }

            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishesTypes.Contains(fishType))           
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            

            if (fish.GetModel(fishName) != null)            
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);


            if (fishType == nameof(ReefFish))
                fish.AddModel(new ReefFish(fishName, points));

            else if (fishType == nameof(DeepSeaFish))
                fish.AddModel(new DeepSeaFish(fishName, points));

            else
                fish.AddModel(new PredatoryFish(fishName, points));

            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
