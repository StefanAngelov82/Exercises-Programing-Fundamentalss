using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;

namespace Person
{
    public class Person
    {       
        private int age;


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Name { get; set; }
        public virtual int Age 
        {
            get { return age; }
            set 
            { 
                if (value > 0) 
                    age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {age}";
        }


    }
}
