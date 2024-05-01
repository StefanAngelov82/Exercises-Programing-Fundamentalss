using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Animal_Models.Abstract_Models;

namespace Wild_Farm2.Models.Animal_Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string ProducingSound()
            => "Cluck";
    }
}
