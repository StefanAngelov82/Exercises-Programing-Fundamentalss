using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace Extract_Emails1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=\s)[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]*@[A-Za-z0-9]+[A-Za-z0-9\.\-_]*[\.][A-Za-z0-9]+";
           

            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine(match.Groups[0].Value);
            }
        }
    }
}