﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public  abstract class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters { get; private set; }
    }
}
