namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> data = new();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (input[0])
                {
                    case 1:
                        data.Push(input[1]);
                        break;

                    case 2:
                        data.Pop();
                        break;

                    case 3:
                        if(data.Any())
                            Console.WriteLine(data.Max());
                        break;

                    case 4:
                        if(data.Any())
                            Console.WriteLine(data.Min());
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", data));
        }
    }
}