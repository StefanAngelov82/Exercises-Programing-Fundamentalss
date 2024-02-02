namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> box = new(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

            int capacity = int.Parse(Console.ReadLine());
            int currentCap = capacity;
            int count = 1;
            
            if (box.Count == 0)
            {
                Console.WriteLine(0);
                return;
            } 

            while (box.Any())
            {
                currentCap -= box.Peek();

                if (currentCap < 0)
                {
                    currentCap =  capacity;
                    count++;

                    continue;
                }

                box.Pop();                
            }

            Console.WriteLine(count);
        }
    }
}