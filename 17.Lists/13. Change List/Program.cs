using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _2._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();           

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (InputRecognition(input, 0) == "Delete")
                {
                    int elementForRemove = int.Parse(InputRecognition(input, 1));

                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i] == elementForRemove)
                        {
                            elements.RemoveAt(i);
                            i--;
                        }
                    }                 
                }
                else
                {
                    int insertElement = int.Parse(InputRecognition(input, 1));
                    int index = int.Parse(InputRecognition(input, 2));

                    elements.Insert(index, insertElement);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
        static string InputRecognition(string input, int inputPart)
        {
            string[] command = input.Split(' ');

            if (inputPart == 0)     return command[0];
            else if (inputPart == 1)return command[1];
            else                    return command[2];
        }
    }
    
}
