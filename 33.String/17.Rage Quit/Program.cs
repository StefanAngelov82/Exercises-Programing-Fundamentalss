using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text  = Console.ReadLine();           

            string pattern = @"(?<symbols>[\D]+)(?<digit>[\d]+)";

            StringBuilder sb = new StringBuilder();

            foreach (Match match in Regex.Matches(text, pattern))
            {
                int N = int.Parse(match.Groups[2].Value);

                string symbols = (match.Groups[1].Value).ToUpper();

                for (int i = 0; i < N; i++)
                {
                    sb.Append(symbols);
                }               
            }

            Console.WriteLine($"Unique symbols used: {sb.ToString().Distinct().Count()}");
            Console.WriteLine(sb.ToString());
        }
    }
}