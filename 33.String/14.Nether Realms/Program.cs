using System.Text.RegularExpressions;

namespace Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] deamonsData = Console.ReadLine()
                .Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            List<Deamon> data = new List<Deamon>();

            foreach (var deamon in deamonsData)
            {
                string name = deamon;
                int health = 0;
                double damage = 0;

                string healthPattern = @"[^0-9\+\-\*\/\.]";

                foreach (Match matches in Regex.Matches(deamon, healthPattern))
                {
                    health += char.Parse(matches.Value);
                }

                string damagePattern = @"[+|-]?\d+(?:\.\d+)?";

                foreach (Match matches in Regex.Matches(deamon, damagePattern))
                {
                    damage += double.Parse(matches.Value);
                }

                string multilicatorPattern = @"[\*|\/]";                

                foreach (Match matches in Regex.Matches(deamon, multilicatorPattern))
                {
                    if (matches.Value == "*") damage *= 2;
                    else damage /= 2;
                }

                Deamon current = new Deamon(name, health, damage);
                data.Add(current);
            }

            foreach (var deamon in data.OrderBy(x =>x.Name))
            {
                Console.WriteLine(deamon);
            }
        }
    }
    class Deamon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Deamon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Health} health, {this.Damage:F2} damage";
        }
    }
}