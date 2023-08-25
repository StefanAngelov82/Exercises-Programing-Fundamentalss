using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> wards = Console.ReadLine()
                .Split(' ')
                .ToList();

            bool swapped; 

            do 
            {
                swapped = false;

                for (int i = 0; i < wards.Count - 1; i++)
                {
                    int result = wards[i].CompareTo(wards[i + 1]);

                    if ((wards[i].ToUpper() == wards[i + 1]))
                    {
                        string temp = wards[i];
                        wards[i] = wards[i + 1];
                        wards[i + 1] = temp;
                    }

                    if (result > 0)
                    {
                        string temp = wards[i];
                        wards[i] = wards[i + 1];
                        wards[i + 1] = temp;

                        swapped = true;
                    }                    
                }                
            } while (swapped);

            Console.WriteLine(string.Join(" ", wards));
        }
    }
}
