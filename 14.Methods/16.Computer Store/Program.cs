using System;

namespace Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            double totalSum = 0;

            while ((input = Console.ReadLine()) != "special" && input != "regular")
            {
                double currentPrice = double.Parse(input);

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                totalSum += currentPrice;
            }

            if (totalSum == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double tax = totalSum * 0.2;

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalSum:F2}$");
            Console.WriteLine($"Taxes: {tax:F2}$");

            Console.WriteLine("-----------");

            if (input == "regular")
            {
                Console.WriteLine($"Total price: {totalSum + tax:F2}$");
            }
            else
            {
                Console.WriteLine($"Total price: {(totalSum + tax) * 0.9:F2}$");
            }
        }
    }
}
