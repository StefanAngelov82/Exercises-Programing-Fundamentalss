using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interface;
using Vehicles.Models;
using Vehicles.Models.Interface;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Models.Interface.Vehicle Creator(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);

                case "Bus":               
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);

                default:
                    throw new ArgumentException("Invalid vehicle type");
                
            }
        }
    }
}
