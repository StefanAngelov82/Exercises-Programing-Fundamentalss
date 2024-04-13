namespace FilterCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int>() {1, 5, 17, 11, 2 ,6 , 15, };

            Console.WriteLine(string.Join(" ", Filter(num, x => x > 7)));
        }

        public static List<int> Filter(
                List<int> numbers,
                Func<int, bool> filter)
        {
            var result = new List<int>();

            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}