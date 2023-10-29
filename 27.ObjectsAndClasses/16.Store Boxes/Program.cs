namespace Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Box> data = new List<Box>();

            while ((input = Console.ReadLine()) is not "end")
            {                
                Box currentBox = Box.ParseData(input);   
                data.Add(currentBox);
            }

            foreach (Box box in data.OrderByDescending(x => x.PriceOfBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceOfBox:F2}");
            }

        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    class  Box
    {
        
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity  { get; set; }

        public decimal PriceOfBox
        {
            get
            {
                return ItemQuantity * Item.Price ;
            }
        }        


        public Box (int serialNumber, string name, decimal itemPrice, int itemQuantity)
        {

            this.SerialNumber = serialNumber;
            this.Item = new Item(name, itemPrice);
            this.ItemQuantity = itemQuantity;            
        }  
        
        public static Box ParseData(string input)
        {
            string[] inputArg = input.Split();

            int serialNumber = int.Parse(inputArg[0]);
            string name = inputArg[1];
            decimal itemPrice = decimal.Parse(inputArg[3]);
            int itemQuantity = int.Parse(inputArg[2]);

            return new Box(serialNumber, name, itemPrice, itemQuantity);
        }
    }
}