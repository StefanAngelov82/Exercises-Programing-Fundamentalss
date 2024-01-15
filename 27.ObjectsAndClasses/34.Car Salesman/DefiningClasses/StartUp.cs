namespace DefiningClasses
{
    public  class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engineData = new List<Engine>();
            List<Car> carsData = new List<Car>();

            EngineDataCollection(engineData);
            CarDataCollection(engineData, carsData);

            foreach(Car car in carsData)
            {
                Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($"  {car.Engine.Model}:");

                        Console.WriteLine($"    Power: {car.Engine.Power}");               
                if (car.Engine.Displacement == - 1)  
                        Console.WriteLine($"    Displacement: n/a");
                else    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                        Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");

                if (car.Weight == -1)
                    Console.WriteLine($"  Weight: n/a");
                else
                    Console.WriteLine($"  Weight: {car.Weight}");
                    Console.WriteLine($"  Color: {car.Color}");
            }
        }

        private static void CarDataCollection(List<Engine> engineData, List<Car> carsData)
        {
            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] inputCar = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                string model = inputCar[0];
                string engineModel = inputCar[1];

                Engine current = engineData.FirstOrDefault(x => x.Model == engineModel);

                Car newCar = new Car(model, current);

                if (inputCar.Length == 4)
                {
                    newCar.Weight = int.Parse(inputCar[2]);
                    newCar.Color = inputCar[3];
                }
                else if (inputCar.Length == 3 && char.IsDigit(inputCar[2][0]))
                {
                    newCar.Weight = int.Parse(inputCar[2]);
                }
                else if (inputCar.Length == 3 && !char.IsDigit(inputCar[2][0]))
                {
                    newCar.Color = inputCar[2];
                }

                carsData.Add(newCar);
            }
        }

        private static void EngineDataCollection(List<Engine> engineData)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputEngine = Console.ReadLine()
                    .Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);

                string model = inputEngine[0];
                int power = int.Parse(inputEngine[1]);

                Engine current = new Engine(model, power);

                if (inputEngine.Length == 4)
                {
                    current.Displacement = int.Parse(inputEngine[2]);
                    current.Efficiency = inputEngine[3];
                }
                else if (inputEngine.Length == 3 && char.IsDigit(inputEngine[2][0]))
                {
                    current.Displacement = int.Parse(inputEngine[2]);
                }
                else if (inputEngine.Length == 3 && !char.IsDigit(inputEngine[2][0]))
                {
                    current.Efficiency = inputEngine[2];
                }

                engineData.Add(current);
            }
        }
    }
}