namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelConsumption = 2;
            car.FuelQuantity = 100;

            car.Drive(50);
            Console.WriteLine(car.WhoAmI());

            
        }
    }
}