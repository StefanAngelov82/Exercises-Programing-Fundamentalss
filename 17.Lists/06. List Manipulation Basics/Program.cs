using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace _6._List_Manipulation_Basics
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

            while ((comand = Console.ReadLine()) != "end")
            {
               numbers = Execute(numbers, comand);
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
        static string ComandRecagnition(string comand, int RequetedElement)
        {
            string[] input = comand.Split(' ');

            if (RequetedElement == 0)      return input[0];
            else if (RequetedElement == 1) return input[1];
            else                           return input[2];            
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
       
    }
}
