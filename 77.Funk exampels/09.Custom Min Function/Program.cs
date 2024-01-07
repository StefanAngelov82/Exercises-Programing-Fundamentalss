namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> MinValue = number => number.Min();
                
            Console.WriteLine(MinValue(numbers));
        }
    }
}