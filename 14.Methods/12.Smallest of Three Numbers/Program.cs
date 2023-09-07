using System;

namespace Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());

            MInValue(x, y, z);
        }

        static void MInValue(int x, int y, int z)
        {
            int minvalue = int.MaxValue;

            if (x < minvalue) minvalue = x;
            if (y < minvalue) minvalue = y;
            if (z < minvalue) minvalue = z;

            Console.WriteLine(minvalue);
        }
    }
}
