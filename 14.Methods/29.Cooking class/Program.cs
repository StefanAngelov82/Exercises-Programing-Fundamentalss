using System.Diagnostics.Metrics;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            double totalFlourPrice = students * priceFlour;

            int currentStudent = 0;
            int counter = 0;

            while (currentStudent < students)
            {
                currentStudent++;

                if (currentStudent % 5 == 0)
                {
                    counter++;
                }                
            }

            totalFlourPrice -= priceFlour * counter;

            double totalEggPrice = students * priceEgg * 10;
            double totalApronPrice = students * priceApron + Math.Ceiling(students * 0.2) * priceApron;

            double totalPrice = totalApronPrice + totalEggPrice + totalFlourPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:F2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice - budget:F2}$ more needed.");
            }
        }
    }
}