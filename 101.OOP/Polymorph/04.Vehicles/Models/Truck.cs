using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {        
        private const double TankLose = 0.95;
        private const double AdditionalConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, AdditionalConsumption)
        {
        }

        public override void Refuel(double refuelQuantity)
        {
            if (refuelQuantity <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (TankCapacity < FuelQuantity + refuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {refuelQuantity} fuel in the tank");
            }

            FuelQuantity += refuelQuantity * TankLose;
        }
    }
}
