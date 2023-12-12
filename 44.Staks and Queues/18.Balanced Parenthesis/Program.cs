using System;
using System.Collections.Generic;

namespace Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> one = new Stack<char>();

            foreach (var symbol in text)
            {
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    one.Push(symbol);
                }
                else
                {
                    if (one.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        char symbol2 = one.Pop();
                        string result = symbol2.ToString() + symbol.ToString();

                        if (result != "()" && result != "[]" && result != "{}")
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("YES");
        }
          
    }
}
