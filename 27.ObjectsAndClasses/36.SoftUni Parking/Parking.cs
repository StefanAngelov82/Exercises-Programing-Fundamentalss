using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            Cars = new Dictionary<string, Car>();
            Capacity = capacity;
        }


        public Dictionary<string, Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get => this.Cars.Count;
        }

        public string AddCar(Car currentCar)
        {
            if (Cars.ContainsKey(currentCar.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";                
            }

            if (this.Cars.Count >= this.Capacity)
            {
                return "Parking is full!";                
            }

            this.Cars[currentCar.RegistrationNumber] = currentCar;

            return $"Successfully added new car {currentCar.Make} {currentCar.RegistrationNumber}";            
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.Cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";               
            }

            this.Cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
