using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Models
{
    public class Spy : Soldier
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $"Code Number: {CodeNumber}";
        }
    }
}
