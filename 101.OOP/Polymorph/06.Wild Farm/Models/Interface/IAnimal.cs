using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm.Models.Interface
{
    public interface IAnimal
    {
        public string Name { get;}
        public double Weight { get;}
        public int FoodEaten { get;}

        string Sound();

        void Eat(IFood food);       
        
    }
}
