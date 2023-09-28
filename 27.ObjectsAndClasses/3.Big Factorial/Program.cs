using System.Numerics;

namespace Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            BigInteger P = 1;

            for (int i = x; i >= 1; i--)
            {
               P *= i;
            }

            Console.WriteLine(P);
            

        }
    }
}