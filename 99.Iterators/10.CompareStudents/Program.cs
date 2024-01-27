namespace CompareStudents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student( 3.76, "Pesho");
            Student st2 = new Student( 3.70, "Asan");


            Console.WriteLine(st1.CompareTo(st2) == 1 ? "Pesho is the best" : "Asan is the Best");
        }
    }
} 