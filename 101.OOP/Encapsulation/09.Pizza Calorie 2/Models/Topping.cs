using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Models
{
    public class Topping
    {
		private Dictionary<string, double> _toppingTypesAndCalories;

        private string _toppingType;
        private double _weight;

        public Topping(string toppingType, double weight)
		{
			_toppingTypesAndCalories = new Dictionary<string, double>();

			AddToppingTypes();

			ToppingType = toppingType;
			Weight = weight;
		}        

		public string ToppingType
        {
			get => _toppingType; 
			private set 
			{
				if (!_toppingTypesAndCalories.ContainsKey(value))
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
			
				_toppingType = value; 
			}
		}		

		public double Weight
        {
			get => _weight; 
			private set 
			{
				if (value < 1 || value > 50)
					throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");

                _weight = value; 
			}
		}

        public double Calories 
		{
			get => CaloriesCalculator();
		}

        private double CaloriesCalculator()
        {
			return GlobalConstants.GlobalConstants.BASE_TOPPING_CALORIES
				* _toppingTypesAndCalories[_toppingType]
				* Weight;
        }

        public void AddToppingTypes()
		{
			_toppingTypesAndCalories.Add("Meat", 1.2);
			_toppingTypesAndCalories.Add("Veggies", 0.8);
			_toppingTypesAndCalories.Add("Cheese", 1.1);
			_toppingTypesAndCalories.Add("Sauce", 0.9);
		}

    }
}
