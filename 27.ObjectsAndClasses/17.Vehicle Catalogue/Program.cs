namespace Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Catalog cat = new Catalog();    

            while ((input = Console.ReadLine()) is not "end")
            {
                string[] inputArg = input.Split('/');

                if (inputArg[0] is "Car")
                {
                    Car newCar = new Car(inputArg[1], inputArg[2], int.Parse(inputArg[3]));
                    cat.Cars.Add(newCar);
                }
                else
                {
                    Truck newTruck = new Truck(inputArg[1], inputArg[2], int.Parse(inputArg[3]));
                    cat.Trucks.Add(newTruck);
                }
            }

            if (cat.Cars.Count is not 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in cat.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HoursePower}hp");
                }
            }

            if (cat.Trucks.Count is not 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in cat.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }           
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck (string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HoursePower { get; set; }

        public Car (string brand, string model, int hoursePower)
        {
            this.Brand= brand;
            this.Model = model;
            this.HoursePower = hoursePower;
        }
    }
    class Catalog
    {
        public List<Truck> Trucks { get; set;}
        public List<Car> Cars { get; set;}

        public Catalog()
        {
            this.Trucks = new List<Truck>();
            this.Cars = new List<Car>();
        }
    }
}