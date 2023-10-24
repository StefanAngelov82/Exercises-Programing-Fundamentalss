namespace Text_filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banwords = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string Text = Console.ReadLine();



            for (int i = 0; i < banwords.Length; i++)
            {
                 Text = Text.Replace(banwords[i], new string('*', banwords[i].Length));
            }

            Console.WriteLine(Text);
        }
    }
}