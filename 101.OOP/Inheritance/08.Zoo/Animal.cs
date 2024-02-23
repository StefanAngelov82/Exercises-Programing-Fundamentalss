using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public abstract class Animal
    {
        
        public Animal(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }
}
