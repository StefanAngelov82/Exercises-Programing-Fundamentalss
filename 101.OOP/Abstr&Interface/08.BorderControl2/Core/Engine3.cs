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
    public class Engine3 : IEngine
    {
        public void Run()
        {
            List<Human> data = new List<Human>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name, id, birthDay, group;
                int age;

                if (inputArg.Length == 4)
                {
                    name = inputArg[0];
                    age = int.Parse(inputArg[1]);
                    id = inputArg[2];
                    birthDay = inputArg[3];

                    data.Add(new Person( name, age, id, birthDay));
                }
                else 
                {
                    name = inputArg[0];
                    age = int.Parse(inputArg[1]);                    
                    group = inputArg[2];

                    data.Add(new Rebel(name, age, group));
                }
            }

            string input = String.Empty;


            while ((input = Console.ReadLine()) != "End")
            {
                Human? target = data.FirstOrDefault(x => x.Name == input);

                if (target is not null)
                {
                    target.BuyFood();
                }
            }           

            int totalFood = data.Sum(x => x.Food);

            Console.WriteLine(totalFood);

        }
    }
}
