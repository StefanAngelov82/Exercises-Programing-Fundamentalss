using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] personInput = Console.ReadLine().Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < personInput.Length; i += 2)
                {
                    string name = personInput[i];
                    double money = double.Parse(personInput[i + 1]);

                    peoples.Add(new Person(name, money));
                }

                string[] productsInput = Console.ReadLine().Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    string name = productsInput[i];
                    double cost = double.Parse(productsInput[i + 1]);

                    products.Add(new Product(name, cost));
                }

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArg = command.Split();

                    Person? person1 = peoples.FirstOrDefault(x => x.Name == commandArg[0]);
                    Product? product1 = products.FirstOrDefault(x => x.Name == commandArg[1]);

                    //if (person1 != null && product1 != null)
                    {
                        Console.WriteLine(person1.BuYProduct(product1));
                    }
                }

                foreach (var person1 in peoples)
                {
                    if (person1.BagOfProducts.Count > 0)
                    {
                        Console.WriteLine($"{person1.Name} - {string.Join(", ", person1.BagOfProducts)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person1.Name} - Nothing bought");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }
    }
}