namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();

            int index = 0;

            while (text2.Contains(text1))
            {               
                text2 = text2.Remove(text2.IndexOf(text1), text1.Length);
            }

            Console.WriteLine(text2);
        }
    }
}