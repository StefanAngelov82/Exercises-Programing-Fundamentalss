using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.Data = new List<Pet> ();
        }

        public int Capacity { get; set; }
        public List<Pet> Data { get; set; }

        public int Count 
        {
            get => Data.Count; 
        }

        public  void Add(Pet pet)
        {
            if (Data.Count < Capacity)
            {
                Data.Add (pet);
            }
        }

        public bool Remove(string name)
        {
            Pet target = Data.FirstOrDefault (p => p.Name == name);

            if (target == null) 
                return false;

            return Data.Remove(target);
        }

        public Pet GetPet(string name, string owner)
        {
            return Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return Data.OrderByDescending(x => x.Age).First();
        }


        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in Data)
            {
                sb.AppendLine($"{pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
