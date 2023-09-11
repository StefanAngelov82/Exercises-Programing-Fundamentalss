using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Registered_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var registerUsers = new Dictionary<string, DateTime>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input
                    .Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                string data = inputArg[1];

                DateTime date = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                registerUsers.Add(name, date);
            }           

            foreach (var kvp in registerUsers.OrderByDescending(x => x.Value).Reverse().TakeLast(5))
            {
                Console.WriteLine($"{kvp.Key}");
            }
        }
    }
}
