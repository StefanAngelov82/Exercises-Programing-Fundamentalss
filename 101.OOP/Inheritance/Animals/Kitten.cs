﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string Sound = "Meow";
        private const string KittenGender = "Female";
        public Kitten(string name, int age) 
            : base(name, age, KittenGender)
        {
        }

        public override string ProduceSound() 
            => Sound;
        
    }
}
