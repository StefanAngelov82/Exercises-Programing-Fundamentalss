namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int dev = int.Parse(Console.ReadLine());

            Action<int[]> reverse = (x) => Array.Reverse(x);

            reverse(numbers);

            Predicate<int> filter = (x) => x % dev != 0;

            numbers.Where(x => filter(x))
                .ToList()
                .ForEach(x => Console.Write($"{x} "));

        }
    }
}