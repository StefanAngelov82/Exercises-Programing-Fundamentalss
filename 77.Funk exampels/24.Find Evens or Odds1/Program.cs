namespace Find_Evens_or_Odds1
{
    internal class Program
    {
        public delegate bool Filter(int number);

        static void Main(string[] args)
        {
            int[] borders = Console.ReadLine().Split().Select(int.Parse).ToArray();  
            
            int start = borders[0];
            int end = borders[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string oddOrEven = Console.ReadLine();

            Filter filter = FilterinNumbers(oddOrEven);

            Console.WriteLine(string.Join(" ", numbers.Where(x =>filter(x))));
        }

        private static Filter FilterinNumbers(string oddOrEven)
        {
            Predicate<int> filter =
                (x) =>
                {
                    if (oddOrEven == "odd") return x % 2 != 0;
                    else return x % 2 == 0;

                };

            return new Filter(filter);
        }
    }
}