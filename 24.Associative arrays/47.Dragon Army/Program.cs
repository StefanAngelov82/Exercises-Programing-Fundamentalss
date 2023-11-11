namespace Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<Dragon>> data = new Dictionary<string,List<Dragon>>();

            int N = int.Parse(Console.ReadLine());           

            for (int i = 0; i < N; i++)
            {
                Dragon current = Dragon.DataParse();

                current.DragonChek(data);               
            }

            foreach (var kvp in data)
            {

                double averageDamage = kvp.Value.Average(x => x.Damage);
                double averageHealth = kvp.Value.Average(x => x.Health);
                double averageArmor = kvp.Value.Average(x => x.Armor);

                Console.WriteLine($"{kvp.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in kvp.Value.OrderBy(x=>x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }           
        }
    }
    class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string type, string name, int damage, int health, int armor)
        {
            Type = type;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public static Dragon DataParse()
        {
            string[] inputarg = Console.ReadLine().Split();

            string type = inputarg[0];
            string name = inputarg[1];
            int damage = (inputarg[2] == "null") ? 45 : int.Parse(inputarg[2]);
            int health = (inputarg[3] == "null") ? 250 : int.Parse(inputarg[3]);
            int armor = (inputarg[4] == "null") ? 10 : int.Parse(inputarg[4]);

            return new Dragon(type, name, damage, health, armor);
        }

        public void DragonChek(Dictionary<string, List<Dragon>> data)
        {
            if (!data.ContainsKey(this.Type))
            {
                data[this.Type] = new List<Dragon> { this };                
            }
            else
            {
                Dragon existing = data[this.Type].FirstOrDefault(x => x.Name == this.Name);

                if (existing == null)
                {
                    data[this.Type].Add(this);
                }
                else
                {
                    existing.Damage = this.Damage;
                    existing.Health = this.Health;
                    existing.Armor = this.Armor;
                }
            }         
        }
    }
}