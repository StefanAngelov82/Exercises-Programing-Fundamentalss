namespace ConcertHall
{
    public class StartUp
    {
        static void Main()
        {
            ConcertHall hall = new ConcertHall(new List<int>() {1, 2, 3});

            foreach (int seats in hall)
            {
                Console.WriteLine(seats);
            }
        }
    }
}