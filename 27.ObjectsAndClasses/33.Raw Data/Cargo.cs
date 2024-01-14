using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type   { get; set; }
        public int Weight { get; set; }
    }
}
