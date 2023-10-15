namespace Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnegry = int.Parse(Console.ReadLine());


            string input = String.Empty;

            int winCount = 0;


            while (initialEnegry >= 0 && (input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance <= initialEnegry)
                {
                    winCount++;

                    initialEnegry -= distance;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winCount} won battles and {initialEnegry} energy");
                    return;
                }

                if (winCount % 3 == 0)
                {
                    initialEnegry += winCount;
                }
            }

            Console.WriteLine($"Won battles: {winCount}. Energy left: {initialEnegry}");

        }
    }
}