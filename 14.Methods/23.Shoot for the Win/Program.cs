using System.Net.WebSockets;

namespace Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;
            int targetCount = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(input);

                if (!(targetIndex < 0 || targetIndex >= targets.Count || targets[targetIndex] == - 1))
                {
                    int tempTargetValue = targets[targetIndex];

                    targets[targetIndex] = - 1;
                    targetCount++;

                    for (int i = 0; i < targets.Count; i++)
                    {  
                        if (targets[i] != - 1 && targets[i] > tempTargetValue)
                        {
                            targets[i] -= tempTargetValue;
                        }
                        else if (targets[i] != - 1 && targets[i] <= tempTargetValue)
                        {
                            targets[i] += tempTargetValue;
                        }
                    }                
                }
            }

            Console.Write($"Shot targets: {targetCount} -> " + string.Join(" ", targets));            
        }
    }
}