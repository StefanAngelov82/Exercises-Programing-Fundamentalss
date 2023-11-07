using System.Threading.Channels;

namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> data = new Dictionary<string, List<double>>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!data.ContainsKey(name))
                {
                    data[name] = new List<double>();
                }

                data[name].Add(grade);
            }

            data.Where(x => x.Value.Average() >= 4.50)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value.Average():F2}"));
        }
    }
}