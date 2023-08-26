using System;
using System.Collections.Generic;
using System.Linq;

namespace Decode_Radio_Frequencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] deliminers = {' ','.'};
            string[] numbers = Console.ReadLine()
                .Split(deliminers)
                .ToArray();

            List<char> leftList = new List<char>();
            List<char> rightList = new List<char>();
            List<char> result = new List<char>();

            char left = ' ', right = ' ';

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    left = (char)int.Parse(numbers[i]);
                    leftList.Add(left);
                }
                else
                {
                    right = (char)int.Parse(numbers[i]);
                    rightList.Add(right);
                }               
            }

            rightList.Reverse();

            result.InsertRange(0,rightList);
            result.InsertRange(0,leftList);

            Console.WriteLine(string.Join("", result));
        }
    }
}
