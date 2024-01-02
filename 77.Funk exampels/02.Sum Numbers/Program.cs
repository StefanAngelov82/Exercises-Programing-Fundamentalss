namespace Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] data = input.Split(", ").Select(Parse1).ToArray();
            Console.WriteLine(data.Count());
            Console.WriteLine(data.Sum());


        }

        static int Parse1(string str) => int.Parse(str);
        
    }
}