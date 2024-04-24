using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Models
{
    public class Pizza
    {
		private string _name;
        private List<Topping> _toppings;
		private Dough _dough = null;

        public Pizza(string name)
        {
            Name = name;			
			_toppings = new List<Topping>();
        }

        public string Name
		{
			get => _name; 
			private set 
			{
				if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                _name = value;
			}
		}	

		public IReadOnlyCollection<Topping> Toppings
		{
			get => _toppings.AsReadOnly();			
		}

		public Dough Dough { get => _dough;}

        public double TotalCalories 
		{
			get => CaloriesCalculation();            
		}

        public void AddToppingOnPizza(Topping currentTopping)
		{
			if (_toppings.Count == 10)
				throw new ArgumentException("Number of toppings should be in range [0..10].");

            _toppings.Add(currentTopping);
		}
		public void AddDoughOnPizza(Dough currentDough)
		{
			_dough = currentDough;
		}

		public double CaloriesCalculation()
		{
			if (Dough == null) return 0;

            if (_toppings.Count == 0)           
				return _dough.Calories;            

            return _dough.Calories + _toppings.Sum(x => x.Calories);
        }

        public override string ToString()
        {
			return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}
