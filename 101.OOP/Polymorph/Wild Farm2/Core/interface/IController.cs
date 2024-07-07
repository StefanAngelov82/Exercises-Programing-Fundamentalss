using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Animal_Models;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Core
{
    public interface IController
    {
        public IAnimal? CreateAnimal(string? currentAnimalData);

        public IFood? CreateFood(string? currentFoodData);

        public string AnimalDangle(IAnimal? animal, IFood? food);

        public string PrintAnimalData();
    }
}
