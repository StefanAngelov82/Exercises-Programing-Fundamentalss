namespace Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> data  = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

             data = data.Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", data));


        }
    }
}