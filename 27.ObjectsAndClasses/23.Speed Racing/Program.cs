using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> data = new List<Car>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Car newCar = Car.DataParse(Console.ReadLine());

                data.Add(newCar);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) is not "End")
            {
                string[] inputArg = input.Split();

                string model = inputArg[1];
                double distance = double.Parse(inputArg[2]);

                Car target = data.FirstOrDefault(x => x.Model == model);

                if (!target.isFuelEnought(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }                
            }

            foreach (var car in data)
            {
                Console.WriteLine(car);
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TravelDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption, double travelDistance)
        {
            this.Model = model; 
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TravelDistance = travelDistance;
        }

        public static Car DataParse(string input)
        {
            string[] inputArg = input.Split();

            string model = inputArg[0];
            double fuelAmount = double.Parse(inputArg[1]);
            double fuelConsumption = double.Parse(inputArg[2]);
            double travelDistance = 0;

            return new Car(model, fuelAmount, fuelConsumption, travelDistance);
        }

        public bool isFuelEnought(double  distance)
        {
            if (this.FuelAmount > 0)
            {
                double possibeDistanse = this.FuelAmount / this.FuelConsumption;

                if (possibeDistanse >= distance)
                {
                    this.TravelDistance += distance;
                    this.FuelAmount -= distance * this.FuelConsumption;

                    return true;
                }
            }
            
            return false;            
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelDistance}";
        }
    }
}