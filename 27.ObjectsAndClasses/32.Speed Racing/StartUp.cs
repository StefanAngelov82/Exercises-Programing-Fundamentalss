namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Car> data = new List<Car>();

            EnteringData(data);
            Traveling(data);

            foreach (var car in data)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }

        private static void Traveling(List<Car> data)
        {
            string Command = String.Empty;

            while ((Command = Console.ReadLine()) != "End")
            {
                string[] CommandArg = Command.Split();

                string carModel = CommandArg[1];
                double amountOfKm = double.Parse(CommandArg[2]);

                Car current = data.FirstOrDefault(x => x.Model == carModel);

                if (current != null)
                {
                    current.CarMove(amountOfKm);
                }
            }
        }

        private static void EnteringData(List<Car> data)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);

                Car current = new Car(model, fuelAmount, fuelConsumptionFor1km);

                data.Add(current);
            }
        }
    }
}