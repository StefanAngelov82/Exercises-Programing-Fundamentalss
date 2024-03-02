using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
	public class Topping
	{
		private const double BaseCaloriesPerGram = 2;

		private const string ExceptionMessage = "Cannot place {0} on top of your pizza.";
		private const string ExceptionMessage1 = "{0} weight should be in the range [1..50].";
		private string exceptionMemory;

		private Dictionary<string, double> toppingTypeCalories;

		private string toppingType;
		private double grams;

		public Topping(string toppingType, double grams)
		{
			toppingTypeCalories = new Dictionary<string, double>()
			{
				{"meat", 1.2},
				{"veggies", 0.8},
				{"cheese", 1.1},
				{"sauce", 0.9}
			};

			this.ToppingType = toppingType;
			this.Grams = grams;
		}

		public string ToppingType
		{
			get { return toppingType; }

			private set
			{
				if (!toppingTypeCalories.ContainsKey(value.ToLower()))
				{
					throw new ArgumentException(string.Format(ExceptionMessage, value));
				}

				exceptionMemory = value;
				toppingType = value.ToLower();
			}
		}

		public double Grams
		{
			get { return grams; }

			private set
			{
				if (value < 0 || value > 50)
				{
					throw new ArgumentException(string.Format(ExceptionMessage1, exceptionMemory));
				}

				grams = value;
			}
		}

		public double ToppingCalories
		{
			get => BaseCaloriesPerGram * Grams * toppingTypeCalories[ToppingType];
		}
	}
}
