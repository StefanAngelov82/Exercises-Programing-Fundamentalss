using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)        
        {           
            List<int> numbers = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            string comand = String.Empty;
            bool isUsed = false;

            while ((comand = Console.ReadLine()) != "end")
            {
                
                switch (ComandRecagnition(comand, 0))
                {
                    case "Add":
                    case "Remove":
                    case "RemoveAt":
                    case "Insert":
                        numbers = Execute(numbers, comand);
                        isUsed = true;
                        break;
                    case "Contains":
                        Contains(numbers, comand);
                        break;
                    case "PrintEven":
                    case "PrintOdd":
                        PrintEvenOdd(numbers, comand);
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        Filter(numbers, comand);
                        break;
                }
            }
            if (isUsed)
            {
                 Console.WriteLine(string.Join(" ", numbers));
            }                
           
            static string ComandRecagnition(string comand, int RequetedElement)
            {
                string[] input = comand.Split(' ');

                if (RequetedElement == 0) return input[0];
                else if (RequetedElement == 1) return input[1];
                else return input[2];
            }
            static List<int> Execute(List<int> numbers, string comand)
            {
                int targetNumber = int.Parse(ComandRecagnition(comand, 1));

                if (ComandRecagnition(comand, 0) == "Add")
                {
                    numbers.Add(targetNumber);
                }
                else if (ComandRecagnition(comand, 0) == "Remove")
                {
                    numbers.Remove(targetNumber);
                }
                else if (ComandRecagnition(comand, 0) == "RemoveAt")
                {
                    numbers.RemoveAt(targetNumber);
                }
                else if (ComandRecagnition(comand, 0) == "Insert")
                {
                    int index = int.Parse(ComandRecagnition(comand, 2));
                    numbers.Insert(index, targetNumber);
                }

                return numbers;
            }
            static void Contains(List<int> numbers, string comand)
            {
                int targetNumber = int.Parse(ComandRecagnition(comand, 1));

                if (numbers.Contains(targetNumber))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No such number");
                }
            }
            static void PrintEvenOdd(List<int> numbers,string comand)
            {
                foreach (var number in numbers)
                {
                    if ((ComandRecagnition(comand, 0) == "PrintEven") && number % 2 == 0)
                    {
                        Console.Write(number + " ");                        
                    }
                    else if ((ComandRecagnition(comand, 0) == "PrintOdd") && number % 2 != 0)
                    {
                        Console.Write(number + " ");
                        
                    }
                }
                Console.WriteLine();
            }
            static void Filter(List<int> numbers,string comand)
            {
                int targetNumber = int.Parse(ComandRecagnition(comand, 2));
                string condition = ComandRecagnition(comand, 1);

                if (condition == "<")
                {
                    foreach (var item in numbers)
                    {
                        if (item < targetNumber) Console.Write(item + " ");
                    }
                }
                else if (condition == "<=")
                {
                    foreach (var item in numbers)
                    {
                        if (item <= targetNumber) Console.Write(item + " ");
                    }

                }
                else if (condition == ">")
                {
                    foreach (var item in numbers)
                    {
                        if (item > targetNumber) Console.Write(item + " ");
                    }
                }
                else 
                {
                    foreach (var item in numbers)
                    {
                        if (item >= targetNumber) Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
