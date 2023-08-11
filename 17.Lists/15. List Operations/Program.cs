using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace _4._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                switch (CommadArguments(command, 0))
                {
                    case "Add":
                        AddElement(numbers, CommadArguments(command, 1));
                        break;
                    case "Insert":
                        InsertElement(numbers, command);
                        break;
                    case "Remove":
                        RemoveElement(numbers, command);
                        break;
                    case "Shift":
                        ShiftElements(numbers, command);
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
        static string CommadArguments(string comand, int element)
        {
            string[] elements = comand.Split(" ").ToArray();

            if (element == 0)       return elements[0];
            else if (element == 1)  return elements[1];
            else                    return elements[2];
        }
        static void AddElement(List<int> numbers, string number)
        {
            int additionalNumber = int.Parse(number);
            numbers.Add(additionalNumber);
        }
        static void RemoveElement(List<int> numbers, string command)
        {
            int targetIndex = int.Parse(CommadArguments(command, 1));

            if (targetIndex < 0 || targetIndex >= numbers.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                numbers.RemoveAt(targetIndex);
            }
        }
        static void InsertElement(List<int> numbers, string command)
        {
            int insertNumber = int.Parse(CommadArguments(command, 1));
            int targetIndex = int.Parse(CommadArguments(command, 2));

            if (targetIndex < 0 || targetIndex >= numbers.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                numbers.Insert(targetIndex, insertNumber);
            }
        }
        static void ShiftElements(List<int> numbers, string command)
        { 

            string moveDirection = CommadArguments(command, 1);
            int count = int.Parse(CommadArguments(command, 2));            

            if (moveDirection == "left")
            {
                ShiftLeft(numbers, count);
            }
            else
            {
                ShiftRight(numbers, count);
            }
        }
        static void ShiftLeft(List<int> numbers, int count)
        {
            int realCount = count % numbers.Count;

            for (int i = 1; i <= realCount; i++)
            {
                int fistElemet = numbers.First();
                numbers.RemoveAt(0);
                numbers.Add(fistElemet);
            }
        }
        static void ShiftRight(List<int> numbers, int count)
        {
            int realCount = count % numbers.Count;
            for (int i = 1; i <= realCount; i++)
            {
                int LastElement = numbers.Last();
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, LastElement);
            }
        }
    }
}
