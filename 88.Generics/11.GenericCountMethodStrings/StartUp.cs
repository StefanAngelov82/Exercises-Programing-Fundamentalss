namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();

            double N = double.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double pattern = double.Parse(Console.ReadLine());

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