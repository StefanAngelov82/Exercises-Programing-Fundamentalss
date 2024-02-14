
Queue<int> tools = new Queue<int> (Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

Stack<int> substances = new Stack<int>(Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

List<int> challenges = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

while (substances.Count != 0 && tools.Count != 0)
{
    int result = tools.Peek() * substances.Peek();

    if (challenges.Any(x => x == result))
    {
        tools.Dequeue();
        substances.Pop();
        challenges.Remove(result);
        continue;
    }

    tools.Enqueue(tools.Dequeue() + 1);

    if (substances.Peek() - 1 <= 0)
        substances.Pop();

    else    
        substances.Push(substances.Pop() - 1);
}

if (challenges.Count > 0)
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
else
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");


if (tools.Count > 0)
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");

if (substances.Count > 0)
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");

if(challenges.Count > 0)
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
