using System;

namespace Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            double area = Area(x,y);

            Console.WriteLine(area);
        }

        static double Area(double x, double y)
        {
            double area =  x * y;

            return area;
        }
        static int Area(int x, int y)
        {
            int area = x * y;

            return area;
        }
    }
}
