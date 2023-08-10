using System;
using System.Collections.Generic;

namespace Split_by_Word_Casing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] delimiters = {",", ";", ":", ".", "\"", "\'", "!", "(", ")", "\\", "/", "[", "]", " "};
            string[] words = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            List<string> LowerCase = new List<string>();
            List<string> UpperCase = new List<string>();
            List<string> MixedCase = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                int number;
                if (words[i] == words[i].ToLower() && !(int.TryParse(words[i], out number)))
                {
                    LowerCase.Add(words[i]);
                }
                else if (words[i] == words[i].ToUpper() && !(int.TryParse(words[i], out number)))
                {
                    UpperCase.Add(words[i]);
                }
                else
                {
                    MixedCase.Add(words[i]);
                }
            }
            Console.Write("Lower-case: ");
            Console.WriteLine(string.Join(", ", LowerCase));
            Console.Write("Mixed-case: ");
            Console.WriteLine(string.Join(", ", MixedCase));
            Console.Write("Upper-case: ");
            Console.WriteLine(string.Join(", ", UpperCase));
            
        }
    }
}

