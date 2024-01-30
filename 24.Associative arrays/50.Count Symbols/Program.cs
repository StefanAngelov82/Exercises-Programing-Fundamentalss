namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> data = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var symbol in input)
            {
                if (!data.ContainsKey(symbol))
                {
                    data[symbol] = 0;
                }

                data[symbol]++;
            }

            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}