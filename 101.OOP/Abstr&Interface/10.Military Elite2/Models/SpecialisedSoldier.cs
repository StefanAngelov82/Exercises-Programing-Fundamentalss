using Military_Elite2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string  _corps;

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps 
        {
            get => _corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                    throw new ArgumentException();
               
                _corps = value; 
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary} Corps: {Corps}");

            return sb.ToString().Trim();
        }
    }
}
