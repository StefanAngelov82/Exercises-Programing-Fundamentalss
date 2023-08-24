using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Character_Delimiter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> letters = Console.ReadLine()
                .Split(" ")
                .ToList();

            int totalSum = 0;
            int counter = 0;

            for (int i = 0; i < letters.Count; i++)
            {
                string word = letters[i];

                foreach (var charecter in word)
                {
                    totalSum += (int)charecter;
                    counter++;
                }
            }
            string delimiter = ((char)(totalSum / counter)).ToString().ToUpper();

            Console.WriteLine(string.Join(delimiter, letters));           
        }
    }
}
