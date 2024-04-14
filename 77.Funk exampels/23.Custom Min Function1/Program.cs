namespace Custom_Min_Function1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = MINValue();            

            Console.WriteLine(minNumber(numbers));
        }

        public static Func<int[], int> MINValue()
        {
            Func<int[], int> min =
                 (x) =>
                 {
                     int MinValue = int.MaxValue;

                     foreach (int number in x)
                     {
                         if (MinValue > number)                       
                             MinValue = number;                         
                     }

                     return MinValue;
                 };

            return min;
        }
    }      
}