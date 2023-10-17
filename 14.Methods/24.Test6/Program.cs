using System;
using System.Globalization;

namespace Test6
{
    internal class Program
    {
        static void Main(string[] args)
        { int i, j;
            int[] x = { 1, 2, 3, 4, 5};
            int[] y = x[0..3];
            int[] z = x[3..];
            int[] w = new int[x.Length];

            for (i = 0; i < y.Length; i++)
            {
                w[i] = y[i];
            }
            
           for (j  = i; j < x.Length; j++)
            {
                w[j] = z[j - i];
            }

            foreach (var item in w)
            {
                Console.WriteLine(item);
            }
        }
    }
}
