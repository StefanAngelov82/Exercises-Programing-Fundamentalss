using Military_Elite2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Factory.Interface
{
    public interface IFactory
    {
        ISoldier SoldierCreator(string type, int id, string firsName, string lastName, decimal salary, string corps = null);
    }
}
