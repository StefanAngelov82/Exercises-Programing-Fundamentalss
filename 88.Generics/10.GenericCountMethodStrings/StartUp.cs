namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                list.Add(Console.ReadLine());
            }

            string pattern = Console.ReadLine();


            Console.WriteLine(Compare(list, pattern));

        }
        static int Compare<T>(List<T> list, T pattern)  where T : IComparable 
        {
            int counter = 0;
            
            foreach (var item in list)
            {
                if (item.CompareTo(pattern) > 0)
                {
                    counter++;
                }
            }           

            return counter;
        }
    }
}