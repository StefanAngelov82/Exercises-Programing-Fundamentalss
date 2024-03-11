using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interface
{
    public interface Vehicle
    {
         double FuelQuantity { get; }
         double FuelConsumption { get; }
         double TankCapacity { get; }        

        string Drive(double distance, bool IsEmpty = false);
        
        void Refuel(double refuelQuantity);

    }
}
