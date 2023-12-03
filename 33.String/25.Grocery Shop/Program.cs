using System.Text.RegularExpressions;

namespace Grocery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> data = new Dictionary<string, double>();

            string pattern = @"(?<name>^[A-Z][a-z]+):(?<prive>\d+\.\d{2})$";
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "bill")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string productName = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);

                    if (!data.ContainsKey(productName))
                    {
                        data[productName] = 0;
                    }

                    data[productName] = price;
                }
            }

            data.OrderByDescending(x => x.Value)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} costs {x.Value}"));
        }
    }
}