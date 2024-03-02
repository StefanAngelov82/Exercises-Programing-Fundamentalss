using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
		private const double BaseCaloriesPerGram = 2;
		private const string ExceptionMessage = "Invalid type of dough.";
		private const string ExceptionMessage1 = "Dough weight should be in the range [1..200].";


        private Dictionary<string, double> flowerTypeCalories;
		private Dictionary<string, double> backingTechniquesCalories;

		private string flourType;
        private string bakingTechnique;
        private double grams; 

        public Dough(string flourType, string bakingTechnique, double grams)
        {
			flowerTypeCalories = new Dictionary<string, double>()
			{
				{"white", 1.5 },
				{"wholegrain", 1} 
			};

			backingTechniquesCalories = new Dictionary<string, double>() 
			{
				{"crispy", 0.9 },
				{"chewy", 1.1},
				{"homemade", 1 }
			};

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
			get { return flourType; }

			private set 
			{
                if (!flowerTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                flourType = value.ToLower(); 
			}
		}		

		public string BakingTechnique
        {
			get { return bakingTechnique; }

			private set 
			{
                if (!backingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                bakingTechnique = value.ToLower(); 
			}
		}		

		public double Grams
		{
			get { return grams; }

			private set 
			{
				if (value < 1 || value > 200)
				{
                    throw new ArgumentException(ExceptionMessage1);
                }

				grams = value; 
			}
		}

		public double DoughCalories
		{
			get =>	(grams * BaseCaloriesPerGram) * 
					(flowerTypeCalories[FlourType] * backingTechniquesCalories[BakingTechnique]);
        }

		
			
		   
        
    }
}
