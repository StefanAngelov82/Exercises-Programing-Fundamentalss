using Military_Elite2.Core.Enumerator;
using Military_Elite2.Core.Interface;
using Military_Elite2.Factory;
using Military_Elite2.Factory.Interface;
using Military_Elite2.Models;
using Military_Elite2.Models.Interface;
using Military_Elite2.Repository;
using Military_Elite2.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Core
{
    public class Controller : IController
    {
        private IFactory factory;
        private IRepository<ISoldier> repository;

        public Controller()
        {
            factory = new SoldierFactory();
            repository = new SoldierRepository();
        }

        public void GenerateCommando(string[] inputArg)
        {
            throw new NotImplementedException();
        }

        public void GenerateEngineer(string[] inputArg)
        {
            throw new NotImplementedException();
        }

        public void GenerateLieutenantGeneral(string[] inputArg)
        {
            throw new NotImplementedException();
        }

        public void GeneratePrivate(string[] inputArg)
        {
            Private @private = (Private)ParseData(inputArg);

            if (!repository.Exist(@private.Id))
                repository.Add(@private);            
        }

        public void GenerateSpy(string[] inputArg)
        {
            throw new NotImplementedException();
        }


        private ISoldier ParseData(string[] inputArg)
        {
            string type = inputArg[0];
            int id = int.Parse(inputArg[1]);
            string firstName = inputArg[2];
            string lastName = inputArg[3];
            decimal salary = decimal.Parse(inputArg[4]);

            if (Enum.IsDefined(typeof(SpecialisedSoldierсType), type))
            {
                string corp = inputArg[5];               

                if (corp != "Airforces" && corp != "Marine")
                    return null;

                return factory.SoldierCreator(type, id, firstName, lastName, salary, corp);
            }

            else
                return factory.SoldierCreator(type, id, firstName, lastName, salary);
           
        }
    }
}
