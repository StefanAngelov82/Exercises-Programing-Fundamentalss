using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            decimal totalImcome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*?<(?<product>\w+)>[^|$%.]*?\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+(?:\.\d+)?)\$";

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    decimal totalPrice = count * price;
                    totalImcome += totalPrice;
                    
                    Console.WriteLine($"{customer}: {product} - {totalPrice:F2}");
                }
            }

            Console.WriteLine($"Total income: {totalImcome:F2}");
        }
    }
   
}