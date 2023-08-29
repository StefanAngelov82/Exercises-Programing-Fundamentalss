using System;
using System.Xml;

namespace Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            if (comand == "int")
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                GetMax(x, y);
            }
            else if (comand == "char")
            {
                char x = char.Parse(Console.ReadLine());
                char y = char.Parse(Console.ReadLine());
                GetMax(x, y);
            }
            else
            {
                string x = Console.ReadLine();
                string y = Console.ReadLine();
                GetMax(x, y);
            }

            

        }
        static void GetMax(int x, int y)
        {
            int resulut = Math.Max(x, y);

            Console.WriteLine(resulut);           
        }
        static void GetMax(char x, char y)
        {
            char resulut  = (char)Math.Max(x, y);

            Console.WriteLine(resulut);
        }
        static void GetMax(string x, string y)
        {
            int result = x.CompareTo(y);

            if (result > 0 ) Console.WriteLine(x);
            else             Console.WriteLine(y);
        }
    }
}
