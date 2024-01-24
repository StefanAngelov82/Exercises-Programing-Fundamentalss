namespace CustomEnumerator
{
    public class StartUp
    {
        static void Main()
        {
            SoftUni university = new SoftUni();

            university.AddStudent(new Students() {Name = "Pencho", Age = 25 });
            university.AddStudent(new Students() {Name = "Gancho", Age = 22 });


            foreach (var student in university)
            {
                Console.WriteLine($"{student.Name} => {student.Age}");
            }
        }
    }
}