using System;
using System.Linq;

namespace The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int i = 0;
            int wagoonsNumber = wagons.Length;

            while (people > 0 && wagoonsNumber > 0)
            {
                int emtySit = 4 - wagons[i];

                if (emtySit <= people)
                {
                    wagons[i] = 4;
                }
                else
                {
                    wagons[i] += people;
                }

                people -= emtySit;
                wagoonsNumber--;
                i++;
            }

            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }
            else if (wagons.Average() != 4)
            {
                Console.WriteLine("The lift has empty spots!");
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
