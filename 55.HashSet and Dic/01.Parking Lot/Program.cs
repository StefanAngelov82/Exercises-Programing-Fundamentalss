using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split(", ");

                if (inputArg[0] == "IN")
                {
                    set.Add(inputArg[1]);
                }
                else
                {
                    set.Remove(inputArg[1]);
                }
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(String.Join(Environment.NewLine, set));
            }

        }
    }
}
