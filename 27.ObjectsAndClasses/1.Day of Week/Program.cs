using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int[] dateArg = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

            DateTime result = new DateTime(dateArg[2], dateArg[1], dateArg[0]);

            Console.WriteLine($"{result.DayOfWeek}");

            //DateTime result = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(result.DayOfWeek);
        }
    }
}