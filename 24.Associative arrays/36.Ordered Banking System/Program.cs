namespace Ordered_Banking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, decimal>> bankData = new Dictionary<string, Dictionary<string, decimal>>();
            
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input.Split(" -> ");

                string bankName = inputArg[0];
                string deposant = inputArg[1];
                decimal accoutValue = decimal.Parse(inputArg[2]);

                if (!bankData.ContainsKey(bankName))
                {
                    bankData[bankName] = new Dictionary<string, decimal>();
                }

                if (!bankData[bankName].ContainsKey(deposant))
                {
                    bankData[bankName][deposant] = 0;
                }

                bankData[bankName][deposant] += accoutValue;               
            }

            bankData = bankData
                .OrderByDescending(x => x.Value.Values.Sum()).ThenByDescending(x => x.Value.Values.Max())
                .ToDictionary(x =>x.Key, y => y.Value);


            foreach (var bank in bankData.Keys)
            {
                foreach (var kvp in bankData[bank].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value} ({bank}) ");
                }
            }
        }
    }
}