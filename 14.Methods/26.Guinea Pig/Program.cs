namespace Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());

            int days = 1;

            while (food > 0 && hay > 0 && cover > 0 && days <= 30)
            {
                food -= 0.3;

                if (days % 2 == 0)
                {
                    hay -= food * 0.05;
                }

                if (days % 3 == 0)
                {
                    cover -= weight / 3;
                }

                days++;
            }

            if (Math.Round(food) <= 0 || Math.Round(hay) <= 0 || Math.Round(cover) <= 0)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:F2}, Hay: {hay:F2}, Cover: {cover:F2}.");
            }
        }
    }
}