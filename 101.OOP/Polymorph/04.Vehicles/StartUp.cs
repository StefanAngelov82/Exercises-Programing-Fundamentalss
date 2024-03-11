using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Factories.Interface;
using Vehicles.IO;
using Vehicles.IO.Interface;
using Vehicles.Models.Interface;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            //IWriter writer = new FileWriter();

            IEngine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}