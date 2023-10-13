namespace Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToArray();

            string input = String.Empty;

            int position = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] InputArg = input.Split();

                int jump = int.Parse(InputArg[1]);

                position = position + jump;

                if (position >= houses.Length)
                {
                    position = 0;
                }

                houses[position] -= 2;

                if (houses[position] == 0)
                {
                    Console.WriteLine($"Place {position} has Valentine's day.");
                }
                else if (houses[position] < 0)
                {
                    Console.WriteLine($"Place {position} already had Valentine's day.");
                }                
            }

            Console.WriteLine($"Cupid's last position was {position}.");

            int happuHouses = houses.Count(x => x <= 0);

            if (happuHouses == houses.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Length - happuHouses} places.");
            }
        }
    }
}