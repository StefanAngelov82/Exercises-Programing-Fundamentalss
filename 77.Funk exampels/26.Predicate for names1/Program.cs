namespace Predicate_for_names1
{
    internal class Program
    {

        public delegate bool Filter(string name);

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Filter filter = Filtretion(N);

            names.Where(x => filter(x)).ToList().ForEach(x => Console.WriteLine(x));
        }

        static Filter Filtretion(int N)
        {
           Predicate<string> filter =
                (x) => x.Length <= N;

            return new Filter(filter);
        }
    }
}