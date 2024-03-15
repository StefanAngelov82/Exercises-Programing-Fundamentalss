﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string liveRegion, string breed)
            : base(name, weight, liveRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
