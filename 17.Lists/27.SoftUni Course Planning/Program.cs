using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lesons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string coureseChanges = String.Empty;

            while ((coureseChanges = Console.ReadLine()) != "course start")
            {
                CourseChanges(lesons, coureseChanges);
            }

            PrintSoftUniProgram(lesons);
        }
        static void CourseChanges(List<string> lesons, string coureseChanges)
        {
            string command = CommandRecagnition(coureseChanges, 0);

            switch (command)
            {
                case "Add":     AddLesson(lesons, coureseChanges);    break;
                case "Insert":  InsertLesson(lesons, coureseChanges); break;
                case "Remove":  RemoveLesson(lesons, coureseChanges); break;
                case "Swap":    SwapLessons(lesons, coureseChanges);  break;         
                case "Exercise":AddExercise(lesons, coureseChanges);  break;                               
            }
        }        
        static string CommandRecagnition(string coureseChanges, int arg)
        {
            string[] cmdArg = coureseChanges
                .Split(':')
                .ToArray();

            if      (arg == 0)  return cmdArg[0];
            else if (arg == 1)  return cmdArg[1];
            else                return cmdArg[2];            
        }
        static void AddLesson(List<string>lesons,string coureseChanges)
        {
            string lesonToAdd = CommandRecagnition(coureseChanges, 1);

            int[] checkingArg = IsLesonOrExerciseExist(lesons, lesonToAdd);

            if (checkingArg[0] == 0)
            {
                lesons.Add(lesonToAdd);
            }
        }       

        static int[] IsLesonOrExerciseExist(List<string> lesons, string nameToCheck)
        {
            int[] checkingArg = new int[2];
            int counter = 0, index = - 1;

            for (int i = 0; i < lesons.Count; i++)
            {
                if (lesons[i] == nameToCheck || lesons[i] == $"{nameToCheck}-Exercise")
                {
                    counter++;
                    index = i; 
                }
            }

            if (counter > 1)
            {
                index--;
            }

            checkingArg[0] = counter;
            checkingArg[1] = index;

            return checkingArg;
        }
        static void PrintSoftUniProgram(List<string> lesons)
        {
            for (int i = 0; i < lesons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lesons[i]}");
            }
        }
        static void InsertLesson(List<string>lesons, string coureseChanges)
        {
            string lesonToAdd = CommandRecagnition(coureseChanges, 1);
            int positionToAdd = int.Parse(CommandRecagnition(coureseChanges, 2));

            int[] checkingArg = IsLesonOrExerciseExist(lesons, lesonToAdd);

            if (checkingArg[0] == 0)
            {
                lesons.Insert(positionToAdd, lesonToAdd);
            }
        }
        static void RemoveLesson(List<string> lesons,string coureseChanges)
        {
            string lessonToRemove = CommandRecagnition(coureseChanges, 1);

            int[] checkingArg = IsLesonOrExerciseExist(lesons, lessonToRemove);

            if (checkingArg[0] > 1)
            {
                lesons.RemoveRange(checkingArg[1], 2);
            }
            else if (checkingArg[0] > 0)
            {
                lesons.RemoveAt(checkingArg[1]);
            }
        }
        static void SwapLessons( List< string> lesons, string coureseChanges)
        {
            string firstLesson = CommandRecagnition(coureseChanges, 1);
            string SecondLesson = CommandRecagnition(coureseChanges, 2);

            int[] checkingArg1 = IsLesonOrExerciseExist(lesons, firstLesson);
            int[] checkingArg2 = IsLesonOrExerciseExist(lesons, SecondLesson);

            if (checkingArg1[1] > checkingArg2[1])
            {
                int[] temp1 = checkingArg1;
                int[] temp2 = checkingArg2;
                checkingArg2 = temp1;
                checkingArg1 = temp2;
            }

            if ((firstLesson == SecondLesson) || (checkingArg1[0] == 0) || (checkingArg2[0] == 0)) return;

            string temporary;            
            
            temporary = lesons[checkingArg1[1]];
            lesons[checkingArg1[1]] = lesons[checkingArg2[1]];
            lesons[checkingArg2[1]] = temporary;

            if (checkingArg1[0] > 1 && checkingArg2[0] > 1)
            {
                temporary = lesons[checkingArg1[1] + 1];
                lesons[checkingArg1[1] + 1] = lesons[checkingArg2[1] + 1];
                lesons[checkingArg2[1] + 1] = temporary;
            }
            else if(checkingArg1[0] == 1 && checkingArg2[0] > 1)
            {
                lesons.Insert(checkingArg1[1] + 1, lesons[checkingArg2[1] + 1]);
                lesons.RemoveAt(checkingArg2[1] + 2);
            }
            else if (checkingArg1[0] > 1 && checkingArg2[0] == 1)
            {
                lesons.Insert(checkingArg2[1] + 1, lesons[checkingArg1[1] + 1]);
                lesons.RemoveAt(checkingArg1[1] + 1);
            }
        }
        static void AddExercise( List<string>lesons,string coureseChanges)
        {
            string lesson = CommandRecagnition(coureseChanges, 1);           

            int[] checkingArg = IsLesonOrExerciseExist(lesons, lesson);

            if (checkingArg[0] == 0)
            {
                lesons.Add(lesson);
                lesons.Add(lesson + "-Exercise");
            }
            else if(checkingArg[0] == 1)
            {
                lesons.Insert(checkingArg[1] + 1,(lesson + "-Exercise"));
            }
        }

    }
}
