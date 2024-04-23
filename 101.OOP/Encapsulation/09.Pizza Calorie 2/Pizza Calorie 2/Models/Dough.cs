using Pizza_Calorie_2.GlobalConstants;
using Pizza_Calorie_2.Utility.ExceptionMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Calorie_2.Models
{
    public class Dough
    {
        private Dictionary<string, double> _flowerTypesAndCalories;
        private Dictionary<string, double> _backingTechniquesAndCalories;

        private string _doughType;
        private string _bakingTechnique;
        private double _weight;

        public Dough(string doughType, string bakingTechnique, double weight)
        {
            _flowerTypesAndCalories = new Dictionary<string, double>();
            _backingTechniquesAndCalories = new Dictionary<string, double>();            

            AddDoughTypes();
            AddBakingTechniques();

            DoughType = doughType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string DoughType
        {
            get => _doughType;

            private set
            {
                if ((string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) || (!_flowerTypesAndCalories.ContainsKey(value)))
                    throw new ArgumentNullException(ExceptionMessages.ExceptionMessage);

                _doughType = value;
            }
        }

        public string BakingTechnique
        {
            get => _bakingTechnique;

            private set
            {
                if ((string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) || ((!_backingTechniquesAndCalories.ContainsKey(value))))
                    throw new ArgumentNullException(ExceptionMessages.ExceptionMessage);

                _bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => _weight;

            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException(ExceptionMessages.ExceptionMessage1);

                _weight = value;
            }
        }

        public double Calories
        {
            get => CaloriesCalculator();
        }

        private double CaloriesCalculator()
        {
            return GlobalConstants.GlobalConstants.BASE_DOUGH_CALORIES
                * _flowerTypesAndCalories[_doughType]
                * _backingTechniquesAndCalories[_bakingTechnique]
                * Weight;
        }

        private void AddDoughTypes()
        {
            _flowerTypesAndCalories.Add("White", 1.5);
            _flowerTypesAndCalories.Add("Wholegrain", 1);
        }
        private void AddBakingTechniques()
        {
            _backingTechniquesAndCalories.Add("Crispy", 0.9);
            _backingTechniquesAndCalories.Add("Chewy", 1.1);
            _backingTechniquesAndCalories.Add("Homemade", 1);
        }

        public override string ToString()
        {
            return $"{DoughType}/{BakingTechnique}/{Weight}-->{Calories:F2}";
        }

    }
}
