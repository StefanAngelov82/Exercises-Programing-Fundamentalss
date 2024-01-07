namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] range = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            List<long> numbers = new List<long>();

            for (long i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            string Input = Console.ReadLine();

            Predicate<long> isRequired =
                (x) =>
                {
                    if (Input == "even") return Math.Abs(x) % 2 == 0;
                    else                 return Math.Abs(x) % 2 == 1;                    
                };

            numbers.Where(x => isRequired(x)).ToList().ForEach(x => Console.Write($"{x} "));
        }
    }
}