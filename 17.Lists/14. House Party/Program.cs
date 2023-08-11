using System;
using System.Collections.Generic;

namespace _3._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                string input = Console.ReadLine();

                if (InputRecagnition(input, 1) != "not")
                {
                    AddingPersonInList(list, InputRecagnition(input, 0));
                }
                else
                {
                    RemouvingPersonInList(list, InputRecagnition(input, 0));
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, list));
        }
        static string InputRecagnition(string input, int position)
        {
            string[] wards = input.Split(' ');

            if (position == 0)      return wards[0];
            else                    return wards[2];  
        }
        static void AddingPersonInList(List<string> list, string name)
        {
            if (list.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
            }
            else
            {
                list.Add(name);
            }
        }
        static void RemouvingPersonInList(List<string> list, string name)
        {
            if (!list.Contains(name))
            {
                Console.WriteLine($"{name} is not in the list!");
            }
            else
            {
                list.Remove(name);
            }
        }
    }
}
