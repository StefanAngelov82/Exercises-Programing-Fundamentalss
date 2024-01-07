namespace Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> filter = (x) => x.Length <= length;

            names.Where(x => filter(x)).ToList().ForEach(x => Console.WriteLine($"{x}"));
        }
    }
}