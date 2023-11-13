namespace Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int indexSlash = input.LastIndexOf('\\');
            int indexDot = input.LastIndexOf(".");

            int lenght = indexDot - (indexSlash + 1);

            string fileName = input.Substring(indexSlash + 1, lenght);
            string extension = input.Substring(indexDot + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}