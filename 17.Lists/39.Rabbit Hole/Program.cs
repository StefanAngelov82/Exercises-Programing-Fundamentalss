using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabbit_Hole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> fieldpositions = Console.ReadLine()
                .Split(" ")
                .ToList();

            int livePoints = int.Parse(Console.ReadLine());

            int currentPosition = 0;
            string status = String.Empty;

            while (status != "tired" && status != "winner" && status != "dead")
            {
                switch (PositinDefinition(fieldpositions, 0, currentPosition))
                {
                    case "RabbitHole":

                        status = "winner";
                        break;

                    case "Left":
                    case "Right":

                        livePoints -= int.Parse(PositinDefinition(fieldpositions, 1, currentPosition));

                        if (livePoints <= 0)
                        {
                            status = "tired";
                            break;
                        }
                        else
                        {
                            currentPosition = Moving(fieldpositions, currentPosition);
                        }
                        break;

                    case "Bomb":

                        livePoints -= int.Parse(PositinDefinition(fieldpositions, 1, currentPosition));

                        if (livePoints <= 0)
                        {
                            status = "dead";
                            break;
                        }
                        else
                        {
                            fieldpositions.RemoveAt(currentPosition);
                            currentPosition = 0;
                        }
                        break;
                }

                DeployMine(fieldpositions, livePoints);
            }

            PrintingResultStatus(status);

        }

        static void PrintingResultStatus(string status)
        {
            if (status == "tired")
            {
                Console.WriteLine("You are tired. You can't continue the mission");
            }
            else if (status == "winner")
            {
                Console.WriteLine("You have 5 years to save Kennedy!");
            }
            else if (status == "dead")
            {
                Console.WriteLine("You are dead due to bomb explosion!");
            }
        }

        static void DeployMine(List<string> fieldpositions, int livePoints)
        {
            if (PositinDefinition(fieldpositions, 0, (fieldpositions.Count - 1)) == "RabbitHole" || PositinDefinition(fieldpositions, 0, (fieldpositions.Count - 1)) == "Bomb")
            {
                string toBeAdd = "Bomb|" + livePoints;
                fieldpositions.Add(toBeAdd);
            }
            else
            {
                fieldpositions.RemoveAt(fieldpositions.Count - 1);
                string toBeAdd = "Bomb|" + livePoints;
                fieldpositions.Add(toBeAdd);
            }
        }

        static string PositinDefinition(List<string> fieldpositions, int argumnt, int currentPositin)
        {
            string[] positonArg = fieldpositions[currentPositin]
                .Split("|")
                .ToArray();
            if (argumnt == 0) return positonArg[0];
            else              return positonArg[1];
        }
        static int Moving(List<string> fieldpositions, int curentPosition)
        {
            string direction = PositinDefinition(fieldpositions, 0, curentPosition); 
            int steps = int.Parse(PositinDefinition(fieldpositions, 1, curentPosition));

            if (direction == "Left")
            {
                curentPosition -= steps;
            }
            else
            {
                curentPosition += steps;
            }

            if (curentPosition < 0)
            {
                curentPosition = 0;
            }                                                                 
            else if (curentPosition >= fieldpositions.Count - 1)
            {
                int overstep = curentPosition - (fieldpositions.Count - 1);
                curentPosition = overstep - 1;
            }

            return curentPosition;
        }
    }
}
