using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Animal_Models.Abstract_Models;

namespace Wild_Farm2.Models.Animal_Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string bread) 
            : base(name, weight, foodEaten, livingRegion, bread)
        {
        }

        public override string ProducingSound()
            => "ROAR!!!";
    }
}
