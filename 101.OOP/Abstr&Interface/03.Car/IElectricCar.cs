using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public abstract class IElectricCar : ICar
    {
        protected int battery;

        protected IElectricCar(string model, string color, int battery) : base(model, color)
        {
            this.battery = battery;
        }
    }
}
