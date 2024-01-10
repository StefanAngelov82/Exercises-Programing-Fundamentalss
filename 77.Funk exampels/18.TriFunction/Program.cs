namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();


            Func<string, int, bool> check =
                (x, y) =>
                {
                    int count = 0;

                    for (int i = 0; i < x.Length; i++)
                    {
                        count += x[i];
                    }

                    return count >= y;
                };

            foreach (string name in names)
            {
                if (check(name, N))
                {
                    Console.WriteLine(name);
                    break;
                }
            };                 
        }
    }
}