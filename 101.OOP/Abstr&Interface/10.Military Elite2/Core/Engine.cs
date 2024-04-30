using Military_Elite2.Core.Interface;
using Military_Elite2.IO;
using MilitaryElite.Core.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Military_Elite2.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller(); 
        }

        public void Run()
        {
            string input = String.Empty;

            while ((input = reader.Read()) != "End")
            {
                string[] inputArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = inputArg[0];

                if (IsSoldierTypeValid(soldierType))
                {
                    try
                    {
                        ProcessingInputData(inputArg, soldierType);
                    }
                    catch (Exception ex)
                    {
                        writer.Write(ex.Message);                        
                    }
                }
            }
        }

        private void ProcessingInputData(string[] inputArg, string soldierType)
        {
            SoldierType soldier = (SoldierType)Enum.Parse(typeof(SoldierType), soldierType);

            switch (soldier)
            {
                case SoldierType.Private:
                    controller.GeneratePrivate(inputArg);
                    break;

                case SoldierType.LieutenantGeneral:
                    controller.GenerateLieutenantGeneral(inputArg);
                    break;

                case SoldierType.Engineer:
                    controller.GenerateEngineer(inputArg);
                    break;

                case SoldierType.Commando:
                    controller.GenerateCommando(inputArg);
                    break;

                case SoldierType.Spy:
                    controller.GenerateSpy(inputArg);
                    break;
            }
        }
        private bool IsSoldierTypeValid(string type)
        {
            return Enum.IsDefined(typeof(SoldierType), type);
        }
    }
}
