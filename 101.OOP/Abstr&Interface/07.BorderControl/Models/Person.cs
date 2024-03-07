using BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Person : Iidentifiable, IBirthable
    {
        public Person(string id, string name, int age, string birthDay)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthDay;
        }

        public string Id { get;  private set; }
        public string Name { get;  private set; }       
        public int Age { get;  private set; }        
        public string Birthdate { get; private set; }
    }
}
