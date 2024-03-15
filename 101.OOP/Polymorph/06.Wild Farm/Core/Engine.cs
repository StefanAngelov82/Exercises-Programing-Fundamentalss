using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Core.Interface;
using Wild_Farm.Factories.Interface;
using Wild_Farm.IO.Interface;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        public ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;

            animals = new List<IAnimal>();

            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            try
            {
                ProcessingInputData();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

            foreach (var animal in animals )
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private void ProcessingInputData()
        {
            string inputAnimal = String.Empty;
            string inputFood = String.Empty;
            

            while ((inputAnimal = reader.ReadLine()) != "End" && (inputFood = reader.ReadLine()) != "End")
            {
                IAnimal currentAnimal = CreateAnimal(inputAnimal);
                IFood currentFood = CreateFood(inputFood);

                writer.WriteLine(currentAnimal.Sound().ToString());

                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message.ToString());
                }
                

                animals.Add(currentAnimal);               
            }
        }

        private IAnimal CreateAnimal(string inputAnimal)
        {
            return animalFactory.Creator(inputAnimal.Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }

        private IFood CreateFood(string inputFood)
        {
            return foodFactory.Creator(inputFood.Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }


    }
}
