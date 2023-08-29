using System;

namespace Math_Power1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine(Pow(x , y));
        }

        static double Pow(double x, double y)
        {
            double result = Math.Pow(x, y);
            return result;
        }
    }
}
