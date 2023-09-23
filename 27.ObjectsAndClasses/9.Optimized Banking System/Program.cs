namespace Optimized_Banking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> data = new List<BankAccount>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                data.Add(BankAccount.ParseData(input));
            }

            data.OrderByDescending(x => x.Balance)
                .ThenBy(x => x.Bank.Length)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} -> {x.Balance} ({x.Bank})"));
        }

        class BankAccount
        {
            public string Name { get; set; }
            public string Bank { get; set; }
            public decimal Balance { get; set; }

            public BankAccount(string name, string bank, decimal balance)
            {
                Name = name;
                Bank = bank;
                Balance = balance;
            }

            public static BankAccount ParseData(string input)
            {
                string[] inputArg = input.Split(" | ");

                decimal balance = decimal.Parse(inputArg[2]);

                return new BankAccount(inputArg[1], inputArg[0], balance);
            }

        }
    }
}