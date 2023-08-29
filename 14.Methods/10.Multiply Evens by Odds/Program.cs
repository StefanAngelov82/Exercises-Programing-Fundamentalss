using System;
using System.Runtime.InteropServices;

namespace Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            number = Math.Abs(number);

             GetMultipleOfEvenAndOdds(GetSumOfOddDigits(number), GetSumOfEvenDigits(number));
        }
        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            
            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 != 0) oddSum += lastDigit;

                number = number / 10;
            }

            return oddSum;
        }
        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 == 0) evenSum += lastDigit;

                number = number / 10;
            }

            return evenSum;
        }
        static void GetMultipleOfEvenAndOdds(int oddSum, int evenSum)
        {
            int result = oddSum * evenSum;
            Console.WriteLine(result);
        }
    }
}
