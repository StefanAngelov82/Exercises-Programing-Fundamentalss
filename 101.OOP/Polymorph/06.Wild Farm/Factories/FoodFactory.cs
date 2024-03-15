using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Factories.Interface;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Factories
{
    public class FoodFactory : IFoodFactory
    {        
        public IFood Creator(params string[] foodData)
        {
            string foodName = foodData[0];
            int foodQuantity = int.Parse(foodData[1]);

            switch (foodName)
            {
                case "Vegetable":
                    return new Vegetable(foodQuantity);                    

                case "Fruit":
                    return new Fruit(foodQuantity);

                case "Meat":
                    return new Meat(foodQuantity);

                case "Seeds":
                    return new Seeds(foodQuantity);

                default:
                    throw new ArgumentException("Invalid food");
            }
        }
    }
}
