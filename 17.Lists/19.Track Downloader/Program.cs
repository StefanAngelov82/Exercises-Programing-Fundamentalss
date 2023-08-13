using System;
using System.Collections.Generic;
using System.Linq;

namespace Track_Downloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wards = Console.ReadLine().Split(' ');

            List<string> filenames = new List<string>();

            string input = String.Empty;           

            while ((input = Console.ReadLine()) != "end")
            {
                bool isValid = false;

                for (int i = 0; i < wards.Length; i++)
                {
                    if (input.Contains(wards[i]))
                    {
                        isValid = true;
                        break;
                    }
                }
                
                if (!isValid)
                {
                    filenames.Add(input);
                }                
            }           

            filenames.Sort();

            foreach (var files in filenames)
            {
                Console.WriteLine(files);
            }
        }
    }
}
