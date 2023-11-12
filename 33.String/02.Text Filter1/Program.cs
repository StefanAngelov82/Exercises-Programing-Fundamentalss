namespace Text_Filter1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filters = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

           foreach (string filter in filters)
           {
              text = text.Replace(filter, new string('*', filter.Length));
           }

            Console.WriteLine(text);
        }

    }
}