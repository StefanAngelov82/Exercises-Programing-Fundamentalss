using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> data = new Dictionary<string, List<Dragon>>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                int damage = (input[2] == "null") ? 45 : int.Parse(input[2]);
                int health = (input[3] == "null") ? 250 : int.Parse(input[3]);
                int armor = (input[4] == "null") ? 10 : int.Parse(input[4]);

                Dragon current = new Dragon(name, type, damage, health, armor);

                if (!data.ContainsKey(type))
                {
                    data[type] = new List<Dragon>();
                }

                if (!data[type].Contains(current))
                {
                    data[type].Add(current);
                }
                else
                {
                    Dragon existing = data[type].FirstOrDefault(x => x.Name == name);

                    existing.Damage = damage;
                    existing.Health = health;
                    existing.Armor = armor;
                }
            }

            foreach (var kvp in data)
            {
                double averageDamage = kvp.Value.Average(x => x.Damage);
                double averageHealth = kvp.Value.Average(x => x.Health);
                double averageArmor = kvp.Value.Average(x => x.Armor);

                Console.WriteLine($"{kvp.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var item in kvp.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{item.Name} -> damage: {item.Damage}, health: {item.Health}, armor: {item.Armor}");
                }
            }
        }
    }
    class Dragon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string name, string type, int damage, int health, int armor)
        {
            this.Name = name;
            this.Type = type;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public override bool Equals(object obj)
        {
            if (obj is Dragon)
            {
                Dragon other = (Dragon)obj;

                return other.Name == this.Name &&
                       other.Type == this.Type;
            }
            return false;
        }
    }
}
