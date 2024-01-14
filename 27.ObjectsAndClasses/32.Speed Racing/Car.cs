using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {

		private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.travelledDistance = 0;
        }



        public string Model
		{
			get { return model; }
			set { model = value; }
		}		

		public double FuelAmount
        {
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}	

		public double FuelConsumptionPerKilometer
        {
			get { return fuelConsumptionPerKilometer; }
			set { fuelConsumptionPerKilometer = value; }
		}      

        public double TravelledDistance
		{
			get { return travelledDistance; }
			set { travelledDistance = value; }
		}


		public void CarMove(double amountOfKm)
		{
			double consumedFuel = amountOfKm * this.FuelConsumptionPerKilometer;

            if (this.FuelAmount >= consumedFuel) 
            {
                this.FuelAmount -= consumedFuel;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

	}
}
