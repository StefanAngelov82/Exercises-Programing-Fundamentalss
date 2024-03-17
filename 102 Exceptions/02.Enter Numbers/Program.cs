namespace Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int[] numbers = new int[10];
            int start = 1;
            int end = 100;


            while (counter != 10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());

                    if ((number <= start || number >= end))
                    {
                        throw new ArgumentOutOfRangeException(null, $"Your number is not in range ({start} - {end})!");
                    }

                    start = number;
                    numbers[counter] = number;
                    counter++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}