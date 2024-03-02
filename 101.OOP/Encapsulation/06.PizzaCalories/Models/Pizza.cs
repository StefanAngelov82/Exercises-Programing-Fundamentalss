using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Pizza
    {
		private string name;
        private Dough doughType;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough doughType)
        {
            this.Name = name;
            this.DoughType = doughType;
			this.toppings = new List<Topping>();
        }

        public string Name
		{
			get { return name; }

			private set 
			{
                if ((value.Length < 1 || value.Length > 15))
                {
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value; 
			}
		}		

		public Dough DoughType
		{
			get { return doughType; }
			private set { doughType = value; }
		}		

		public IReadOnlyCollection<Topping> Toppings
		{
			get => toppings.AsReadOnly();
			
		}

        public double TotalCalories
		{
			get => TotalCaloriesCalculation();
		}


		internal double TotalCaloriesCalculation()
		{			
			double toppingCalories = toppings.Sum(x => x.ToppingCalories);
			double doughCalories = doughType.DoughCalories;		

			return  toppingCalories + doughCalories;
		}

		public void AddTopping(Topping topping)
		{
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);            
        }

    }
}
