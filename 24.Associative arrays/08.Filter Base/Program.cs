using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Filter_Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ageCollection = new Dictionary<string, int>();
            Dictionary<string, double> salaryCollection = new Dictionary<string, double>();
            Dictionary<string, string> occupationCollection = new Dictionary<string, string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "filter base")
            {
                string[] arg = input.Split(" -> ");

                string userName = arg[0];
                string unknown = arg[1];

                double salary;
                int age;
                string occupation;

                if (double.TryParse(unknown, out salary))
                {
                    salaryCollection[userName] = salary;
                }
                else if (int.TryParse(unknown, out age))
                {
                    ageCollection[userName] = age;
                }
                else
                {
                    occupation = unknown;
                    occupationCollection[userName] = occupation;
                }
            }

                input = Console.ReadLine();

                string collection = String.Empty;

                if (input == "Age")
                {
                    foreach (var item in ageCollection)
                    {
                        Console.WriteLine($"Name: {item.Key}");
                        Console.WriteLine($"Age: {item.Value}");
                        Console.WriteLine("====================");
                    }
                } 

                else if (input == "Salary")
                {
                    foreach (var item in salaryCollection)
                    {
                        Console.WriteLine($"Name: {item.Key}");
                        Console.WriteLine($"Salary: {item.Value:F2}");
                        Console.WriteLine("====================");
                    }
                }

                else
                {
                    foreach (var item in occupationCollection)
                    {
                        Console.WriteLine($"Name: {item.Key}");
                        Console.WriteLine($"Position: {item.Value}");
                        Console.WriteLine("====================");
                    }
                }            
        }
    }
}
