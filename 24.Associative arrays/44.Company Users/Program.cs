namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Company> data = new List<Company>();   

            while ((input = Console.ReadLine()) is not "End")
            {
                string[] inputArg = input.Split(" -> ");

                string name = inputArg[0];
                string id = inputArg[1];

                Company newcomp = new Company(name);

                if (!data.Contains(newcomp))
                {
                    data.Add(newcomp);
                }

                int index = data.IndexOf(newcomp);

                if (!data[index].Id.Contains(id))
                {
                    data[index].Id.Add(id);
                }
                              
            }


            foreach (Company comp in data.OrderBy(x => x.Name))
            {
                Console.WriteLine(comp.Name);

                foreach (var item in comp.Id)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
    class Company
    {
        public string Name { get; set; }       

        public List<string> Id { get; set; }

        public Company (string name)
        {
            this.Name = name;
            this.Id = new List<string>(); 
        }

        public override bool Equals(object? obj)
        {
            if (obj is Company)
            {
                Company other = (Company)obj;

                return this.Name == other.Name;
            }

            return false;
        }
    }
}