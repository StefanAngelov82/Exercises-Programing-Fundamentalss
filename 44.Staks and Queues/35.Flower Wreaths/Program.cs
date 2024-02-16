Queue<int> lilies = new Queue<int> (Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse));

Stack<int> roses = new Stack<int>(Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse));

int storage = 0;
int wreaths = 0;

while (lilies.Any() && roses.Any())
{
    if (lilies.Peek() + roses.Peek() == 15)
    {
        lilies.Dequeue();
        roses.Pop();
        wreaths++;
    }
    else
    {
        if (lilies.Peek() + roses.Peek() < 15)
        {
            storage += lilies.Dequeue() + roses.Pop();
            continue;
        }

        int flowers = lilies.Dequeue() + roses.Pop();

        while (flowers > 15)
        {
            flowers -= 2;

            if (flowers == 15)
            {
                wreaths++;
                break;
            }

            if (flowers < 15)
            {
                storage = +flowers;
                break;
            }
        }       
    }    
}

if (lilies.Any())
{
    storage += lilies.Sum();
}

if (roses.Any())
{
    storage += roses.Sum();
}

wreaths += storage / 15;

if (wreaths >= 5) Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
else Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
