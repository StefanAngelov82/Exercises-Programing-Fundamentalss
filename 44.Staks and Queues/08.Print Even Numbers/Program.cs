namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> data = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int counter = data.Count;
           
            while (counter > 0)
            {
                if (data.Peek() % 2 == 0) data.Enqueue(data.Dequeue());                
                else                      data.Dequeue();                

                counter--;
            }

            Console.WriteLine(String.Join(", ", data));            

        }
    }
}