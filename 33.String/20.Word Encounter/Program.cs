using System.Text.RegularExpressions;

namespace Word_Encounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            char symbol = key[0];
            int N = int.Parse(key[1].ToString());

            string input = String.Empty;

            List<string> output = new List<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                Regex reg = new Regex(@"^[A-Z](.*)[?!.]$");

                if (reg.IsMatch(input))
                {
                    foreach (Match match in Regex.Matches(input, @"[A-Za-z]+"))
                    {
                        if (match.Value.Count(x => x == symbol) == N)
                        {
                            output.Add(match.Value);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}