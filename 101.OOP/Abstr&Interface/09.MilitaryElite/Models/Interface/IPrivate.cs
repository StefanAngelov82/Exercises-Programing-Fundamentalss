using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interface
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get;}
    }
}
