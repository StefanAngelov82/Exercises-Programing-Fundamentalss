namespace Knights_of_Honor1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> filter = AddiningPrefix();
            Array.ForEach(names, filter);
        }

        private static Action<string> AddiningPrefix()
        {
            return x => Console.WriteLine($"Sir {x}");
        }
    }
}