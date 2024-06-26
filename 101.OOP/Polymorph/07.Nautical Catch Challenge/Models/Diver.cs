﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catches;
        private double competitionPoints;
        private bool hasHealthIssue;

        protected Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.catches = new List<string>();
            this.competitionPoints = 0;
            this.hasHealthIssue = false;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);

                name = value; 
            }
        }        

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set 
            {
                if (value <= 0)
                {
                    hasHealthIssue = true;
                    value = 0;
                }               
                
                oxygenLevel = value; 
            }
        }       

        public IReadOnlyCollection<string> Catch 
        { get => catches.AsReadOnly() ; }       

        public double CompetitionPoints
        { get {
                competitionPoints = Math.Ceiling(competitionPoints * 10) / 10;
                return competitionPoints; 
            } 
        }       

        public bool HasHealthIssues ///
        { get { return hasHealthIssue; } }        

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catches.Add(fish.Name);
            competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();
        

        public void UpdateHealthStatus()
        {
            hasHealthIssue = !hasHealthIssue;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catches.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
