namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> data = new Dictionary<string, long>();

            string input = String.Empty;
            String input2 = String.Empty;           

            while ((input = Console.ReadLine()) != "stop")
            {
                input2 = Console.ReadLine();

                if (!data.ContainsKey(input))
                {
                    data[input] = 0;
                }

                data[input] += long.Parse(input2);
            }

            foreach ( var kvp in data)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}