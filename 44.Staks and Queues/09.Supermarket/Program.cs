namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> data = new Queue<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    data.Enqueue(input);
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, data));

                    data.Clear();
                }
            }

            Console.WriteLine($"{data.Count} people remaining.");
        }
    }
}