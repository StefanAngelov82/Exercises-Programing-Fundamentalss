using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentBook = new Dictionary<string, List<double>>();

            int count =int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string input = Console.ReadLine();

                string[] inputArg = input.Split(" ");

                string studentName = inputArg[0];
                double studentGrade = double.Parse(inputArg[1]);

                if (!studentBook.ContainsKey(studentName))
                {
                    studentBook[studentName] = new List<double>();
                }

                studentBook[studentName].Add(studentGrade);
            }

            foreach (var personData in studentBook)
            {
                Console.WriteLine($"{personData.Key} -> {string.Join(" ", personData.Value.Select(p => string.Format("{0:F2}", p))):F2} (avg: {personData.Value.Average():F2}) ");
            }

        }
    }
}
