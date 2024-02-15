

Stack<int> worms = new Stack<int>(Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

Queue<int> holes = new Queue<int> (Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

int matches = 0;
int deadWorms = 0;

while (worms.Any() && holes.Any())
{
    if (worms.Peek() == holes.Dequeue())
    {
        worms.Pop();
        matches++;
        continue;
    }       

    if (worms.Peek() - 3 > 0) 
        worms.Push(worms.Pop() - 3);
    else
    {
        worms.Pop();
        deadWorms++;
    }           
}

if (matches > 0) Console.WriteLine($"Matches: {matches}");
else             Console.WriteLine("There are no matches.");

if (worms.Count == 0 && deadWorms == 0)     Console.WriteLine("Every worm found a suitable hole!");
else if (worms.Count == 0 && deadWorms > 0) Console.WriteLine("Worms left: none");
else                                        Console.WriteLine($"Worms left: {String.Join(", ", worms)} ");

if (holes.Count == 0) Console.WriteLine("Holes left: none");
else Console.WriteLine($"Holes left: {string.Join(", ", holes)}"); 

