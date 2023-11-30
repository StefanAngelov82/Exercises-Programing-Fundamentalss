using System.Text;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Planet> data = new List<Planet>();

            for (int i = 0; i < N; i++)
            {
                string code = Console.ReadLine();

                string result = Decripting(code);

                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!>:]*?:(?<population>\d+)[^@\-!>:]*?!(?<fate>[AD])![^@\-!>:]*?->(?<soldiers>\d+)";

                foreach (Match match in Regex.Matches(result, pattern))
                {
                    string name = match.Groups["name"].Value;
                    long population = long.Parse(match.Groups["population"].Value);
                    char fate = char.Parse(match.Groups["fate"].Value);
                    long soldiers = long.Parse(match.Groups["soldiers"].Value);

                    Planet curent = new Planet(name, population, fate, soldiers);
                    data.Add(curent);
                }
            }

            int count = data.Where(x => x.Fate == 'A').Count();
            Console.WriteLine($"Attacked planets: {count}");

            foreach (Planet planet in data.Where(x => x.Fate == 'A').OrderBy(x => x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            count = data.Where(x => x.Fate == 'D').Count();
            Console.WriteLine($"Destroyed planets: {count}");

            foreach (Planet planet in data.Where(x => x.Fate == 'D').OrderBy(x => x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }

        private static string Decripting(string code)
        {
            int decounter = 0;

            foreach (var symbol in code.ToLower())
            {
                if (symbol == 's' || symbol == 't' || symbol == 'a' || symbol == 'r')
                {
                    decounter++;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var symvol in code)
            {
                sb.Append((char)(symvol - decounter));
            }

            string result = sb.ToString();
            return result;
        }
    }
    class Planet
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public char Fate { get; set; }
        public long Soldiers { get; set; }

        public Planet(string name, long pupulation, char fate, long soldiers)
        {
            this.Name = name;
            this.Population = pupulation;
            this.Fate = fate;
            this.Soldiers = soldiers;
        }
    }
}