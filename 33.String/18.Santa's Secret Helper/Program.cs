using System.Text;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string text = String.Empty;

            List<string> list = new List<string>();

            while ((text = Console.ReadLine()) != "end")
            {

                StringBuilder sb = new StringBuilder();

                foreach (var symbol in text)
                {
                    sb.Append((char)(symbol - N));
                }

                text = sb.ToString();

                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<grade>[G|N])!";

                foreach (Match match in Regex.Matches(text, pattern))
                {
                    if (match.Groups["grade"].Value == "G")
                    {
                        list.Add(match.Groups["name"].Value);
                    }
                }                
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}