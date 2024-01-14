using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Tires
    {
        public Tires(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age  { get; set; }
        public double Pressure { get; set; }
    }
}
