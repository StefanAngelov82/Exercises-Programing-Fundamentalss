using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interface;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AdditionalConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, double additionalConsumption = 0) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, AdditionalConsumption)
        {
            
        }
       
    }
}
