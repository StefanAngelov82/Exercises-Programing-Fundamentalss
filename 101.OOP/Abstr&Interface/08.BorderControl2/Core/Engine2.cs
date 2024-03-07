using BorderControl.Core.Interface;
using BorderControl.Models;
using BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine2 : IEngine
    {
        public void Run()
        {
            //    List<IBirthable> data = new List<IBirthable>();

            //    string input = String.Empty;

            //    while ((input = Console.ReadLine()) != "End")
            //    {
            //        string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //        string name, id, birthDay;
            //        int age;


            //        if (inputArg[0] == "Citizen")
            //        {
            //            name = inputArg[1];
            //            age = int.Parse(inputArg[2]);
            //            id = inputArg[3];
            //            birthDay = inputArg[4];

            //            data.Add(new Person(id, name, age, birthDay));
            //        }
            //        else if (inputArg[0] == "Pet")
            //        {
            //            name = inputArg[1];
            //            birthDay = inputArg[2];

            //            data.Add(new Pet(name, birthDay));
            //        }
            //    }

            //    string key = Console.ReadLine();

            //    data.Where(x => x.Birthdate.EndsWith(key)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
            //}}
        }
    }
}
