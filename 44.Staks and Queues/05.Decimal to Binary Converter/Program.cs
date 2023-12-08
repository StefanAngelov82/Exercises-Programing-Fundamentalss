using System.Text;

namespace Decimal_to_Binary_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

           if (number == 0)
           {
                Console.WriteLine(0);
           }
           else
           {
                while (number > 0)
                {
                    stack.Push(number%2);
                    number /= 2 ;
                }
           }

            StringBuilder sb = new StringBuilder();

            while (stack.Count != 0)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());

            string result = sb.ToString();
            int counter = 0;

            for (int i = 3; i < result.Length; i += 3)
            {                
                string firsPart = result.Substring(0, i);
                string secondPart = result.Substring(i);

                result = firsPart + "_" + secondPart;
                i++;
            }

            Console.WriteLine(result);
        }
    }
}