using BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public abstract class Human : IBuyer
    {
        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
       
    }
}
