﻿using Raiding.Factories.Interface;
using Raiding.Models;
using Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroesFactory
    {
        
        public IHero Creator(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");

            }
        }
    }
}
