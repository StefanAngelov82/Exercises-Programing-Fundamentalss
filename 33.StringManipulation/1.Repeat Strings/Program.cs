using System.Text;

namespace Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int copy = text[i].Length;

                for (int J = 0; J < copy; J++)
                {
                    sb.Append(text[i]);
                }
            }

            Console.WriteLine(sb.ToString());

            sb.Clear();
        }
    }
}