namespace Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Action<string> print = x => Console.WriteLine(x);

            names.ForEach(print);
        }
    }
}