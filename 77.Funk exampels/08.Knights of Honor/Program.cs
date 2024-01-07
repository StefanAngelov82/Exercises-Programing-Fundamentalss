namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Func<string, string> printName = name => "Sir " + name;

            Array.ForEach(names, name => Console.WriteLine(printName(name)));
        }
    }
}