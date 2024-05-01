using Military_Elite2.Factory.Interface;
using Military_Elite2.Models;
using Military_Elite2.Models.Interface;
using MilitaryElite.Core.Enumerator;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Military_Elite2.Factory
{
    public class SoldierFactory : IFactory
    {
        public ISoldier SoldierCreator(
            string type, int id, string firsName, string lastName, decimal salary, string corps = null)
        {
            SoldierType soldier = (SoldierType)Enum.Parse(typeof(SoldierType), type);

            switch (soldier)
            {
                case SoldierType.Private:
                    return new Private(id, firsName, lastName, salary);                    

                case SoldierType.LieutenantGeneral:
                    return new LieutenantGeneral(id, firsName, lastName, salary);

                case SoldierType.Engineer:
                    return new Engineer(id, firsName, lastName, salary, corps);

                case SoldierType.Commando:
                    return new Commando(id, firsName, lastName, salary, corps);

                case SoldierType.Spy:
                    return new Spy(id, firsName, lastName, salary);

                default:
                    return null;
            }
        }
    }
}
