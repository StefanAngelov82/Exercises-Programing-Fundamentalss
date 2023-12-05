using System.Text;
using System.Text.RegularExpressions;

namespace SoftUni_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Decrypt!")
            {
                int N = int.Parse(Console.ReadLine());                

                string pattern = @"^(?<partOne>\d+)(?<massage>[A-Za-z]+)(?<partTwo>[^A-Za-z]+)$";

                StringBuilder sb = new StringBuilder();

                foreach (Match matches in Regex.Matches(input, pattern))
                {
                    string text = matches.Groups["massage"].Value;

                    if (text.Length != N) break;                                 

                    foreach(char digit in text) 
                    {
                        int index;
                        bool success = int.TryParse(digit.ToString(), out index);

                        if (!success) continue;

                        if ((index) >= 0 && (index) < text.Length)
                        {
                            sb.Append(text[index]);
                        }
                    }

                    Console.WriteLine($"{text} = {sb.ToString()}");
                }                
            }
        }
    }
}