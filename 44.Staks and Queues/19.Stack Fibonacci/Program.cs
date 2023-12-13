using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Stack<int> fib = new Stack<int>();
           
            fib.Push(1);
            fib.Push(1);

            for (int i = 0; i < N - 2; i++)
            {
                int lastNumber = fib.Pop();
                int previousNumber = fib.Peek();                
                int newNumber = previousNumber + lastNumber;

                fib.Push(lastNumber);
                fib.Push(newNumber);
            }

            
                Console.WriteLine(fib.Peek());
            
            
        }
    }
}
