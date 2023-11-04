using System.Threading.Channels;

namespace Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Car newCar = Car.DataParse(Console.ReadLine());

                cars.Add(newCar);
            }

            string input = Console.ReadLine();

            if (input == "fragile")
            {
                cars.Where(x => x.Cargo1.CargoType == "fragile" && x.Cargo1.CargoWeight < 1000)                    
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                cars.Where(x => x.Cargo1.CargoType == "flamable" && x.Engine.EnginePowerl > 250)                   
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo1 { get; set; }


        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo1 = cargo;
        }

        public static Car DataParse(string input)
        {
            string[] inputArg = input.Split();

            string model = inputArg[0];
            int enginSpeed = int.Parse(inputArg[1]);
            int enginPower = int.Parse(inputArg[2]);
            int cargoWeight = int.Parse(inputArg[3]);
            string cargoType = inputArg[4];

            Engine engine = new Engine(enginSpeed, enginPower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            return new Car(model, engine, cargo);

        }
    }

    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePowerl { get; set; }

        public Engine(int engineSpeed, int enginePowerl)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePowerl = enginePowerl;
        }
    }
    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
    }
}