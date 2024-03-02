using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Person
    {

		private string name;
        private double money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
			this.bagOfProducts = new List<Product>();
        }

        public string Name
		{
			get { return name; }

			private set 
			{ 
				if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value; 
			}
		}		
				
		public double Money
		{
			get { return money; }

			private set 
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				money = value; 
			}
		}
        public IReadOnlyCollection<Product> BagOfProducts
		{
            get => bagOfProducts.AsReadOnly();
        }		


        public string BuYProduct(Product product)
		{
            if (this.Money >= product.Cost )
            {
				bagOfProducts.Add(product);
				this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }
	}
}
