using System;
using System.Collections.Generic;

namespace TakeSkip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> code = new List<char>();
            List<int> digits = new List<int>();
            List<string> letters = new List<string>();

            code.AddRange(Console.ReadLine());

            for (int i = 0; i < code.Count; i++)
            {
                if (char.IsDigit(code[i]))
                {
                    digits.Add(int.Parse(code[i].ToString()));
                }
                else
                {
                    letters.Add(code[i].ToString());
                }
            }

            List<int> TakeList = new List<int>();
            List<int> SkipList = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    TakeList.Add(digits[i]);
                }
                else
                {
                    SkipList.Add(digits[i]);
                }
            }

            List<string> result = new List<string>();

            int counter = 0;

            for (int i = 0; i < TakeList.Count; i++)
            {
                for (int j = counter; j < (counter + TakeList[i]); j++)
                {
                    if (j > letters.Count - 1)
                    {
                        break;
                    }

                    result.Add(letters[j]);
                }

                counter += (TakeList[i] + SkipList[i]);
            }

            Console.WriteLine(String.Join("", result));

        }
    }
}
