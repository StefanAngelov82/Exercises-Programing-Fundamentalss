using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, double> data = new Dictionary<string, double>();

            while ((input = Console.ReadLine()) is not "Purchase")
            {
                string pattern = @">>(?<furniture>\w+)<<(?<price>[\d.]+)!(?<quantity>\d+)";

                Match matches = Regex.Match(input, pattern); 

                if (matches.Success)
                {
                    string furniture = matches.Groups[1].Value;
                    double moneySpend = double.Parse(matches.Groups[2].Value) * double.Parse(matches.Groups[3].Value);

                    if (!data.ContainsKey(furniture))
                    {
                        data[furniture] = 0;
                    }

                    data[furniture] += moneySpend;
                }                
            }

            double totalprice = 0;

            Console.WriteLine("Bought furniture:");

            foreach (var item in data)
            {
                Console.WriteLine(item.Key);
                totalprice += item.Value;
            }

            Console.WriteLine($"Total money spend: {totalprice:F2}");
        }
    }
}