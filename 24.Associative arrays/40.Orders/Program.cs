using System.Security.Cryptography.X509Certificates;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> data = new Dictionary<string, Product>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) is not "buy")
            {
                Product currentProduct = Product.DataParse(input);

                if (!data.ContainsKey(currentProduct.Name))
                {
                    data[currentProduct.Name] = currentProduct; 
                }
                else
                {
                    data[currentProduct.Name].Price = currentProduct.Price;
                    data[currentProduct.Name].Quantity += currentProduct.Quantity;
                }               
            }

            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Quantity * kvp.Value.Price:F2}");
            }
        }


    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public static Product DataParse(string input)
        {
            string[] inputArg = input.Split();

            string name = inputArg[0];
            double price = double.Parse(inputArg[1]);
            int quantity = int.Parse(inputArg[2]);

            return new Product(name, price, quantity);

        }
    }
}