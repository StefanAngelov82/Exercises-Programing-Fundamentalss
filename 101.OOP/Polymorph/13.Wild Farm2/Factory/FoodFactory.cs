using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm2.Core.Enumerators;
using Wild_Farm2.Models;
using Wild_Farm2.Models.Food_Models;
using Wild_Farm2.Models.Interface;

namespace Wild_Farm2.Factory
{
    public class FoodFactory : IFoodFactory
    {
        public IFood? FoodCreator(string[] FoodData)
        {
            string name = FoodData[0];
            int quantity = int.Parse(FoodData[1]);

            if (!Enum.IsDefined(typeof(Foods), name)) 
                return null;

            Foods food = (Foods)Enum.Parse(typeof(Foods), name);

            switch (food)
            {
                case Foods.Vegetable:
                    return new Vegetable(quantity);

                case Foods.Fruit:
                    return new Fruit(quantity);

                case Foods.Meat:
                    return new Meat(quantity);

                case Foods.Seeds:
                    return new Seeds(quantity);

                default:
                    return null;
            }
        }
    }
}
