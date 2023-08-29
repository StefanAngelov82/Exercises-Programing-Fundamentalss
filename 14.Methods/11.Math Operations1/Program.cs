using System;

namespace Math_Operations1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double y =int.Parse(Console.ReadLine());
            double result = 0;

            switch (symbol)
            {
                case '*':
                    result = Multyply(x, y);
                    break;
                case '/':
                    result = Divide(x, y);
                    break;
                case '+':
                    result = Add(x, y);
                    break;
                case '-':
                    result = Substract(x, y);
                    break;
            }
            static double Multyply(double x, double y)
            {
                double result = x * y;
                return result;
            }
            static double Divide(double x, double y)
            {
                double result = x / y;
                return result;
            }
            static double Substract(double x, double y)
            {
                double result = x - y;
                return result;
            }
            static double Add(double x, double y)
            {
                double result = x + y;
                return result;
            }
            Console.WriteLine(result);
        }
    }
}
