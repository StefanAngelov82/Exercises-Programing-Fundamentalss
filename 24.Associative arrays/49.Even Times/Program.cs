using System.Runtime.InteropServices;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> data = new Dictionary<int, int>();

            int N  = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!data.ContainsKey(number))
                {
                    data[number] = 0;
                }

                data[number]++;
            }

            Console.WriteLine((data.FirstOrDefault(x=>x.Value % 2 == 0)).Key);
        }
    }
}