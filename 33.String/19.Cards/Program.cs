using System.Text.RegularExpressions;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> data = new List<string>(); 

            string patterh = @"(?:[2-9JQKA]|10)[SHDC]";

            foreach (Match match in Regex.Matches(text, patterh))
            {
                data.Add(match.Value);
            }

            Console.WriteLine(string.Join(", ", data));
        }
    }
}