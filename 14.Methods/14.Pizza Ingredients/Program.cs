using System.Globalization;

namespace Pizza_Ingredients
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();
            int x = int.Parse(Console.ReadLine());

            string[] used = new string[10];

            int counter = 0;

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == x)
                {
                    used[counter] = ingredients[i];
                    counter++;
                    Console.WriteLine($"Adding {ingredients[i]}.");
                }
                if (counter == 10)
                {
                    break;
                }
            }
            Console.WriteLine($"Made pizza with total of {counter} ingredients.");

            Console.Write("The ingredients are: ");
            Console.Write(string.Join(", ", used.Where(x => x != null)));
            Console.WriteLine(".");

        }
    }
}