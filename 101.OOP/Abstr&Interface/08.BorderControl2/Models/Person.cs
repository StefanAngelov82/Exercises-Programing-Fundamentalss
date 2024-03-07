using BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Person : Human, Iidentifiable, IBirthable
    {
        public Person( string name, int age, string id, string birthDay) : base(name, age)
        {
            Id = id;           
            Birthdate = birthDay;           
        }

        public string Id { get;  private set; }         
        public string Birthdate { get; private set; }        

        public  override void BuyFood()
        {
            Food += 10;
        }
    }
}
