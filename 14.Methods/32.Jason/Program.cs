namespace Jason
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "stringify")
            {
                string[] inputArg = input
                    .Split(new string[] { ":", " ", "-", ">", ", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);
                int[] grades = inputArg
                    .Skip(2)
                    .Select(int.Parse)
                    .ToArray();

                Student st = new Student(name, age, grades);
                students.Add(st);
            }
            int count = 0;
            Console.Write("[");
            foreach (var st in students)
            {
                count++;
                Console.Write($"{{name:\"{st.Name}\",age:{st.Age},grades:[{string.Join(", ", st.Grades)}]}}");

                if (count != students.Count)
                {
                    Console.Write(",");
                }

            }
            Console.WriteLine("]");
        }
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int[] Grades { get; set; }

            public Student(string name, int age, int[] grades)
            {
                this.Name = name;
                this.Age = age;
                this.Grades = grades;
            }
        }
    }
}