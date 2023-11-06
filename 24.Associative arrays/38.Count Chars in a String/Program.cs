namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();

            Dictionary<char, int> data = new Dictionary<char, int>();

            foreach (var symbol in text.Where(x => x is not ' '))
            {
                if (!data.ContainsKey(symbol))
                {
                    data[symbol] = 0;
                }

                data[symbol]++;
            }


            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}