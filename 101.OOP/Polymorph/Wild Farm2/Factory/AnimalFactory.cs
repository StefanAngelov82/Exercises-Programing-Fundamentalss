using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Core.Enumerators;
using Wild_Farm2.Models.Animal_Models;
using Wild_Farm2.Models.Animal_Models.Abstract_Models;

namespace Wild_Farm2.Factory
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal? Creator(string[] AnimalData)
        {
            string animalType = AnimalData[0];
            string name = AnimalData[1];
            double weight = double.Parse(AnimalData[2]);
            string livingRegion;
            double wingSize;
            string bread;           

            if (!Enum.IsDefined(typeof(Animals), animalType))
                return null;

            Animals animal = (Animals)Enum.Parse(typeof(Animals), animalType);

            switch (animal)
            {
                case Animals.Owl:
                    wingSize = double.Parse((string)AnimalData[3]);

                    return new Owl(name, weight, wingSize);

                case Animals.Hen:
                    wingSize = double.Parse((string)AnimalData[3]);

                    return new Hen(name, weight, wingSize);

                case Animals.Mouse:
                    livingRegion = AnimalData[3];

                    return new Mouse(name, weight, livingRegion);

                case Animals.Dog:
                    livingRegion = AnimalData[3];

                    return new Dog(name, weight, livingRegion);

                case Animals.Cat:
                    livingRegion = AnimalData[3];
                    bread = AnimalData[4];

                    return new Cat(name, weight, livingRegion, bread);

                case Animals.Tiger:
                    livingRegion = AnimalData[3];
                    bread = AnimalData[4];

                    return new Tiger(name, weight, livingRegion, bread);

                default:
                    return null;
            }
        }
    }
}
