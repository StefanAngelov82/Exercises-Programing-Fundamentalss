using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
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
            throw new NotImplementedException();
        }

        public string CompetitionStatistics()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string HealthRecovery()
        {
            throw new NotImplementedException();
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

            return string.Format(OutputMessages.FishCreated, fishType);
        }
    }
}
