
Stack<int> money = new Stack<int> (Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

Queue<int> prices = new Queue<int>(Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse));

int count = 0;

while (money.Any() && prices.Any())
{
    if(money.Peek() == prices.Peek())
    {
        count++;
        money.Pop();
        prices.Dequeue();
    }
    else if (money.Peek() < prices.Peek())
    {
        money.Pop();
        prices.Dequeue();
    }
    else
    {
        count++;
        int change = money.Pop() - prices.Dequeue();
        if (money.Any())
        {
            money.Push(change + money.Pop());
        }
        else
        {
            money.Push(change);
        }


    }
}

if (count >= 4)
{
    Console.WriteLine($"Gluttony of the day! Henry ate {count} foods.");
}
else if ( count == 0)
{
    Console.WriteLine("Henry remained hungry. He will try next weekend again.");
}
else
{
    Console.WriteLine( (count == 1) ? $"Henry ate: {count} food." :  $"Henry ate: {count} foods.");
}

