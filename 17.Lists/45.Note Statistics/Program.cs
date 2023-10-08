using System;
using System.Collections.Generic;
using System.Linq;

namespace Note_Statistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] note = {"C", "C#", "D", "D#","E", "F", "F#","G", "G#","A","A#","B"};
            double[] Frequency = { 261.63, 277.18, 293.66, 311.13, 329.63, 349.23, 369.99, 392.00, 415.30, 440.00, 466.16, 493.88};

            double[] input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            List<string> Notes = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Frequency.Length; j++)
                {
                    if (Frequency[j] == input[i])
                    {
                        Notes.Add(note[j]);
                        break;
                    }
                }
            }

            List <string> Naturals = new List<string>(Notes.Where(x => x.Length == 1));            
            List <string> Sharps = new List<string>(Notes.Where(x => x.Length > 1));

            Console.Write("Notes: ");
            Console.WriteLine(String.Join(" ", Notes));
            Console.Write("Naturals: ");
            Console.WriteLine(String.Join(", ", Naturals));
            Console.Write("Sharps: ");
            Console.WriteLine(String.Join(", ", Sharps));

            double sumNatural = 0;

            for (int i = 0; i < Naturals.Count; i++)
            {
                for (int j = 0; j < note.Length; j++)
                {
                    if (Naturals[i] == note[j])
                    {
                        sumNatural += Frequency[j];
                        break;
                    }
                }
            }

            Console.Write("Naturals sum: ");
            Console.WriteLine($"{sumNatural:F2}");

            double sumSharps = 0;

            for (int i = 0; i < Sharps.Count; i++)
            {
                for (int j = 0; j < note.Length; j++)
                {
                    if (Sharps[i] == note[j])
                    {
                        sumSharps += Frequency[j];
                        break;
                    }
                }
            }

            Console.Write("Sharps sum: ");
            Console.WriteLine($"{sumSharps:F2}");
        }
    }
}
