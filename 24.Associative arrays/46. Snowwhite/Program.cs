namespace _4._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> data = new List<Dwarf>();   

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                Dwarf current = Dwarf.DataParse(input);

                if (!data.Contains(current))
                {
                    data.Add(current);
                }
                else
                {
                    Dwarf existing = data.FirstOrDefault(x => x.Name == current.Name && x.HatColor == current.HatColor);
                    
                    existing.Physics = Math.Max(current.Physics, existing.Physics);
                }
            }

            foreach (Dwarf f in data
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => data.Count(y => y.HatColor == x.HatColor)))
            {
                Console.WriteLine($"({f.HatColor}) {f.Name} <-> {f.Physics}");
            }
        }
    }
    class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

        public Dwarf(string name, string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Dwarf)
            {
                Dwarf other = (Dwarf)obj;

                return this.Name == other.Name &&
                       this.HatColor == other.HatColor;
            }

            return false;
        }

        public static Dwarf DataParse(string input)
        {
            string[] inputArg = input.Split(" <:> ");

            return new Dwarf(inputArg[0], inputArg[1], int.Parse(inputArg[2]));
        }
    }
}