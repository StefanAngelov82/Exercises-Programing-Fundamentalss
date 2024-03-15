using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Factories.Interface;
using Wild_Farm.Models.Animals;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Creator(params string[] animalData)
        {
            string type = animalData[0];
            string name = animalData[1]; 
            double weight = double.Parse(animalData[2]);
            double wingSize;
            string livingRegion;
            string breed;

            switch (type)
            {
                case "Hen":
                case "Owl":                  
                   
                    wingSize = double.Parse(animalData[3]);

                    if  (type == "Hen")     return new Hen(name, weight, wingSize);
                    else                    return new Owl(name, weight, wingSize);

                case "Mouse":
                case "Dog":
                                        
                    livingRegion = animalData[3];

                    if (type == "Mouse") return new Mouse(name, weight, livingRegion);
                    else                 return new Dog(name, weight, livingRegion);

                case "Tiger":
                case "Cat":

                    livingRegion = animalData[3];
                    breed = animalData[4];

                    if (type == "Tiger") return new Tiger(name, weight, livingRegion, breed);
                    else                 return new Cat(name, weight, livingRegion, breed);

                default:
                    throw new ArgumentException("Invalid Animal");

            }
        }
    }
}
