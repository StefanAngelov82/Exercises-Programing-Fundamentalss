using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Core.Interface
{
    public interface IController
    {
        public void GeneratePrivate(string[] inputArg);

        public void GenerateLieutenantGeneral(string[] inputArg);

        public void GenerateEngineer(string[] inputArg);

        public void GenerateCommando(string[] inputArg);
        public void GenerateSpy(string[] inputArg);

        public string PrintData();


    }
}
