
using System.Collections.Specialized;

int stationsNumber = int.Parse(Console.ReadLine());
int globalCounter = 0;

Queue<int> data = new Queue<int>();

for (int i = 0; i < stationsNumber; i++)
{
    int[] stationInfo = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    data.Enqueue(stationInfo[0] - stationInfo[1]);    
}

for (int i = globalCounter;i < stationsNumber; i++)
{
    long truckTank = 0;
    Queue<int> currentRound = new Queue<int>(data);

    for (int j = 0; j < globalCounter; j++)
    {
        currentRound.Enqueue(currentRound.Dequeue());
    }

    while (currentRound.Any() && truckTank >= 0)
    {
        truckTank += currentRound.Peek();
        currentRound.Dequeue();        
    }

    if (truckTank >= 0) break;
    
    globalCounter++;   
}

Console.WriteLine(globalCounter);

