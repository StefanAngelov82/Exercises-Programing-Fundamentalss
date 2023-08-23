using System;

namespace Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repitition = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input, repitition));
        }

        static string RepeatString(string input, int repitition)
        {
            string result = String.Empty;

            for (int i = 0; i < repitition; i++)
            {
                result += input;
            }

            return result;
        }

    }
}
