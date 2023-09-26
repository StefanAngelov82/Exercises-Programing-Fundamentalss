using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Array_Manipulator_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = String.Empty;
            
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command
                    .Split(' ');

                string cmdType = cmdArg[0];

                if (cmdType == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArg[1]);
                    

                    if (exchangeIndex < 0  || exchangeIndex >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                   numbers = ExchangeArrayParts(numbers, exchangeIndex);
                }
                else if (cmdType == "max")
                {
                    string oddOrEven = cmdArg[1];

                    int maxIndex = MaxElementOfTypeIindex(numbers, oddOrEven);

                    if (maxIndex == -1)
                    {
                        Console.WriteLine("No match");
                    }
                    else
                    {
                        Console.WriteLine(maxIndex);
                    }
                }
                else if (cmdType == "min")
                {
                    string oddOrEven = cmdArg[1];
                    int minIndex = MinElementOfTypeIindex(numbers, oddOrEven);
                    if (maxIndex == -1)
                    {
                        Console.WriteLine("No match");
                    }
                    else
                    {
                        Console.WriteLine(minIndex);
                    }
                }
            }
        }
        static int[] ExchangeArrayParts(int[] numbers,int xchangeIndex)
        {
            int[] excangedNumbers = new int[numbers.Length];
            int exNumbersIndex = 0;

            for (int i = exNumbersIndex + 1; i < numbers.Length; i++)
            {
                excangedNumbers[exNumbersIndex] = numbers[i];  
                exNumbersIndex++;
            }

            for (int i = 0; i <= exNumbersIndex; i++)
            {
                excangedNumbers[exNumbersIndex] = numbers[i];
                exNumbersIndex++;
            }

            return excangedNumbers;
        }

        static int MaxElementOfTypeIindex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int MaxValue = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentDigit = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currentDigit % 2 == 0 && currentDigit >= MaxValue )
                    {
                        MaxValue = currentDigit;
                        index = i;
                    }
                }
                else if ((oddOrEven == "odd"))
                {
                    if (currentDigit % 2 != 0 && currentDigit >= MaxValue)
                    {
                        MaxValue = currentDigit;
                        index = i;
                    }
                }

            }
          
        }
        static int MinElementOfTypeIindex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int MinValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentDigit = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currentDigit % 2 == 0 && currentDigit <= MinValue)
                    {
                        MinValue = currentDigit;
                        index = i;
                    }
                }
                else if ((oddOrEven == "odd"))
                {
                    if (currentDigit % 2 != 0 && currentDigit <= MinValue)
                    {
                        MinValue = currentDigit;
                        index = i;
                    }
                }

            }

        }
    } 
}
 