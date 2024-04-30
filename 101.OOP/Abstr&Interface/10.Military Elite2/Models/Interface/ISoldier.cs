using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Models.Interface
{
    public interface ISoldier
    {
        public int Id { get; }
        public string FirstName { get; } 
        public string LastName { get; }

    }
}
