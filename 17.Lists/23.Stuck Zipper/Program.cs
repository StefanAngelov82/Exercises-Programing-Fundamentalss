using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Stuck_Zipper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOne = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> sequenceTwo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            int minLenghtOne = int.MaxValue;
            int count;

            if (sequenceOne.Count <= sequenceTwo.Count)
            {
                count = sequenceTwo.Count;
            }
            else
            {
                count = sequenceOne.Count;
            }

            for (int i = 0; i < count; i++)
            {
                minLenghtOne = FindMinLengh(sequenceOne, minLenghtOne, i);
                minLenghtOne = FindMinLengh(sequenceTwo, minLenghtOne, i);
            }

            RemoveElements(sequenceOne, minLenghtOne);
            RemoveElements(sequenceTwo, minLenghtOne);

            List<string> result = new List<string>();

            ZippingElementsInList(sequenceOne, sequenceTwo, result);

            Console.WriteLine(string.Join(" ", result));

        }

        private static void ZippingElementsInList(List<string> sequenceOne, List<string> sequenceTwo, List<string> result)
        {
            int counter = 0;

            while (counter < sequenceOne.Count && counter < sequenceTwo.Count)
            {
                result.Add(sequenceTwo[counter]);
                result.Add(sequenceOne[counter]);
                counter++;
            }

            if (sequenceOne.Count > sequenceTwo.Count)
            {
                for (int i = counter; i < sequenceOne.Count; i++)
                {
                    result.Add(sequenceOne[i]);
                }

            }

            else if (sequenceOne.Count < sequenceTwo.Count)
            {
                for (int i = counter; i < sequenceTwo.Count; i++)
                {
                    result.Add(sequenceTwo[i]);
                }
            }
        }

        private static void RemoveElements(List<string> sequenceOne, int minLenghtOne)
        {
            for (int i = 0; i < sequenceOne.Count; i++)
            {
                if ((sequenceOne[i].First() == '-') && (sequenceOne[i].Length > (minLenghtOne + 1)))
                {
                    sequenceOne.RemoveAt(i);
                    i--;
                }
                else if ((sequenceOne[i].First() != '-') && (sequenceOne[i].Length > minLenghtOne))
                {
                    sequenceOne.RemoveAt(i);
                    i--;
                }
            }
        }
        static int FindMinLengh(List<string> sequence, int minLenghtOne, int i)
        {
            if ((i < sequence.Count) && (sequence[i].Length < minLenghtOne))
            {
                minLenghtOne = sequence[i].Length;

                if (sequence[i].First() == '-')
                {
                    minLenghtOne--;
                }
            }

            return minLenghtOne;
        }
    }
}
