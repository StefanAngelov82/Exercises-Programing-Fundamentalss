namespace Sales_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Sales> data = new List<Sales>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                data.Add(Sales.ParseData(Console.ReadLine()));
            }

            Dictionary<string, double> totalSales = new Dictionary<string, double>();

            foreach (var sale in data)
            {
                if (!totalSales.ContainsKey(sale.Town))
                {
                    totalSales[sale.Town] = 0;
                }

                totalSales[sale.Town] += sale.Price * sale.Quantity;
            }

            foreach (var kvp in totalSales.OrderBy(x =>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }
    }
    class Sales
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }


        public  Sales(string townName, string productName, double pricePerProduct, double productQuantity)
        {
            Town = townName;
            Product = productName;
            Price = pricePerProduct;
            Quantity = productQuantity;
        }

        public static Sales ParseData(string input)
        {
            string[] args = input.Split(' ');

            double price = double.Parse(args[2]);
            double quantity = double.Parse(args[3]);

            return new Sales(args.First(), args.Skip(1).First(), price, quantity);
        }
    }

}