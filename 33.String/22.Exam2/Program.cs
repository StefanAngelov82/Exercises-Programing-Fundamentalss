using System.Text.RegularExpressions;

namespace Exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();

                string pattren = @"\|(?<name>[A-Z][A-Z][A-Z][A-Z]+)\|:\#(?<title>[A-Za-z]+\s[A-ZA-z]+)\#";

                Regex reg = new Regex(pattren);

                if (reg.IsMatch(text))
                {
                   foreach (Match m in reg.Matches(text))
                   {
                        Console.WriteLine($"{m.Groups["name"].Value}, The {m.Groups["title"].Value}");
                        Console.WriteLine($">> Strength: {m.Groups["name"].Value.Length}");
                        Console.WriteLine($">> Armor: {m.Groups["title"].Value.Length}");
                   }
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}