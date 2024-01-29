using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person? other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result != 0)
            {
                return result;
            }

            return this.Age.CompareTo(other.Age);   
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person)
            {
                Person other = (Person)obj;

                return other.Name== this.Name &&
                       other.Age ==this.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = this.Name.GetHashCode() + this.Age.GetHashCode();

            return hashCode;
        }

    }

    
}
