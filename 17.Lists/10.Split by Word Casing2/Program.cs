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
                string currentword = words[i];
                int lowerCounter = 0;
                int uppercounter = 0;
                int mixcounter = 0;
                for (int j = 0; j < currentword.Length; j++)
                {
                    if (uppercounter != 0 && lowerCounter != 0)
                    {
                        mixcounter++;
                        break;
                    }
                    else if (currentword[j] >= 65 && currentword[j] < 91)
                    {
                        uppercounter++;
                    }
                    else if (currentword[j] >= 97 && currentword[j] < 123)
                    {
                        lowerCounter++;
                    }                
                    else
                    {
                        mixcounter++;
                        break;
                    }                    
                }
             
                if (uppercounter == 0 && lowerCounter !=0 && mixcounter == 0)
                {
                    LowerCase.Add(currentword);
                }
                else if(uppercounter != 0 && lowerCounter == 0 && mixcounter == 0)
                {
                    UpperCase.Add(currentword);
                }
                else
                {
                    MixedCase.Add(currentword);
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

