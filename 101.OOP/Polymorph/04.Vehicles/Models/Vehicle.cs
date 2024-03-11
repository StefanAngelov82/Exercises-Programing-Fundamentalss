using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interface;

namespace Vehicles.Models
{
    public abstract class Vehicle : Interface.Vehicle
    {        
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        protected double additionalConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double additionalConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            this.additionalConsumption = additionalConsumption;
        }

        public double FuelQuantity
		{
			get { return fuelQuantity; }
			protected set { fuelQuantity = value; }
		}        

        public double FuelConsumption 
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }

            protected set
            {
                if (value < FuelQuantity )
                {
                    fuelQuantity = 0;
                }

                tankCapacity = value; 
            }
        }

        public virtual string Drive(double distance)
        {
            double consumedFuel = distance * (FuelConsumption + additionalConsumption);

            if (FuelQuantity >= consumedFuel)
            {
                FuelQuantity -= consumedFuel;

                 return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                //return $"{GetType().Name} needs refueling";
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
        }

        public virtual string Drive(double distance, bool IsEmpty = false )
        {
            if (IsEmpty) additionalConsumption = 0;
            return Drive(distance);
        }


        public virtual void Refuel(double refuelQuantity)
        {
            if (refuelQuantity <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (TankCapacity < FuelQuantity + refuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {refuelQuantity} fuel in the tank");
            }

            FuelQuantity += refuelQuantity;
        }

        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:F2}";
    }
}
