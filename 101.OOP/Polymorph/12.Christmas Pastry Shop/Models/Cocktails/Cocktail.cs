using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value; 
            }
        }        

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }        

        protected Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }

        public double Price
        {
            get { return price; }
            private set 
            {
                if (Size == "Large")
                {
                    price = value;
                }

                if (Size == "Middle")
                {
                    price = (2.0 / 3) * value;
                }

                if (Size == "Small")
                {
                    price = (1.0 / 3) * value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }

    }
}
