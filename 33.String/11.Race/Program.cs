using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> data = new List<Person>();

            string[] names = Console.ReadLine().Split(", ");

            string input = String.Empty;

            string lettersPattern = @"[A-Za-z]";
            string digitPattern = @"[0-9]";            

            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder bl = new StringBuilder();

                foreach (Match match in Regex.Matches(input, lettersPattern))
                {
                    bl.Append(match.Value);                    
                }

                string name = bl.ToString();
                int distance = 0;

                foreach (Match match in Regex.Matches(input, digitPattern))
                {
                    distance += int.Parse(match.Value);
                }

                if (!names.Contains(name))
                {
                    continue;
                }

                Person current = new Person(name, distance);

                if (!data.Contains(current))
                {
                    data.Add(current);
                }
                else
                {
                    Person target = data.FirstOrDefault(x => x.Name == current.Name);

                    target.Distance += current.Distance;
                }
            }

            int ch = 1;
            string[] fix = new string[] {"st","nd","rd"};

            foreach (var person in data.OrderByDescending(x =>x.Distance).Take(3))
            {
                Console.WriteLine($"{ch}{fix[ch - 1]} place: {person.Name}");
                ch++;
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Distance { get; set; }

        public Person(string name, int distance)
        {
            this.Name = name;
            this.Distance = distance;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person)
            {
                Person other = (Person)obj;

                return this.Name == other.Name;
            }

            return false;
        }

    }
}