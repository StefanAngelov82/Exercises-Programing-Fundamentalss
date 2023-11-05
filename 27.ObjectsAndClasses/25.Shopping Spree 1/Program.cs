using System.Runtime.CompilerServices;
using System.Text;

namespace Shopping_Spree_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> peoples = new List<Person>(Person.DataParse(input));

            input = Console.ReadLine(); 

            List<Product>products = new List<Product>(Product.DataParse(input));

            while ((input = Console.ReadLine()) is not "END")
            {
                Buy(input, peoples, products);
            }

            foreach (var person in peoples)
            {
                Console.WriteLine(person);
            }
        }

        static void Buy(string input, List<Person> peoples, List<Product> products)
        {
            string[] inputArg = input.Split();

            string name = inputArg[0];
            string product = inputArg[1];

            Person currentPerson = peoples.FirstOrDefault(x => x.Name == name);
            Product currentProduct = products.FirstOrDefault(x => x.Name == product);

            if (currentPerson is not null && currentProduct is not null)
            {
                currentPerson.Purchasing(currentProduct);
            }            
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> Bag { get; set; }

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public static List<Person> DataParse(string input)
        {
            List<Person> list = new List<Person>();
             
            string[] inputArg = input.Split('=', ';');

            for (int i = 0; i < inputArg.Length; i += 2)
            {
                string name = inputArg[i];
                double money = double.Parse(inputArg[i + 1]);

                list.Add(new Person(name, money));
            }

            return list;
        }

        public void Purchasing(Product currentproduct)
        {
            if (this.Money >= currentproduct.Price)
            {
                this.Money -= currentproduct.Price;

                this.Bag.Add(currentproduct);

                Console.WriteLine($"{this.Name} bought {currentproduct.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {currentproduct.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name} - ");

            if (this.Bag.Count > 0)
            {
                int count = 1;

                foreach (var product in this.Bag)
                {
                    if (count != this.Bag.Count)
                    {
                        sb.Append($"{product.Name}, ");
                    }
                    else
                    {
                        sb.Append($"{product.Name}");
                    }

                    count++;
                }
            }
            else
            {
                sb.Append($"Nothing bought");
            }

            return sb.ToString().TrimEnd();
        }

    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public static List<Product> DataParse(string input)
        {
            List<Product> list = new List<Product>();

            string[] inputArg = input.Split(new char[] {';','='}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputArg.Length; i += 2)
            {
                string name = inputArg[i];
                double price = double.Parse(inputArg[i + 1]);

                list.Add(new Product(name, price));
            }

            return list;
        }
    }

}