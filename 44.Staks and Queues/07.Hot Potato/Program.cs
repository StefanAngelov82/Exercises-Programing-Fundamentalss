namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int N = int.Parse(Console.ReadLine());

            Queue<string> people = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                people.Enqueue(input[i]);
            }

            int count = 1;
            string name = String.Empty;

            while (people.Count > 1)
            {
                if (count != N)
                {
                    name = people.Dequeue();
                    people.Enqueue(name);

                }
                else
                {
                    name = people.Dequeue();
                    Console.WriteLine($"Removed {name}");
                    count = 0;
                }

                count++;
            }

            Console.WriteLine($"Last is {people.Dequeue()}");
        }
    }
}