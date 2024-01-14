namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Car> data = new List<Car>();

            DataEntering(data);

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                data.Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tires.Any(x => x.Pressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                data.Where(x => x.Cargo.Type == "flammable")
                    .Where(x => x.Engine.Power > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }

        }

        static void DataEntering(List<Car> data)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                string model = inputArg[0];

                int engineSpeed = int.Parse(inputArg[1]);
                int enginePower = int.Parse(inputArg[2]);

                int cargoWeight = int.Parse(inputArg[3]);
                string cargoType = inputArg[4];

                double tire1Pressure = double.Parse(inputArg[5]);
                int tire1Age = int.Parse(inputArg[6]);

                double tire2Pressure = double.Parse(inputArg[7]);
                int tire2Age = int.Parse(inputArg[8]);

                double tire3Pressure = double.Parse(inputArg[9]);
                int tire3Age = int.Parse(inputArg[10]);

                double tire4Pressure = double.Parse(inputArg[11]);
                int tire4Age = int.Parse(inputArg[12]);


                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car current = new Car(model, engine, cargo);

                current.Tires[0] = new Tires(tire1Age, tire1Pressure);
                current.Tires[1] = new Tires(tire2Age, tire2Pressure);
                current.Tires[2] = new Tires(tire3Age, tire3Pressure);
                current.Tires[3] = new Tires(tire4Age, tire4Pressure);


                data.Add(current);
            }
        }
    }
}