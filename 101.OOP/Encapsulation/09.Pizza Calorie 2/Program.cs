using Pizza_Calorie_2.Models;

namespace Pizza_Calorie_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dough dough = new Dough("Wholegrain", "Homemade", 100);

            //double cal = dough.Calories * dough.Weight;

            Console.WriteLine(dough.ToString());

        }
    }
}