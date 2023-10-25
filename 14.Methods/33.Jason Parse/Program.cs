using System.Text;

namespace Jason_Parse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] input = Console.ReadLine().Trim('[',']','{','}').Split("},{");

            for(int i = 0; i < input.Length; i++)
            {
                Student st = Student.ParseData(input[i]);

                students.Add(st);
            }

            foreach(Student str in students)
            {
                Console.WriteLine($"{str.Name} : {str.Age} -> {str.Grades}");
            }
        }
       
    }
    class Student
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Grades { get; set; }

        public Student(string name, string age, string grades)
        {
            Name = name;
            Age = age;
            Grades = grades;
        }

        public static Student ParseData(string input)
        {
            string[] inputArg = input.Trim('{','}').Split(':', StringSplitOptions.RemoveEmptyEntries);

            string[] names = inputArg[1].Split(',');
            string[] ages = inputArg[2].Split(',');

            string name = names[0].Trim('"');
            string age = ages[0];
            string grades = inputArg[3].Trim('[',']');

            if (grades == "")
            {
                grades = "None";
            }

            return new Student(name, age, grades);
        }

    }
}