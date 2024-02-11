

using System.Threading.Channels;

Stack<int> initialFuel = new Stack<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse));

Queue<int> consumptionIndex = new Queue<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse));

Queue<int> neededFuel = new Queue<int>(Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse));

int counter = 1;

while (initialFuel.Any())
{
    if (initialFuel.Pop() - consumptionIndex.Dequeue() >= neededFuel.Dequeue())
    {
        Console.WriteLine($"John has reached: Altitude {counter++}");
        continue;
    }

    Console.WriteLine($"John did not reach: Altitude {counter}");
    break;
}

if (initialFuel.Any())
{
    Console.WriteLine("John failed to reach the top.");

    if (counter == 1 )
        Console.WriteLine("John didn't reach any altitude.");

    else
    {
        List<string> data = new List<string>();

        for (int i = 1; i < counter; i++)
        {
            data.Add($"Altitude {i}");
        }

        Console.Write("Reached altitudes: ");
        Console.Write(string.Join(", ", data));
    }
}
else
    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
    
