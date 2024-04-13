using System.Threading.Channels;

namespace BYAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Students student = new() {Name = name, Age = age };

                students.Add(student);
            }

            string filterType = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Students, bool> filter = FilterGenerator(filterType, ageFilter);

           students = students.Where(x => filter(x)).ToList();

            Action<Students> formatter = FormatterGenerator(format);
            
            foreach (Students student in students)
            {
                formatter(student);
            }
           
        }

        public static Action<Students> FormatterGenerator(string format)
        {
            if (format == "name age")
            {
                return x => Console.WriteLine($"{x.Name} {x.Age}");
            }
            else if (format == "name")
            {
                return x => Console.WriteLine($"{x.Name}");
            }
            else
            {
                return x => Console.WriteLine($"{x.Age}");
            }
        }

        public static Func<Students, bool> FilterGenerator(string filterType, int filterAge)
        {
            Func<Students, bool> ageFilters = null;

            if (filterType == "older")
                ageFilters = (s) => s.Age >= filterAge;

            if (filterType =="younger")
                ageFilters = (s) => s.Age < filterAge;

            return ageFilters;

        }  
    }
}