namespace List_of_Predicates2
{
    internal class Program
    {
        public delegate bool Filter(int number);

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Filter IsDivided = Divided(divisors);

            int[] numbers = new int[N];

            for (int i = 0; i < numbers.Length; i++)            
                numbers[i] = i + 1;

            Console.WriteLine(string.Join(" ", numbers.Where(x => IsDivided(x))));

        }

        private static Filter Divided(int[] divisors)
        {
            Predicate<int> predicate =
                (x) =>
                {
                    for (int i = 0; i < divisors.Length; i++)
                    {
                        if (x % divisors[i] != 0)                        
                            return false;                        
                    }

                    return true;
                };

            return new Filter(predicate);
        }
    }
}