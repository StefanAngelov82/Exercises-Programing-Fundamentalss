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
using System.Linq;
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
            Commando commando = ParseData(inputArg) as Commando;

            if (commando == null) return;

            if (!repository.Exist(commando.Id))
            {
                for (int i = 6; i < inputArg.Length; i += 2)
                {
                    string missionName = inputArg[i];
                    string missionStatus = inputArg[i + 1];

                    if (commando.Missions.ContainsKey(missionName)
                        || (missionStatus != "inProgres" && missionStatus != "Finished"))
                    {
                        continue;
                    }

                    commando.AddMission(missionName, missionStatus);
                }

                repository.Add(commando);
            }
        }

        public void GenerateEngineer(string[] inputArg)
        {
            Engineer engineer =  ParseData(inputArg) as Engineer;

            if (engineer == null) return;

            if (!repository.Exist(engineer.Id))
            {
                for (int i = 6; i < inputArg.Length; i += 2)
                {
                    string partName = inputArg[i];
                    int hours = int.Parse(inputArg[i + 1]);

                    if (!engineer.Repairs.Any(x => x.Key == partName))
                        engineer.AddRepairs(partName, hours);
                }

                repository.Add(engineer);
            }            
        }

        public void GenerateLieutenantGeneral(string[] inputArg)
        {
            LieutenantGeneral lieutenantGeneral = (LieutenantGeneral)ParseData(inputArg);

            if (!repository.Exist(lieutenantGeneral.Id))
            {
                foreach (var id in inputArg.Skip(4))
                {
                    int currentId = int.Parse(id);

                    if (repository.Exist(currentId))
                    {
                        ISoldier soldier = repository.GetSoldier(currentId);

                        if (soldier is Private && !lieutenantGeneral.Team.Any(x =>x.Id == currentId))                
                            repository.Add(soldier);
                    }
                }

                repository.Add(lieutenantGeneral);
            }           
        }

        public void GeneratePrivate(string[] inputArg)
        {
            Private @private = (Private)ParseData(inputArg);

            if (!repository.Exist(@private.Id))
                repository.Add(@private);            
        }

        public void GenerateSpy(string[] inputArg)
        {
            Spy spy = (Spy)ParseData(inputArg);

            if (!repository.Exist(spy.Id))
                repository.Add(spy);
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

                if (corp != "Airforces" && corp != "Marines")
                    return null;

                return factory.SoldierCreator(type, id, firstName, lastName, salary, corp);
            }

            else
                return factory.SoldierCreator(type, id, firstName, lastName, salary);
           
        }

        public string PrintData()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var soldier in repository.SoldiersData)
                sb.AppendLine(soldier.ToString());           

            return sb.ToString().Trim();
        }
    }
}
