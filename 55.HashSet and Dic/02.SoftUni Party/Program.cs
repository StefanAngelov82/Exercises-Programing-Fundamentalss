using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();    
            HashSet<string> ordinary = new HashSet<string>();    

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        VIP.Add(input);
                    }
                    else
                    {
                        ordinary.Add(input);
                    }
                }
            }           

            while ((input = Console.ReadLine()) != "END")
            {
                if (VIP.Contains(input))
                {
                    VIP.Remove(input);
                }

                if (ordinary.Contains(input))
                {
                    ordinary.Remove(input);
                }
            }

            Console.WriteLine((VIP.Count + ordinary.Count));

            foreach (string gest in VIP)
            {
                Console.WriteLine(gest);
            }

            foreach (var gest in ordinary)
            {
                Console.WriteLine(gest);
            }    
;       }
    }
}
