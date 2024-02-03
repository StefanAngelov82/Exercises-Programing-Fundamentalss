
Queue<string> queue = new Queue<string>();

int greenTime = int.Parse(Console.ReadLine()); 
int freeTime = int.Parse(Console.ReadLine());
int passedCars = 0;

string input = String.Empty;


while ((input = Console.ReadLine()) != "END")
{
    if (input != "green")
    {
        queue.Enqueue(input);
    }
    else
    {
        int currentGreenTime = greenTime;
        int currentFreeTime = freeTime;

        while (queue.Any() && currentGreenTime > 0)
        {
            if (queue.Peek().Length <= currentGreenTime)
            {                
                currentGreenTime -= queue.Dequeue().Length;
                passedCars++;
            }
            else
            {
                int restPart = queue.Peek().Length - currentGreenTime;

                if (restPart <= freeTime)
                {
                    queue.Dequeue();
                    passedCars++;
                    currentGreenTime = 0;
                }
                else
                {
                    int hitIndex = queue.Peek().Length - currentGreenTime - freeTime ;

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{queue.Peek()} was hit at {queue.Peek()[^hitIndex]}.");
                    return;
                }
            }
        }
    }
}


Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{passedCars} total cars passed the crossroads.");