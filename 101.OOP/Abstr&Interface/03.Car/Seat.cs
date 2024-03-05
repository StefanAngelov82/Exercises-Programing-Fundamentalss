using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Seat : ICar
    {
        public Seat(string model, string color) : base(model, color)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.color} {GetType().Name} {this.model}");
            sb.AppendLine($"{this.Start()}");
            sb.AppendLine($"{this.End()}");

            return $"{sb.ToString().Trim()}";
        }
    }
}
