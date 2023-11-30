using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tikets = Console.ReadLine().Split(", ").Select(x =>x.Trim()).ToArray();


            foreach (string ticket in tikets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string pattern = @"[\$]{6,10}|[\#]{6,10}|[\@]{6,10}|[\^]{6,10}";

                string firstHalf = ticket.Substring(0, ticket.Length/2);
                string secondHalf = ticket.Substring(ticket.Length/2);                

                Regex reg = new Regex(pattern);

                Match firstMatch = reg.Match(firstHalf);
                Match seconfMatch = reg.Match(secondHalf);
                int matchLenght = Math.Min(firstMatch.Value.Length, seconfMatch.Value.Length); 

                if (!firstMatch.Success || !seconfMatch.Success || firstMatch.Value[0] != seconfMatch.Value[0])
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
                else if (firstMatch.Value.Length == 10 && seconfMatch.Value.Length == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{firstMatch.Value[0]} Jackpot!");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {matchLenght}{firstMatch.Value[0]}");
                }
            }
        }
    }
}