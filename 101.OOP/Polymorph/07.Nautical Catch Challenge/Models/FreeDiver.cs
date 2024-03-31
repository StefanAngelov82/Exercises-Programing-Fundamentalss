﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int BASE_OXYGEN_LEVEL = 120;
        public FreeDiver(string name) : base(name,BASE_OXYGEN_LEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {            
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero); 
        }

        public override void RenewOxy()
        {
            OxygenLevel = BASE_OXYGEN_LEVEL;
        }
    }
}
