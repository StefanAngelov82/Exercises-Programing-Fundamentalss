using System.Reflection.Metadata;
using System.Text;

namespace Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();   
            
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}