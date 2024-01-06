namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {           

            Func<string, bool> IsCapitalLetter = (string x) => (x.Length > 0) && (char.IsUpper(x[0]));

            Console.ReadLine()
                .Split()
                .Where(x => IsCapitalLetter(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }        
    }
}