using MilitaryElite.Core.Enumerator;
using MilitaryElite.Core.Interface;
using MilitaryElite.Models;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<ISoldier> data = new();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                CheckInput(data, input.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }

            foreach (var soldier in data)
            {
                Console.WriteLine(soldier);
            }
        }

        static void CheckInput(List<ISoldier> data, params string[] input)
        {
            string type = input[0];

            SoldierType soldier = (SoldierType)Enum.Parse(typeof(SoldierType), type);

            switch (soldier)
            {
                case SoldierType.Private:
                    PrivateCreator(data, input);
                    break;

                case SoldierType.LieutenantGeneral:
                    LieutenantGeneralCreator(data, input);
                    break;

                case SoldierType.Engineer:
                    EngineerCreator(data, input);
                    break;

                case SoldierType.Commando:
                    CommandoCreator(data, input);
                    break;

                case SoldierType.Spy:
                    SpyCreator(data, input);
                    break;
                    
                default:
                    break;
            }

        }

        private static void SpyCreator(List<ISoldier> data, string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            int codeNumber = int.Parse(input[4]); 

            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            data.Add(spy);
        }

        static void CommandoCreator(List<ISoldier> data, string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);

            if (input[5] != "Airforces" && input[5] != "Marines")
            {
                return;
            }

            Corps corps = (Corps)Enum.Parse(typeof(Corps), input[5]);

            Commando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                string codename = input[i];

                if (input[i + 1] != "inProgress" && input[i + 1] != "Finished")
                {
                    continue;
                }

                State state = (State)Enum.Parse(typeof(State), input[i + 1]);

                Mission mission = new Mission(codename, state);

                commando.AddMissionInTasks(mission);
            }

            data.Add(commando);
        }

        static void EngineerCreator(List<ISoldier> data, string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);

            if (input[5] != "Airforces" && input[5] != "Marines")
            {
                return;
            }

            Corps corps = (Corps)Enum.Parse(typeof(Corps), input[5]);

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                string partName = input[i];
                int hoursWork = int.Parse(input[i + 1]);

                Repair repair = new Repair(partName, hoursWork);

                engineer.AddRepairInWork(repair);
            }

            data.Add(engineer);
        }

        static void LieutenantGeneralCreator(List<ISoldier> data, string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);

            LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < input.Length; i ++)
            {
                int privateId =int.Parse(input[i]);

                ISoldier? needed = data.FirstOrDefault(x => x.Id == privateId);

                general.AddInTeam((IPrivate)needed);
            }

            data.Add(general);
        }

        static void PrivateCreator(List<ISoldier> data, string[] input)
        {
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            decimal salary = decimal.Parse(input[4]);

            data.Add(new Private(id, firstName, lastName, salary));
        }
    }
}
