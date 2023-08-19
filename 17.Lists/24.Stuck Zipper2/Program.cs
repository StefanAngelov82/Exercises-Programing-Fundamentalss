using System;
using System.Collections.Generic;
using System.Linq;

namespace Stuck_Zipper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> FirstList = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToList();
            List<int> SecondList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int minimumNumberOfDigits = int.MaxValue;

            minimumNumberOfDigits = FindingMinNumberOfDigits(FirstList, minimumNumberOfDigits);
            minimumNumberOfDigits = FindingMinNumberOfDigits(SecondList, minimumNumberOfDigits);

            RemuveBiggerElements(FirstList, minimumNumberOfDigits);
            RemuveBiggerElements(SecondList, minimumNumberOfDigits);

            int index = 1;

            for (int i = 0; i < FirstList.Count; i++)
            {
                int currentsElement = FirstList[i];

                SecondList.Insert(Math.Min(index,SecondList.Count), currentsElement);
                index += 2;
            }

            Console.WriteLine(minimumNumberOfDigits);
            Console.WriteLine(string.Join(" ", FirstList));
            Console.WriteLine(string.Join(" ", SecondList));

        }

        static void RemuveBiggerElements(List<int> list, int minimumNumberOfDigits)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int currentNumberOfDigits = CalculateNumberOfdigits(list[i]);

                if (currentNumberOfDigits > minimumNumberOfDigits)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static int FindingMinNumberOfDigits(List<int> List, int minimumNumberOfDigits)
        {
            foreach (int digit in List)
            {
                int numberOfdigits = CalculateNumberOfdigits(digit);

                if (numberOfdigits < minimumNumberOfDigits)
                {
                    minimumNumberOfDigits = numberOfdigits;
                }
            }

            return minimumNumberOfDigits;
        }

        static int CalculateNumberOfdigits(int digit)
        {
            int currentDigit = Math.Abs(digit);
            int numberOfDigits = 0;
         

            while (currentDigit > 0)
            {
                numberOfDigits++;
                currentDigit /= 10;
            }

            return numberOfDigits;
        }
    }
}
