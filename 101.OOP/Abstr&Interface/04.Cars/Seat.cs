using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set ; }
        public string Color { get ; set ; }

        public string End()
            => "Breaaak!";

        public string Start()
            => "Engine start";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {GetType().Name} {this.Model}");
            sb.AppendLine($"{this.Start()}");
            sb.AppendLine($"{this.End()}");

            return $"{sb.ToString().Trim()}";
        }
    }
}
