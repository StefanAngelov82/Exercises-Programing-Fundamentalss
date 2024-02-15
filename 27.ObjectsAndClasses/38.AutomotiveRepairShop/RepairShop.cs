using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }


        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)            
                Vehicles.Add(vehicle);           
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle? target = Vehicles.FirstOrDefault(x => x.VIN == vin);

            if (target == null)
                return false;
            
            Vehicles.Remove(target);
            return true;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(x => x.Mileage).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var car in Vehicles)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
