using Military_Elite2.Core.Interface;
using Military_Elite2.Factory;
using Military_Elite2.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Core
{
    public class Controller : IController
    {
        private IFactory factory;

        public Controller()
        {
            factory = new SoldierFactory();
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
            throw new NotImplementedException();
        }

        public void GenerateSpy(string[] inputArg)
        {
            throw new NotImplementedException();
        }
    }
}
