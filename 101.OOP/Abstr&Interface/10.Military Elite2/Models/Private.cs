using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Models
{
    public class Private : Soldier
    {
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }


        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}";
        }

    }
}
