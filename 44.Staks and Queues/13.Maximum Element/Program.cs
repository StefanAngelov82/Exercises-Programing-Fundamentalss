﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Maximum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N =int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "1")
                {
                    stack.Push(int.Parse(input[1]));
                }
                else if (input[0] == "2")
                {
                    if (stack.Count > 0) 
                       stack.Pop();                   
                   
                }
                else
                {
                    if (stack.Count > 0 )                    
                       Console.WriteLine(stack.Max());                   
                }
            }
        }
    }
}
