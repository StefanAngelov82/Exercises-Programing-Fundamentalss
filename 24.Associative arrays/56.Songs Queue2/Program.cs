namespace Songs_Queue2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new(
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            //bool IsDone = true;

            while (songs.Any())
            {
                string[] inputArg = Console.ReadLine().Split();

                string song = string.Join(" ", inputArg[1..]);

                switch (inputArg[0])
                {
                    case "Play":

                        //if (songs.Any())
                            songs.Dequeue();

                       // else                        
                          // IsDone = false;                                           

                        break;
                       
                    case "Add":

                        if(songs.Contains(song))
                            Console.WriteLine($"{song} is already contained!");

                        else
                            songs.Enqueue(song);

                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}