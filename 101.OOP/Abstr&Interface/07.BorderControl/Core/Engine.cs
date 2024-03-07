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
    public class Engine : IEngine
    {        

        List<Iidentifiable> data = new List<Iidentifiable>();


        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);   
                
                if (inputArg.Length == 3)
                {
                    string name = inputArg[0];
                    int age = int.Parse(inputArg[1]);
                    string id = inputArg[2];

                   // data.Add(new Person(id, name, age));
                }
                else
                {
                    string model = inputArg[0];
                    string id = inputArg[1];

                    data.Add(new Robot(id, model)); 
                }
            }

            string key = Console.ReadLine();

            data.Where(x => x.Id.EndsWith(key)).ToList().ForEach(x => Console.WriteLine(x.Id));                  
        }
    }
}
