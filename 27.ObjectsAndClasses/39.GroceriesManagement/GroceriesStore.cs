using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }


        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity && !Stall.Contains(product))
                Stall.Add(product);
        }

        public bool RemoveProduct(string name)
        {
            Product? target = Stall.FirstOrDefault(x => x.Name == name);

            if (target == null)
                return false;

            return Stall.Remove(target); 
        }

        public string SellProduct(string name, double quantity)
        {
            Product? target = Stall.FirstOrDefault(x => x.Name == name);

            if (target == null)
                return "Product not found";

            double totalPrice = Math.Round(target.Price * quantity, 2);

            this.Turnover += totalPrice;
            return $"{target.Name} - {totalPrice:F2}$";
        }

        public string GetMostExpensive()
        {
            Product target = Stall.OrderByDescending(x => x.Price).First();
            return target.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Groceries Price List:");

            foreach (var item in Stall)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
