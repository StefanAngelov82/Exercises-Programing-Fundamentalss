using System.Reflection.Metadata;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input.Reverse());

            int sum = int.Parse(stack.Pop());

            while (stack.Count != 0 )
            {                
                string symbol = stack.Pop();
                int number = int.Parse(stack.Pop());

                if (symbol == "+")
                {
                    sum += number;
                }
                else
                {
                    sum -= number;
                }
            }

            Console.WriteLine(sum);
        }
    }
}