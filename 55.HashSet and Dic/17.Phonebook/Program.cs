using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Phonebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> cards = new Dictionary<string, HashSet<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "JOKER")
            {
                string[] inputArg = input.Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];

                if (!cards.ContainsKey(name))
                {
                    cards[name] = new HashSet<string>();
                }

                cards[name].UnionWith(inputArg);
                cards[name].Remove(name);
            }

            Print(cards);

        }

        private static void Print(Dictionary<string, HashSet<string>> cards)
        {
            foreach (var kvp in cards)
            {
                string names = kvp.Key;
                int power = 0;


                foreach (var card in kvp.Value)
                {
                    power = CardCallulation(power, card);
                }

                Console.WriteLine($"{names}:{power}");

            }
        }

        private static int CardCallulation(int power, string card)
        {
            int point;
            int multy;

            if (card.Length > 2)    point = 10;
            else if (char.IsDigit(card[0]))
            {
                point = int.Parse(card[0].ToString());
            }
            else if (card[0] == 'J') point = 11;
            else if (card[0] == 'Q') point = 12;
            else if (card[0] == 'K') point = 13;
            else point = 14;            

            if      (card.Last() == 'S') multy = 4;            
            else if (card.Last() == 'H') multy = 3;            
            else if (card.Last() == 'D') multy = 2;
            else                         multy = 1;            

            power += (multy * point);
            return power;
        }
    }
}
