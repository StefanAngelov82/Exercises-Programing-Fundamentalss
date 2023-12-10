namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passers = int.Parse(Console.ReadLine());

            string input =String.Empty;
            int counter = 0;

            Queue<string> data = new Queue<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    data.Enqueue(input);
                }
                else
                {
                    int end = data.Count;

                    for (int i = 0; i < Math.Min(passers, end); i++)
                    {
                        Console.WriteLine($"{data.Dequeue()} passed!");
                        counter++;
                    }
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}