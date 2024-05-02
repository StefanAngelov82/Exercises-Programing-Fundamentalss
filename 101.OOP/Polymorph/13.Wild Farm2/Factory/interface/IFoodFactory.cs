using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Factory
{
    public interface IFoodFactory
    {
        public IFood? FoodCreator(string[] FoodData);
    }
}
