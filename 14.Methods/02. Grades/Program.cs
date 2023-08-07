using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grades = double.Parse(Console.ReadLine());
            GradeEstimation(grades);
        }
        
        static void GradeEstimation(double grades)
        {
            if (grades >= 2 && grades < 3)  Console.WriteLine("Fail");
            else if (grades < 3.50)         Console.WriteLine("Poor");
            else if (grades < 4.50)         Console.WriteLine("Good");
            else if (grades < 5.50)         Console.WriteLine("Very good");
            else                            Console.WriteLine("Excellent");
        }
    }
}
