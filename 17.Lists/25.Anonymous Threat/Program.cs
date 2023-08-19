using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                if (ComandDefinition(command, 0) == "merge")
                {
                    int startIndex = int.Parse(ComandDefinition(command, 1));
                    int endIndex = int.Parse(ComandDefinition(command, 2));                    

                    Merge(words, startIndex, endIndex);
                }
                else if (ComandDefinition(command, 0) == "divide")
                {
                    int index = int.Parse(ComandDefinition(command, 1));
                    int partition = int.Parse(ComandDefinition(command, 2));

                    Divide(words, index, partition);
                }
               
            }

            Console.WriteLine(string.Join(" ", words));
        }
        static void Divide(List<string> words, int index, int partition)
        {
            string word = words[index];

            if (partition > word.Length)
            {
                return;
            }

            int partitionLenght = word.Length / partition;
            int partitionRemаinder = word.Length % partition;
            int lastpartitionLenght = partitionLenght + partitionRemаinder;

            List<string> partitions = new List<string>();

            for (int i = 0; i < partition; i++)
            {
                char[] currentpartition; 

                if (i == partition - 1)
                {
                    currentpartition = word
                        .Skip(i * partitionLenght)
                        .Take(lastpartitionLenght)
                        .ToArray();
                }
                else
                {
                    currentpartition = word
                        .Skip(i * partitionLenght)
                        .Take(partitionLenght)
                        .ToArray();                  
                }
                
                partitions.Add(new string(currentpartition));
            }

            words.RemoveAt(index);
            words.InsertRange(index, partitions);
        }
        static string ComandDefinition(string command, int argument)
        {
            string[] cmdArg = command.Split(' ');

            if (argument == 0)      return cmdArg[0];
            else if (argument == 1) return cmdArg[1]; 
            else                    return cmdArg[2];
        }
        static void Merge(List<string> words, int startIndex, int endIndex)
        {
            if (!IsIndexValid(words, startIndex))
            {
                startIndex = 0;
            }
            if (!IsIndexValid(words, endIndex))
            {
                endIndex = words.Count - 1;
            }

            StringBuilder merge = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                merge.Append(words[startIndex]);
                words.RemoveAt(startIndex);
            }

            words.Insert(startIndex, merge.ToString());
        }
        static bool IsIndexValid(List<string> words, int index)
        {
            return index >= 0 && index < words.Count;
        }
    }
}
