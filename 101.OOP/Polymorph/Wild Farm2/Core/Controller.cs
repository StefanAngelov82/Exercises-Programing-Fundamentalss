using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Factory;
using Wild_Farm2.Models.Animal_Models;
using Wild_Farm2.Models.Interface;
using Wild_Farm2.Repository;
using Wild_Farm2.Repository.Interface;

namespace Wild_Farm2.Core
{
    public class Controller : IController
    {
        private readonly IAnimalFactory? animalFactory;
        private readonly IFoodFactory? foodFactory;
        private readonly IRepository<IAnimal> repository;

        public Controller()
        {
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.repository = new AnimalRepository();
        }

        public string AnimalDangle(IAnimal? animal, IFood? food)
        {
            animal.Eat(food);

            repository.AddAnimal(animal);

            return animal.ProducingSound();
        }

        public IAnimal? CreateAnimal(string? currentAnimalData)
        {
            string[] AnimalData = currentAnimalData.Split();

            return animalFactory.Creator(AnimalData);
        }

        public IFood? CreateFood(string? currentFoodData)
        {
            string[] FoodData = currentFoodData.Split();

            return foodFactory.FoodCreator(FoodData);
        }

        public string PrintAnimalData()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in repository.Animals)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
