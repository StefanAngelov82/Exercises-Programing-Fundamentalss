using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.IO;
using Wild_Farm2.IO.Interface;
using Wild_Farm2.Models.Animal_Models;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWrite write;
        private readonly IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.write = new Writer();
            this.controller = new Controller();
        }

        public void Run()
        {
            DataProcessing();

            write.Write(controller.PrintAnimalData());
        }

        private void DataProcessing()
        {
            string? currentAnimalData = String.Empty;
            string? currentFoodData = String.Empty;

            while ((currentAnimalData = reader.Read()) != "End" && (currentFoodData = reader.Read()) != "End")
            {
                try
                {
                    IAnimal? currentAnimal = controller.CreateAnimal(currentAnimalData);
                    IFood? currentFood = controller.CreateFood(currentFoodData);

                    write.Write(controller.AnimalDangle(currentAnimal, currentFood));
                }
                catch (Exception ex)
                {

                    write.Write(ex.Message);
                }
                
            }            
        }
    }
}
