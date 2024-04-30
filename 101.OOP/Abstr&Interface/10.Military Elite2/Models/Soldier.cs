using Military_Elite2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Military_Elite2.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is Private)
            {
                Private other = (Private)obj;

                return this.Id == other.Id;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}>";
        }
    }
}
