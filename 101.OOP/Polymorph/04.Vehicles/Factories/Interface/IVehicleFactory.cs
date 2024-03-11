using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interface;

namespace Vehicles.Factories.Interface
{
    public interface IVehicleFactory
    {
        Vehicle Creator(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
