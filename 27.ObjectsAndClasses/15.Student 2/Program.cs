namespace Student_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> list = new List<Student>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                Student current = Student.InputParse(input);

                if (!list.Contains(current))
                {
                    list.Add(current);
                }
                else
                {
                    int index = list.IndexOf(current);

                    list[index].Age = current.Age;
                    list[index].Town = current.Town;
                }
            }

            input = Console.ReadLine();

            list.Where(x => x.Town == input)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} is {x.Age} years old."));
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Student(string firstName, string lastnName, int age, string town)
        {
            this.FirstName = firstName;
            this.LastName = lastnName;
            this.Age = age;
            this.Town = town;
        }

        public static Student InputParse(string input)
        {
            string[] inputArg = input.Split(' ');

            return new Student(inputArg[0], inputArg[1], int.Parse(inputArg[2]), inputArg[3]);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student)
            {
                Student other = (Student)obj;

                return  this.FirstName == other.FirstName &&
                        this.LastName == other.LastName;
            }

            return false;
        }
    }
}