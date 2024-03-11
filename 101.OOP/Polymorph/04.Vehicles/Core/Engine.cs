using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories;
using Vehicles.Factories.Interface;
using Vehicles.IO.Interface;
using Vehicles.Models;
using Vehicles.Models.Interface;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<Models.Interface.Vehicle> vehicles;

        public Engine( IReader reader, IWriter writer,  IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            vehicles = new List<Models.Interface.Vehicle>();
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());            

            int N = int.Parse(reader.ReadLine());

            for (int i = 0; i < N; i++)
            {
                try
                {
                    DriveOrRefuel();
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);

                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private Models.Interface.Vehicle CreateVehicle()
        {
            string[] Input = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Creator(Input[0], double.Parse(Input[1]), double.Parse(Input[2]), double.Parse(Input[3]));
        }

        private void DriveOrRefuel()
        {
            string[] input = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Models.Interface.Vehicle? vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == input[1]);

            if (vehicle is not null)
            {
                if (input[0] == "Drive")
                    writer.WriteLine(vehicle.Drive(double.Parse(input[2])));

                else if(input[0] == "DriveEmpty")
                    writer.WriteLine(vehicle.Drive(double.Parse(input[2]), true));

                else 
                    vehicle.Refuel(double.Parse(input[2]));
            }
        }      
    }
}
