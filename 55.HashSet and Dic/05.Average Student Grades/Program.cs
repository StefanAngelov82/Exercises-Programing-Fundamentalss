using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsData = new Dictionary<string, List<decimal>>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                string name = inputArg[0];
                decimal grade = decimal.Parse(inputArg[1]);

                if (!studentsData.ContainsKey(name))
                {
                    studentsData[name] = new List<decimal>();
                }

                studentsData[name].Add(grade);
            }

            foreach (var student in studentsData)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => $"{x:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
