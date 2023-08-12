using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> fields = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> BombArguments = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int bombNumber = BombArguments.First();
            int bombrange = BombArguments.Last();

            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i] == bombNumber)
                {
                    if (i - bombrange >= 0 && i + bombrange < fields.Count)
                    {
                        fields.RemoveRange(i - bombrange, (1 + 2 * bombrange));
                        i -= (bombrange + 1);
                    }
                    else if (i - bombrange < 0 && i + bombrange >= fields.Count)
                    {
                        fields.RemoveRange(0, fields.Count);
                    }
                    else if (i - bombrange < 0 && i + bombrange < fields.Count)
                    {
                        fields.RemoveRange(0, (1 + i + bombrange));
                        i = 0;
                    }
                    else if (i - bombrange >= 0 && i + bombrange >= fields.Count)
                    {
                        fields.RemoveRange(i - bombrange, (bombrange + (fields.Count - i)));
                        i = 0;
                    }
                }
            }

            Console.WriteLine(fields.Sum()); 

            //Console.WriteLine(string.Join(' ', fields));

        }
    }
}
