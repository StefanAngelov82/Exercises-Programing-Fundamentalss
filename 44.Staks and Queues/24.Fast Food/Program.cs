namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodOrder = int.Parse(Console.ReadLine());

            Queue<int> orders = new (Console.ReadLine().Split().Select(int.Parse));

            if (orders.Any())
                Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                foodOrder -= orders.Peek();

                if(foodOrder < 0) break;

                orders.Dequeue();
            }

            if (!orders.Any())            
                Console.WriteLine("Orders complete");
           
            else           
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        }
    }
}