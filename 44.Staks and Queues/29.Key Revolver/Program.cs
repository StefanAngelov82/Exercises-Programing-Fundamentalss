
int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());


Stack<int> bullets = new Stack<int>(Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse));

Queue<int> locks = new Queue<int>(Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse));
int intelligenceValue = int.Parse(Console.ReadLine());

int counter = 0;

int initialBulletsCount = bullets.Count;

while (locks.Count > 0 && bullets.Count > 0)
{
    if (bullets.Pop() <= locks.Peek())
    {
        locks.Dequeue();
        Console.WriteLine("Bang!");
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    counter++;

    if (counter == gunBarrelSize && bullets.Count > 0)
    {
        Console.WriteLine("Reloading!");
        counter = 0;
    }
}



if (locks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    int moneyEarned = intelligenceValue - bulletPrice * (initialBulletsCount - bullets.Count);
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
}